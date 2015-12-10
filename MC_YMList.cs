using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Rings
{
    public partial class MC_YMList : Form
    {
        public MC_YMList()
        {
            InitializeComponent();
        }

        public MC_YMList(int i)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = i;
            //ConfigInfo.SQLconn= "data source=192.168.9.79;initial catalog=WJQ;user id=sa; pwd=1994031311";
            
        }

        string file = Application.StartupPath + "\\Info\\config.ini";
        private void MC_YMList_Load(object sender, EventArgs e)
        {
            loadOption();

            if (comboBox1.SelectedIndex == 0) getList(sqlYM(),"YJ");
            if (comboBox1.SelectedIndex == 1) getList(sqlMC(), "MC");

            

        }
        private void loadOption()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string aline = "";
                while ((aline = sr.ReadLine()) != null)
                {
                   // if (aline.StartsWith("YM")) comboBox1.SelectedIndex = int.Parse(aline.Substring(3));

                    if (aline.StartsWith("SC"))
                    {
                        switch (aline.Substring(3))
                        {
                            case "0":
                                radioButton1.Checked = true;
                                break;
                            case "1":
                                radioButton2.Checked = true;
                                break;
                            case "2":
                                radioButton3.Checked = true;
                                break;
                            default:
                                radioButton1.Checked = true;
                                break;
                        }
                    }

                }
            }


        }
        private string sqlYM()
        {
            string query = "select ";
            query += "YJ_LX,";
            query += "YJ_WJID,";
            query += "YJ_XMID,";
            query += "YJ_SCRQ,";
            query += "YJ_SCSJ,";
            query += "YJ_WJM,";
            query += "YJ_TGR,";
            query += "YJ_BZ,";
            query += "YJ_STATUS,";
            query += "YJ_WJWZ  ";

            query += "from RS2010D where YJ_LX='YM'";
            if (radioButton1.Checked) return query;
            if (radioButton2.Checked) return query + " and  YJ_STATUS='0'";
            if (radioButton3.Checked) return query + " and YJ_STATUS='1'";
            return query;
        }
        private string sqlMC()
        {
            string query = "select ";
            query += "MC_LX,";
            query += "MC_WJID,";
            query += "MC_XMID,";
            query += "MC_SCRQ,";
            query += "MC_SCSJ,";
            query += "MC_WJM,";
            query += "MC_DOCID,";
            query += "MC_TGR,";
            query += "MC_BZ,";
            query += "MC_STATUS, ";
            query += "MC_WJWZ  ";
            query += "from RS2020D where MC_LX='MC'";

            if (radioButton1.Checked) return query;
            if (radioButton2.Checked) return query + " and  MC_STATUS='0'";
            if (radioButton3.Checked) return query + " and MC_STATUS='1'";
            return query;
        }
        public void updateInfo(string file,string start,string value)
        {
            string[] lines = File.ReadAllLines(file,Encoding.UTF8);
            foreach (string line in lines)
            {
                if (line.StartsWith(start))
                {
                    line.Split(':')[1] = value.ToString();
                }
            }
            File.WriteAllLines(file, lines, Encoding.UTF8);
        }
        public void getList(string sql,string type)
        {
            jDBUtil jdb = new jDBUtil(ConfigInfo.SQLconn,"SQL");
            Dgview.DataSource=jdb.getVector(sql);
            Dgview.Columns[type+"_STATUS"].Visible = false;
            foreach (DataGridViewRow x in Dgview.Rows)
            {
                if (x.Cells[type+"_STATUS"].Value.ToString()=="0")
                { x.Cells["STATUS"].Value = 0; }
                if (x.Cells[type+"_STATUS"].Value.ToString() == "1")
                { x.Cells["STATUS"].Value = 1; }
            }
            jdb.Close();
            
        }

        private void MC_YMList_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index1 = comboBox1.SelectedIndex;
            int index0=0;
            if(radioButton1.Checked==true) index0=0;
            if(radioButton2.Checked==true) index0=1;
            if(radioButton3.Checked==true) index0=2;
            updateInfo(file,"YM",index1.ToString());//YM标识源码检查和目测
            updateInfo(file, "SC", index0.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0) getList(sqlYM(), "YJ");
            if (comboBox1.SelectedIndex == 1) getList(sqlMC(), "MC");

        }

        private void Dgview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                string url = Dgview.SelectedRows[0].Cells["YJ_WJWZ"].Value.ToString();
                string parenturl = Dgview.SelectedRows[0].Cells["YJ_WJWZ"].Value.ToString();
                //文件名是上传日期时间等拼接起来的RINGS_20150827142011
                url += "\\Rings_" + Dgview.SelectedRows[0].Cells["YJ_SCRQ"].Value.ToString() + Dgview.SelectedRows[0].Cells["YJ_SCSJ"].Value.ToString().Replace(":", "");
                //下载文件
                string name = ConfigInfo.TempDir + Dgview.SelectedRows[0].Cells["YJ_WJM"].Value.ToString();
                YMform form = new YMform(parenturl,url, name, Dgview.SelectedRows[0].Cells["YJ_WJID"].Value.ToString());
                form.ShowDialog();
                form.Close();
                form.Dispose();
                getList(sqlYM(), "YJ");
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                string url = Dgview.SelectedRows[0].Cells["MC_WJWZ"].Value.ToString();
                //文件名是上传日期时间等拼接起来的RINGS_20150827142011
                url += "\\Rings_" + Dgview.SelectedRows[0].Cells["MC_SCRQ"].Value.ToString() + Dgview.SelectedRows[0].Cells["MC_SCSJ"].Value.ToString().Replace(":", "");
                //下载文件
                string name = ConfigInfo.TempDir + Dgview.SelectedRows[0].Cells["MC_WJM"].Value.ToString();
                MCform form = new MCform(url, name, Dgview.SelectedRows[0].Cells["MC_WJID"].Value.ToString());
                form.ShowDialog();
                form.Close();
                form.Dispose();
                getList(sqlMC(), "MC");
            }
            
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (comboBox1.SelectedIndex == 0) getList(sqlYM(), "YJ");
                if (comboBox1.SelectedIndex == 1) getList(sqlMC(), "MC");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex == 0) getList(sqlYM(), "YJ");
                if (comboBox1.SelectedIndex == 1) getList(sqlMC(), "MC");
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (comboBox1.SelectedIndex == 0) getList(sqlYM(), "YJ");
                if (comboBox1.SelectedIndex == 1) getList(sqlMC(), "MC");
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rings
{
    public partial class DB_Layout : Form
    {
        public DB_Layout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //变一下连接我的数据库，WANJQ\SQLEXPRESS
            //c.Extract("Data Source=192.168.9.6;Initial Catalog=temp;Persist Security Info=True;User ID=sa;Password=asj",textBox1.Text+"\\","SQL");
            //DBLayout.Extract("Data Source=WANJQ\\SQLEXPRESS;Initial Catalog=GSY1;Integrated Security=True", textBox1.Text + "\\", "SQL");
            string path=@txtDirext.Text + @"\" + getDBname(txtConext.Text) + "_Layout_" + DateTime.Now.ToString("yyMMddhhmmss");
            if (DBLayout.Extract(txtConext.Text.Trim(),@path , "SQL") == 0)
            {
                MessageBox.Show("抽取完成！");
            }
            else
            {
                //MessageBox.Show("抽取失败！");
            }

        }



        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtDirsrc.Text = f.SelectedPath.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ////变一下连接我的数据库，WANJQ\SQLEXPRESS
            ////c.Extract("Data Source=192.168.9.6;Initial Catalog=temp;Persist Security Info=True;User ID=sa;Password=asj",textBox1.Text+"\\","SQL");
            // DBLayout.Extract("Data Source=WANJQ\\SQLEXPRESS;Initial Catalog=GSY2;Integrated Security=True", txtDirdes.Text + "\\", "SQL");
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtDirext.Text = f.SelectedPath.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtDirdes.Text = f.SelectedPath.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtDircomCon.Text = f.SelectedPath.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string tempFile0 = Application.StartupPath + @"\temp0";
            string tempFile1 = Application.StartupPath + @"\temp1";
            if (Directory.Exists(@tempFile0)) Directory.Delete(@tempFile0, true);
            Directory.CreateDirectory(@tempFile0);
            if (Directory.Exists(@tempFile1)) Directory.Delete(@tempFile1, true);
            Directory.CreateDirectory(@tempFile1);
            try
            {
                if (DBLayout.Extract(txtConsrc.Text, @tempFile0, "SQL") != 0) return;
                if (DBLayout.Extract(txtCondes.Text, @tempFile1, "SQL") != 0) return;
                DBLayout.Compare(@tempFile0, @tempFile1, @txtDircomCon.Text + @"\DBcompare_" + DateTime.Now.ToString("yyMMddhhmmss"), "SQL");
            }
            catch (Exception ex)
            { }
                finally
            {
                Directory.Delete(@tempFile0, true);
                Directory.Delete(@tempFile1, true);
            }
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                txtDircomFile.Text = f.SelectedPath.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DBLayout.Compare(@txtDirsrc.Text, @txtDirdes.Text, @txtDircomFile.Text + @"\DBcompare_" + DateTime.Now.ToString("yyMMddhhmmss"), "SQL");

        }

        public string getDBname(string con)
        {
            string name = "DataBase";
            string[] temp = con.Split(';');
            foreach (var t in temp)
            {
                if (t.ToLower().StartsWith("initial catalog="))
                {
                    name = t.Split('=')[1];
                    break;
                }
            }
            return name;
        }

        private void DB_Layout_Load(object sender, EventArgs e)
        {
            //加载默认路径
            string file = Application.StartupPath + @"\Config\DBconfig.ini";
            List<string> dirArray = new List<string>();
            if (File.Exists(file))
            {
                dirArray = File.ReadAllLines(file, Encoding.UTF8).ToList<string>();
                foreach (var txt in dirArray)
                {
                    string[] dir = txt.Split('\b');
                    foreach (System.Windows.Forms.Control gp in this.Controls)
                    {
                        if (gp is GroupBox)
                        {
                            foreach (System.Windows.Forms.Control tb in gp.Controls)
                            {
                                if (tb.Name == dir[0])
                                    tb.Text = dir[1];
                            }
                        }
                        if (gp.Name == dir[0])
                            gp.Text = dir[1];
                    }
                }
            }
            
            
        }

        private void DB_Layout_FormClosed(object sender, FormClosedEventArgs e)
        {
            string file = Application.StartupPath + @"\Config\DBconfig.ini";
            string[] dirlist = new string[] { "txtDirext\b" + txtDirext.Text, "txtDircomCon\b" + txtDircomCon.Text, "txtDirsrc\b" +txtDirsrc.Text, "txtDirdes\b" + txtDirdes.Text, "txtDircomFile\b" + txtDircomFile.Text, "txtConext\b" + txtConext.Text.Substring(0, txtConext.Text.LastIndexOf("=")+1), "txtConsrc\b" + txtConsrc.Text.Substring(0, txtConsrc.Text.LastIndexOf("=")+1), "txtCondes\b" + txtCondes.Text.Substring(0, txtCondes.Text.LastIndexOf("=")+1) };
            if (!Directory.Exists(Application.StartupPath + @"\Config")) Directory.CreateDirectory(Application.StartupPath + @"\Config");
            //if (!File.Exists(file)) File.Create(file);
            File.WriteAllLines(file, dirlist, Encoding.UTF8);
        }

       

    }
}

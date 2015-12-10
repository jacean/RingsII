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
    public partial class YMform : Form
    {
        public YMform()
        {
            InitializeComponent();
        }
        public YMform(string p,string u,string f,string i)
        {
            InitializeComponent();
            url = u;
            file = f;
            fileID=i;
            parenturl=p;
            down.DownloadFile(url, file);
            filename = Path.GetFileNameWithoutExtension(file);
            parentdir = Path.GetDirectoryName(file);
            
        }

        private void  ymload()
        {
            //判断有没有之前已经审批过的文件
            { }
            //记得把之前的删掉
            string[] files = Directory.GetFiles(parenturl);
            foreach (string fi in files)
            {
                FileInfo fii = new FileInfo(fi);
                if (fii.Name.StartsWith(filename))
                {
                    string tempfii = parentdir + "//" + fii.Name;
                    down.DownloadFile(parenturl + "\\" + fii.Name, tempfii);
                    File.Delete(parenturl+"\\"+fii.Name);
                    using (StreamReader sr = new StreamReader(tempfii, Encoding.UTF8))
                    {
                        string aline = "";
                        while ((aline = sr.ReadLine()) != null)
                        {
                            string[] tip = aline.Split(new string[] { "->" }, StringSplitOptions.None);
                            int s = int.Parse(tip[0].Split(':')[0]);
                            int e = int.Parse(tip[0].Split(':')[1]);
                            int sc = 0;
                            int ec = 0;
                            //设置审批色
                            //string[] contents = richTextBox1.Text.Split('\n');
                            //sc = richTextBox1.GetFirstCharIndexFromLine(s - 1);
                            //ec = richTextBox1.GetFirstCharIndexFromLine(e - 1) - 1;
                            string content = richTextBox1.Text;
                            int index = 0;
                            for (int i = 0; i < content.Length; i++)
                            {
                                if (content[i] == '\n')
                                {
                                    index++;
                                    if (index == s - 1)
                                    {
                                        sc = i + 1;
                                    }
                                    if (index == e)
                                    {
                                        ec = i-1;
                                    }
                                }
                            }
                            richTextBox1.Select(sc, ec-sc+1);
                            addList(tip[1]);
                            richTextBox1.SelectionLength = 0;
                            //lineRange.Add(tip[0]);
                            //listDict.Add(tip[0], tip[1]);
                            ////richTextBox1.SelectionColor = Color.Red;
                            ////richTextBox1.SelectionBackColor = Color.Yellow;
                            //listTip.Items.Add(aline);
                            ////listTip.SelectedIndex = listTip.Items.Count - 1;
                        }
                    }
                    File.Delete(tempfii);
                }
            }

        }

        Dictionary<string, string> optionDict = new Dictionary<string, string>();
        string filename = "";
        string file = "";
        string fileID = "";
        string url = "";
        string parenturl = "";
        string parentdir = "";
        WebClient down = new WebClient();
        ToolTip tip = new ToolTip();
        //Dictionary<int, int> lineRange = new Dictionary<int, int>();
        List<string> lineRange = new List<string>();
        Dictionary<string, string> listDict = new Dictionary<string, string>();


        private void Form1_Load(object sender, EventArgs e)
        {
            optionLoad();

            richTextBox1.Text = File.ReadAllText(file, Encoding.UTF8);

            ymload();
           
        }
        private void optionLoad()
        {
            using (StreamReader sr = new StreamReader(ConfigInfo.InfoDir+"option.lst"))
            {
                string aline = "";
                while ((aline = sr.ReadLine()) != null)
                {
                    string[] t = aline.Split(':').ToArray();
                    optionDict.Add(t[0], t[1]);
                    listOption.Items.Add(t[0] + ":" + t[1]);
                }
            }


        }

        private void listOption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //确认选择此问题
            addList(listOption.SelectedItem.ToString());
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                addList("Y00:" + textBox1.Text);
            }
        }
        private void addList(string tip)
        {
            if (richTextBox1.SelectionLength > 0)
            {


                int startLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                int endLine = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart + richTextBox1.SelectionLength);

                
                string start = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart).Split('\n').Length.ToString();
               
                string end = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart + richTextBox1.SelectionLength-1).Split('\n').Length.ToString();//在这里减1是为了避免选择时选择了换行符带来的增加
                
                
                lineRange.Add(start+":"+end);
                string key = start + ":" + end;
                try
                {//防止添加相同的项
                    listDict.Add(key, tip);
                    //listTip.Items.Add( richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart));
                    //listTip.Items.Add(richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart + richTextBox1.SelectionLength));
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    listTip.Items.Add(key + "->" + tip);
                    listTip.SelectedIndex = listTip.Items.Count - 1;
                }
                catch (Exception ex)
                { }

            }

        }
        private int[] getLine()
        {
            string t0 = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart);
            string[] t1 = t0.Split('\n');
            int start = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart).Split('\n').Length;
            string t2 = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart + richTextBox1.SelectionLength);
            string[] t3 = t0.Split('\n');
            int end = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart + richTextBox1.SelectionLength).Split('\n').Length;
            int[] lines = { start,end};
            return lines;
        }

        private void listTip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                listTip.Items.RemoveAt(listTip.SelectedIndex);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (listTip.Items.Count == 0) return;
            //审核结果发送
            //审核结果
            string name = Path.GetFileNameWithoutExtension(file);
            string savafile=ConfigInfo.TempDir+name+"_"+Tools.getTimeStamp()+".txt";
            //if (!Directory.Exists(ConfigInfo.FileDir)) Directory.CreateDirectory(ConfigInfo.FileDir);
            using(StreamWriter sw=new StreamWriter(savafile,false,Encoding.UTF8))
            {
                foreach (string i in listTip.Items)
                {
                    sw.WriteLine(i);
                }
            }
            string uploadurl = url.Substring(0, url.LastIndexOf('\\') + 1) + Path.GetFileName(savafile);
            down.UploadFile(uploadurl, savafile);
            File.Delete(file);
            File.Delete(savafile);
            //修改数据库在原界面执行吧，还是在这吧
            //若没有修改,若是权限用户就可以同时加载目录下的审核文件
            string updatesql = "update RS2010D set YJ_STATUS='1',";
            updatesql += "YJ_SPUS='"+ ConfigInfo.UserID+ "',";
            updatesql += "YJ_SPDT='" +Tools.getNowDate()+ "',";
            updatesql += "YJ_SPSJ='" +Tools.getNowTime()+ "'";
            updatesql+=" where YJ_WJID='"+fileID+"'";


            jDBUtil jb=new jDBUtil(ConfigInfo.SQLconn,"SQL");
            jb.executeUpdate(updatesql);


        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = this.Width - 250;
            listOption.Height = splitContainer2.Panel1.Height - listOption.Top;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public delegate void tipShow(string text);
        public event tipShow tipshow;
        public event tipShow tiphide;
        bool inrange = false;
        int[] inRange = { 0, 0 };
        string text = "";
        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();
            p.X = e.X;
            p.Y = e.Y;
            int index = richTextBox1.GetCharIndexFromPosition(p);
            string content = richTextBox1.Text.Substring(0,index);
            int line = content.Split('\n').Length;
            label3.Text = line.ToString();
            
            if (line > inRange[1] || line < inRange[0])
            {
                 foreach (string  k in lineRange)
                {
                    string[] ls = k.Split(':');
                    if (line >= int.Parse(ls[0]) && line <= int.Parse(ls[1]))
                    {
                       
                            inRange[0] = int.Parse(ls[0]);
                            inRange[1] = int.Parse(ls[1]);
                            inrange = true;
                            text = k;
                            break;
                       
                    }
                    else
                    {
                        inrange = false;
                        inRange[0] = 0;
                        inRange[1] = 0;//防止出去后false但再次回去就不显示
                    }
                }
            
               
            }
            if (inrange)
            {
                tipshow += new tipShow(Form1_tipshow);
                tipshow(listDict[text]);
                for (int i = 0; i < listTip.Items.Count; i++)
                {
                    if (listTip.Items[i].ToString().Split(new[] {"->"},StringSplitOptions.None)[0] == text)
                    {
                        listTip.SelectedIndex = i;
                    }
                }

            }
            else
            {
                
                tiphide += new tipShow(Form1_tiphide);
                tiphide("");
            }
            
        }

        void Form1_tiphide(string text)
        {
            tip.Hide(richTextBox1);
        }

      
        void Form1_tipshow(string text)
        {
            
            tip.SetToolTip(richTextBox1, text);
            
            tip.ShowAlways = true;
        }
       
    }
}

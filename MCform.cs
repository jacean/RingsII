using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;

namespace Rings
{
    public partial class MCform : Form
    {

        public Color color = new Color();
        Pen p = new Pen(Color.Black, 2);
        string x = string.Empty;
        Graphics g;
        Graphics gsave;
        bool canMove = false;
        Point pStart;
        Point pEnd;
        Image pic;
        Bitmap bmp;
        //Point point = new Point();

        Dictionary<string, string> optionDict = new Dictionary<string, string>();
        Dictionary<string, int> optionSortDict = new Dictionary<string, int>();
        int count = 0;
        public class selected
        {

           static string key="";
            public static string Key
            {
                get { return key; }
                set { key = value; }
            }

            static string txt="";

            public static string Txt
            {
                get { return selected.txt; }
                set { selected.txt = value; }
            }
           
        }

        public MCform()
        {
            InitializeComponent();
            
        }
        public MCform(string u,string n,string i)
        {
            InitializeComponent();
            url = u;
            name = n;
            fileID = i;
            //pictureBox1.Image = Image.FromFile(url);
           //
            down.DownloadFile(url,name);
            pic = Image.FromFile(name);
            docid =Path.GetFileNameWithoutExtension(name);
        }
        WebClient down = new WebClient();
        string url = "";
        string name = "";
        string docid = "";
        string fileID = "";
        private void setpanel()
        {
            panel1.Height = this.Height - 5;
            panel1.Width = this.Width - 340;
            panel1.Location = new Point(0, 0);
           
            panel2.Width = 150;
            panel2.Height = this.Height - 10;
            panel2.Top = 5;
            panel2.Left = panel1.Width + 172;

            fpanel.Left = panel1.Width + 2;
            fpanel.Top = 5;
            fpanel.Width = 170;
        }

        private void setfpanel()
        {
            
            if (this.Width < SystemInformation.WorkingArea.Width - 170)
            {
                int width = this.Width;
                panel1.Height = this.Height - 5;
                panel1.Width = width - 340;
                panel1.Location = new Point(0, 0);
                panel2.Width = 150;
                panel2.Height = this.Height - 10;
                panel2.Top = 5;
                panel2.Left = panel1.Width + 172;

                fpanel.Left = panel1.Width + 2;
                fpanel.Top = 5;
                fpanel.Width = 170;
                fpanel.BringToFront();
                fpanel.Height = this.Height;
                this.Controls.Add(fpanel);
                this.Width +=170;
            }

           

        }

        private void MCform_Load(object sender, EventArgs e)
        {
            //string file = ConfigInfo.InfoDir+ "Mc.lst";
            //if (File.Exists(file)) File.Delete(file);
            
            optionLoad();
            fpanel.SendToBack();

            panel1.Height = this.Height - 5;
            panel1.Width = this.Width - 170;
            panel1.Location = new Point(0, 0);
            panel2.Width = 150;
            panel2.Height = this.Height - 10;
            panel2.Top = 5;
            panel2.Left = panel1.Width + 2; 


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rectangle rec = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            g = pictureBox1.CreateGraphics();
            gsave = Graphics.FromImage(pictureBox1.Image);
            //gsave.DrawImage(pic, new Point(0, 0));
            gsave.DrawImage(pic,rec);
            g.DrawImage(pic, new Point(0, 0));
            
            //g.DrawImage(pic, rec);
            fpanel.Visible = false;
            x = "quxian";
        }
        

        private void optionLoad()
        {
            using (StreamReader sr = new StreamReader(ConfigInfo.InfoDir+"option.lst"))
            {
                string aline = "";
                while ((aline = sr.ReadLine()) != null)
                {
                    string[] t = aline.Split(':').ToArray();
                    optionDict.Add(t[0],t[1]);
                    optionSortDict.Add(t[0], 0);
                }
            }

            optionSort();
        }
        /// <summary>
        /// 在btn点击后进行词频排序
        /// </summary>
        private void optionSort()
        {
            //对按钮根据使用频率排序
            //optionSortDict.OrderBy(s => s.Value);
            List<KeyValuePair<string, int>> sortlist = optionSortDict.OrderByDescending(s => s.Value).ToList();
            fpanel.Controls.Clear();
            fpanel.Height = this.Height - fpanel.Top;
            for (var i = 0; i < sortlist.Count; i++)
            {
                System.Windows.Forms.Button newBtn = new Button();
                newBtn.Name = sortlist[i].Key;
                newBtn.Text = optionDict[sortlist[i].Key];

                newBtn.Click += new EventHandler(btn_Click);
                newBtn.MouseEnter += new EventHandler(btn_MouseEnter);
                newBtn.Width = fpanel.Width - 25;
                fpanel.Controls.Add(newBtn);

            }
            fpanel.AutoScroll = true;
        }

        private void btn_Click(object sender,EventArgs e)
        {
            Button btn = (Button)sender; //将触发此事件的对象转换为该Button对象

            selected.Key = btn.Name;
            selected.Txt = btn.Text;
            optionSortDict[btn.Name] += 1;
            fpanel.SendToBack();
            optionSort();
            addLab(pEnd.X,pEnd.Y);
            //listBox1.Items.Add(count+"->"+btn.Name+":"+btn.Text);
            listBox1.Items.Add(count + "->" + btn.Name + ":" + btn.Text+":M:E");
            
        }
        private void btn_MouseEnter(object sender,EventArgs e)
        {
            Button btn = (Button)sender;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btn, btn.Text);
            tip.ShowAlways = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                canMove = true;
                pStart.X = e.X;
                pStart.Y = e.Y;
                //MessageBox.Show(pStart.X+":"+pStart.Y);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (canMove)
                {
                    pEnd.X = e.X;
                    pEnd.Y = e.Y;

                    switch (x)
                    {
                        case "Line":
                            p.EndCap = LineCap.NoAnchor;
                            g.DrawLine(p, pStart, pEnd);
                            gsave.DrawLine(p, pStart, pEnd);
                            break;
                        case "Arror":
                            p.EndCap = LineCap.ArrowAnchor;
                            g.DrawLine(p, pStart, pEnd);
                            gsave.DrawLine(p, pStart, pEnd);
                            break;

                        case "Rec":
                            g.DrawRectangle(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            gsave.DrawRectangle(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            break;

                        case "Cir":
                            g.DrawEllipse(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            gsave.DrawEllipse(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            break;
                        case "quxian":

                            break;
                        default:
                            
                            break;
                    }

                    //if (pStart.X > pEnd.X)
                    //    fpanel.Location =new Point( pEnd.X - fpanel.Width,pEnd.Y);
                    //else fpanel.Location = pEnd;
                    //fpanel.BringToFront();
                    //addLab(e.X, e.Y);
                    //point = new Point(e.X, e.Y);
                    //屏蔽其他
                    if (fpanel.Visible == false)
                    {
                        fpanel.Visible = true;
                        optionSort();
                        setfpanel();

                    }

                    

                }
               
                
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (canMove && x == "quxian")
                {
                    pEnd.X = e.X;
                    pEnd.Y = e.Y;
                    g.DrawLine(p, pStart, pEnd);
                    gsave.DrawLine(p, pStart, pEnd);
                    pStart = pEnd;

                }
            }
        }

        private void addLab(float x,float y)
        {
            count += 1;
            Label lab = new Label();
            //lab.Text = selected.Key + ":" + selected.Txt;
            lab.Name = "lab" + count.ToString();
            lab.Text ="<"+ count.ToString()+">";
            lab.Tag = selected.Key + ":" + selected.Txt; 
            lab.Location = new Point((int)x, (int)y);
            lab.AutoSize = true;
            lab.ForeColor = p.Color;
            lab.BackColor = Color.Transparent;
            lab.DoubleClick += new EventHandler(lab_DoubleClick);
            lab.MouseDown += new MouseEventHandler(lab_MouseDown);
            lab.MouseMove += new MouseEventHandler(lab_MouseMove);
            lab.MouseUp += new MouseEventHandler(lab_MouseUp);
            this.pictureBox1.Controls.Add(lab);
            lab.BringToFront();
           
            
        }

        public static bool labDown = false;
        private void lab_MouseEnter(object sender,EventArgs e)
        {
            Label lab = (Label)sender;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(lab, lab.Text);
            tip.ShowAlways = true;
        }
        private void lab_MouseDown(object sender, EventArgs e)
        {
            labDown = true;
        }
        private void lab_MouseMove(object sender, MouseEventArgs e)
        {
            Label lab = (Label)sender;
            Point p = Control.MousePosition;//相对于屏幕的坐标
            Point p1 = this.PointToClient(p);//相对于窗体的坐标
            
            if(labDown)

            lab.Location = new Point(p1.X, p1.Y);//weizhibudui,这是在label的位置，
        }
        private void lab_DoubleClick(object sender,EventArgs e)
        {
            //Label lab = (Label)sender;
            ////lab.Text = selected.Key + ":" + selected.Txt;
            //listBox1.Items.Clear();
            //using (StreamReader sr = new StreamReader(Application.StartupPath + "\\Data\\Mc.lst", Encoding.UTF8))
            //{
            //    string aline = "";
            //    while ((aline=sr.ReadLine()) != null)
            //    {
            //        listBox1.Items.Add(aline);
            //        if (aline.Substring(0,1) == lab.Text.Substring(1, 1))
            //            listBox1.SelectedItem = aline;
            //    }
            //}


        }
        private void lab_MouseUp(object sender, EventArgs e)
        {
            labDown = false;
        }

        #region 画笔设置
        private void button1_Click(object sender, EventArgs e)
        {
            x = "Line";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x = "Arror";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x = "Rec";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            x = "Cir";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog Color = new ColorDialog();
            if (Color.ShowDialog() == DialogResult.OK)
            {
                button5.BackColor = Color.Color;
                color = Color.Color;
                p.Color = Color.Color;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            //gsave.Clear(Color.White);

            pictureBox1.Controls.Clear();
            listBox1.Items.Clear();
            count = 0;
            if (pic == null)
            {

            }
            else
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Rectangle rec = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
                g = pictureBox1.CreateGraphics();
                gsave = Graphics.FromImage(pictureBox1.Image);
                gsave.Clear(Color.Transparent);
                gsave.DrawImage(pic, rec);
                g.DrawImage(pic, new Point(0, 0));
            }
        }
        #endregion


        private void button7_Click(object sender, EventArgs e)
        {
            x = "quxian";
        }

        private void MCform_SizeChanged(object sender, EventArgs e)
        {
            setpanel();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            save();
            
           this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Rings.Input input = new Rings.Input("请输入自定义选项:", "");
            input.ShowDialog();
            int i = listBox1.SelectedIndex;
            //把对应的label。tag也修改了
            foreach (Label lab in pictureBox1.Controls)
            {
                if (lab.Name == "lab" + (i+1).ToString())
                    lab.Tag = "Y00:" + input.Comment;
            }
            listBox1.Items[i] =listBox1.Items[i].ToString().Split('-')[0]+"->Y00:"+input.Comment;//Y00表示自定义

        }

        private void button10_Click(object sender, EventArgs e)
        {
            MCreq req = new MCreq();
            req.ShowDialog();
            List<string> list = req.List;

            req.Close();
            req.Dispose();

            addLab(pEnd.X, pEnd.Y);
            listBox1.Items.Add(count + "->Y-1:" +list[2]+":"+list[0]+":"+list[1]);
        }

        private void MCform_FormClosed(object sender, FormClosedEventArgs e)
        {
            save();
        }

        private void save()
        {
            if (listBox1.Items.Count > 0)
            {

                foreach (Label lab in pictureBox1.Controls)
                {
                    Point pos = new Point(lab.Location.X, lab.Location.Y);
                    SolidBrush drawBrush = new SolidBrush(lab.ForeColor);
                    gsave.DrawString(lab.Text, new Font("宋体", 15f), drawBrush, pos);

                }
                gsave.Save();
                gsave.Dispose();


                foreach (Label lab in pictureBox1.Controls)
                {

                    Image imgtemp = (Image)pictureBox1.Image.Clone();
                    Graphics gsavetemp = Graphics.FromImage(imgtemp);//

                    Point pos = new Point(lab.Location.X, lab.Location.Y);
                    SolidBrush drawBrush = new SolidBrush(lab.ForeColor);


                    gsavetemp.DrawString(lab.Text + "->" + lab.Tag, new Font("宋体", 15f), drawBrush, pos);
                    gsavetemp.Save();
                    if (!Directory.Exists(ConfigInfo.FileDir)) Directory.CreateDirectory(ConfigInfo.FileDir);
                    if (!Directory.Exists(ConfigInfo.DetailsDir)) Directory.CreateDirectory(ConfigInfo.DetailsDir);

                    string imgname = ConfigInfo.FileDir + docid + "_" + lab.Text.TrimStart('<').TrimEnd('>') + ".jpg";
                    imgtemp.Save(imgname, ImageFormat.Jpeg);
                    //Function.saveFile(imgname,"","MC");
                    gsavetemp.Dispose();
                    string itemstart = lab.Text.TrimStart('<').TrimEnd('>');
                    string tip = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.Items[i].ToString().Split('-')[0] == itemstart)
                        {
                            tip = listBox1.Items[i].ToString();

                        }
                    }

                    GlobalFunc.WriteTextToFile(tip.Split(':')[0] + ":" + tip.Split(':')[1], ConfigInfo.DetailsDir + "XZSM.txt", false);
                    GlobalFunc.WriteTextToFile(tip.Split(':')[0] + ":" + tip.Split(':')[1], ConfigInfo.DetailsDir + "YQJG.txt", false);
                    List<string> header = new List<string>();
                    GlobalFunc.WriteHeader(ref header, "XQ");

                    header.Add("TCR=" + ConfigInfo.UserName);
                    //优先级
                    header.Add("YXJ=" + tip.Split(':')[2]);//H\M|L
                    header.Add("ReqType=" + tip.Split(':')[3]);//默认为错误
                    header.Add("TempRingsID=" + "");

                    GlobalFunc.AddToZipDir(header);




                }
                //插入更新语句，表说明已经审核
                string updatesql = "update RS2020D set MC_STATUS='1',";
                updatesql += "MC_SPUS='" + ConfigInfo.UserID + "',";
                updatesql += "MC_SPDT='" + Tools.getNowDate() + "',";
                updatesql += "MC_SPSJ='" + Tools.getNowTime() + "'";
                updatesql += " where MC_WJID='" + fileID + "'";
                jDBUtil jb = new jDBUtil(ConfigInfo.SQLconn, "SQL");
                jb.executeUpdate(updatesql);

            }
            pictureBox1.Image.Dispose();
            pic.Dispose();
            listBox1.Items.Clear();
            File.Delete(name);
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}

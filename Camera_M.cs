using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AForge.Imaging;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing.Imaging;

namespace Rings
{
    public partial class Camera_M : Form
    {
        static int count = 0;
        int i = -1;
        bool flag = true;
        string path = "";
        public bool Done = false;
        public Camera_M()
        {
            InitializeComponent();
            videoSourcePlayer1.VideoSource = Clscamera.videoSource;

        }

        private void Camera_M_Load(object sender, EventArgs e)
        {
            Function.creatTFolder();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            //panel2.Hide();
            //Class.Function.creatTFolder();
            if (Directory.Exists(ConfigInfo.FileDir))
            { }
            else
                Function.creatTFolder();

                path = ConfigInfo.FileDir+@"GP\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            
            Done = true;
                Clscamera.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                //既然图片变化之后没法改，那就图片变化之前改
                if (i == count - 1)
                {
                    if (i > -2)
                        textBox3.Text = "GP_" + (i + 1).ToString() + ".jpg";
                    if (i > -1)
                        textBox2.Text = "GP_" + i.ToString() + ".jpg";
                    if (i > 0)
                        textBox1.Text = "GP_" + (i - 1).ToString() + ".jpg";
                }
                label2.Text = (count + 1).ToString();
            
        }

        public void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            //string fullPath = txtDir.Text + "\\temp\\";
            
            string ipath = path + "\\" + "GP_" + count++.ToString() + ".jpg";
            bmp.Save(ipath, ImageFormat.Jpeg);

            //动态添加控件有问题，会在添加控件前再次执行GP
            if (flag) i = count - 1;
            if (i == count - 1)
            {
                ////////////*********************8///////////////
                //图片名需得和截图分开，因为改变文本框会影响newFrame
                ////////////////////////////////////////////////////
                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = System.Drawing.Image.FromFile(ipath); //textBox3.Text = ipath.Substring(ipath.LastIndexOf("\\" + 2));

                string imgp = @path + "\\" + "GP_" + (count - 2).ToString() + ".jpg";
                string imgpp = @path + "\\" + "GP_" + (count - 3).ToString() + ".jpg";
                if (File.Exists(@imgp))
                {
                    if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                    pictureBox2.Image = System.Drawing.Image.FromFile(@imgp);
                    // textBox2.Text = imgp.Substring(imgp.LastIndexOf("\\")+2);
                }
                if (File.Exists(@imgpp))
                {
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    pictureBox1.Image = System.Drawing.Image.FromFile(@imgpp);
                    //textBox3.Text = imgpp.Substring(imgpp.LastIndexOf("\\") +2);
                }


            }
            else
            {

            }

            Clscamera.videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);


        }


        #region 停止，将文件压缩并发送至服务器，删除本地临时文件
        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            this.Dispose();
        }
        #endregion

        #region 上一页
        private void button5_Click(object sender, EventArgs e)
        {

            if (i > 2)
                i--;
            else
            {
                MessageBox.Show("没有上一页了");
                return;
            }
            flag = false;

            string img = path + "\\" + "GP_" + i.ToString() + ".jpg";
            string imgp = path + "\\" + "GP_" + (i - 1).ToString() + ".jpg";
            string imgpp = path + "\\" + "GP_" + (i - 2).ToString() + ".jpg";
            if (File.Exists(img))
            {
                if (pictureBox3.Image != null)
                {
                    pictureBox3.Image.Dispose();

                }
                pictureBox3.Image = System.Drawing.Image.FromFile(img);
                textBox3.Text = img.Substring(img.LastIndexOf("\\") + 1);

            } if (File.Exists(imgp))
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                pictureBox2.Image = System.Drawing.Image.FromFile(imgp);
                textBox2.Text = imgp.Substring(imgp.LastIndexOf("\\") + 1);
            }
            else
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                pictureBox2.Image = null;
                textBox2.Text = "";
            } if (File.Exists(imgpp))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                pictureBox1.Image = System.Drawing.Image.FromFile(imgpp);
                textBox1.Text = imgpp.Substring(imgpp.LastIndexOf("\\") + 1);
            }
            else
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                pictureBox2.Image = null;
                textBox1.Text = "";
            }
        }
        #endregion

        #region 下一页
        private void button6_Click(object sender, EventArgs e)
        {

            if (i < count - 1)
                i++;
            else
            {
                flag = true;
                MessageBox.Show("没有下一页了");
                return;
            }

            string img = path + "\\" + "GP_" + (i - 2).ToString() + ".jpg";
            string imgn = path + "\\" + "GP_" + (i - 1).ToString() + ".jpg";
            string imgnn = path + "\\" + "GP_" + i.ToString() + ".jpg";
            if (File.Exists(imgnn))
            {
                if (pictureBox3.Image != null)
                {
                    pictureBox3.Image.Dispose();

                }
                pictureBox3.Image = System.Drawing.Image.FromFile(imgnn);
                //pictureBox3.Image.Dispose();
                textBox3.Text = imgnn.Substring(imgnn.LastIndexOf("\\") + 1);
            }
            else
            {
                if (pictureBox3.Image != null)
                {
                    pictureBox3.Image.Dispose();

                }
                pictureBox3.Image = null;
                textBox3.Text = "";
            }
            if (File.Exists(imgn))
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                pictureBox2.Image = System.Drawing.Image.FromFile(imgn);
                //pictureBox2.Image.Dispose();
                textBox2.Text = imgn.Substring(imgn.LastIndexOf("\\") + 1);
            }
            else
            {
                if (pictureBox2.Image != null)
                {
                    pictureBox2.Image.Dispose();
                }
                pictureBox2.Image = null;
                textBox2.Text = "";
            }
            if (File.Exists(img))
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                pictureBox1.Image = System.Drawing.Image.FromFile(img);
                //pictureBox1.Image.Dispose();
                textBox1.Text = img.Substring(img.LastIndexOf("\\") + 1);
            }


        }
        #endregion

        #region 调整命名
        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            canChange(3);
        }
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            canChange(2);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            canChange(1);
        }



        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.ReadOnly == false)
            {
                if (e.KeyValue == 13)
                {
                    ReName(textBox3, 3, i);

                }
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.ReadOnly == false)
            {
                if (e.KeyValue == 13)
                {
                    ReName(textBox2, 2, i - 1);

                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.ReadOnly == false)
            {
                if (e.KeyValue == 13)
                {
                    ReName(textBox1, 1, i - 2);

                }
            }
        }

        #endregion
        /// <summary>
        /// 激活调整模式
        /// </summary>
        /// <param name="i">第几个pictureBox</param>
        void canChange(int i)
        {

            foreach (Control t in panel2.Controls)
            {
                if (t.Name == "textBox" + i.ToString())
                {
                    TextBox txt = t as TextBox;
                    txt.ReadOnly = false;
                }
            }

        }

        /// <summary>
        /// 连拍重命名//检测是否可写->键盘值是否是回车->重命名格式是否正确->遍历所有图片进行受影响的改变
        /// </summary>
        /// <param name="txt">要修改图片对应的textbox</param>
        /// <param name="range">1、2、3</param>
        /// <param name="oldNum">当前图片的序列号，3》i,2》i-1,1》i-2</param>

        void ReName(TextBox txt, int range, int oldNum)
        {
            int newNum = -1;

            if (txt.Text.Trim().Substring(0, 3) == "GP_" && int.TryParse(txt.Text.Trim().Substring(3, txt.Text.Trim().LastIndexOf(".") - 3), out newNum))
            {//进行遍历来重命名

                string newName = txt.Text.Trim();
                DirectoryInfo tempDir = new DirectoryInfo(path);
                List<FileInfo> imgs = tempDir.GetFiles().ToList<FileInfo>();
                if (imgs[0].Name == "Thumbs.db" || imgs[0].Name == "thumbs.db")
                {
                    imgs.Remove(imgs[0]);
                }

                //判断输入的数字顺序是否合法
                if (newNum > -2 && newNum < count)
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    if (pictureBox2.Image != null)
                        pictureBox2.Image.Dispose();
                    if (pictureBox3.Image != null)
                        pictureBox3.Image.Dispose();

                    if (newNum > -1)
                    {
                        //File.Create(path + "\\GP_-1.jpg").Dispose();
                        //close不好使
                        imgs[oldNum].MoveTo(path + "\\GP_-1.jpg");
                        //文件已存在时不能移动过去
                        //找到新赋值的会冲突的那张图片，临时命名为GP_-1，将重命名的图片进行重命名，
                        if (newNum < oldNum)
                        {
                            for (int x = oldNum - 1; x > newNum - 1; x--)
                            {
                                imgs[x].MoveTo(path + "\\GP_" + (int.Parse(imgs[x].Name.Substring(3, txt.Text.Trim().LastIndexOf(".") - 3)) + 1).ToString() + ".jpg");
                            }
                        }
                        else if (newNum > oldNum)
                        {
                            for (int x = oldNum + 1; x < newNum + 1; x++)
                            {
                                imgs[x].MoveTo(path + "\\GP_" + (int.Parse(imgs[x].Name.Substring(3, txt.Text.Trim().LastIndexOf(".") - 3)) - 1).ToString() + ".jpg");
                            }
                        }
                        else
                        {
                        }
                        imgs[oldNum].MoveTo(path + "\\GP_" + newNum.ToString() + ".jpg");
                    }
                    else
                    {
                        File.Delete(imgs[oldNum].FullName);
                        for (var x = oldNum + 1; x < count; x++)
                        {
                            imgs[x].MoveTo(path + "\\GP_" + (int.Parse(imgs[x].Name.Substring(3, imgs[x].Name.LastIndexOf(".") - 3)) - 1).ToString() + ".jpg");

                        }
                        label2.Text = (count-- - 1).ToString();
                        i--;
                    }
                    txt.ReadOnly = true;
                    MessageBox.Show("重命名、重新排序成功！");
                    //刷新图片显示
                    if (i > 1) pictureBox1.Image = System.Drawing.Image.FromFile(path + "\\GP_" + (i - 2).ToString() + ".jpg"); else pictureBox1.Image = null;
                    if (i > 0) pictureBox2.Image = System.Drawing.Image.FromFile(path + "\\GP_" + (i - 1).ToString() + ".jpg"); else pictureBox2.Image = null;
                    if (i > -1) pictureBox3.Image = System.Drawing.Image.FromFile(path + "\\GP_" + i.ToString() + ".jpg"); else pictureBox3.Image = null;
                    if (i > 1) textBox1.Text = "GP_" + (i - 2).ToString() + ".jpg"; else textBox1.Text = "";
                    if (i > 0) textBox2.Text = "GP_" + (i - 1).ToString() + ".jpg"; else textBox2.Text = "";
                    if (i > -1) textBox3.Text = "GP_" + i.ToString() + ".jpg"; else textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("请输入数量内的数字");
                }

            }
            else
            {
                MessageBox.Show("重命名格式不正确！");

            }

        }

        private void Muliti_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clscamera.videoSource.Stop();
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            if (Done)
            {
                clear();
                Zip.ZIP(path, ConfigInfo.FileDir + "GP.zip");
                Directory.Delete(path, true);
                Function.saveFile(ConfigInfo.FileDir + "GP.zip", "", "FJ");
                Function.sendServer("GP.zip");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            //MessageBox.Show("文件已删除");
            count = 0; i = -1; label2.Text = "0";
            Done = false;
            

        }

        public void clear()
        {
            textBox1.Text = "";
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = null;
            textBox2.Text = "";
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }
            pictureBox2.Image = null;
            textBox3.Text = "";
            if (pictureBox3.Image != null)
            {
                pictureBox3.Image.Dispose();
            }
            pictureBox3.Image = null;
        }
    }
}

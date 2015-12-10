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
    public partial class Camera_S : Form
    {

        public PictureBox pic = new PictureBox();
        public bool Done = false;
        public Camera_S()
        {
            InitializeComponent();
            videoSourcePlayer1.VideoSource = Clscamera.videoSource;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Function.creatTFolder();
            Done = true;
            if (Clscamera.videoSource == null)
            {
                MessageBox.Show("设备未连接"); return;
            }
            panel1.BringToFront();
                Clscamera.videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);

           
        }




        public void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {

            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();

            string fullPath = ConfigInfo.FileDir;
            
            string ipath = fullPath + "GP.jpg";
            bmp.Save(ipath, ImageFormat.Jpeg);
            pic.Image = bmp;
            Clscamera.videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
            ///////////////////////////
            //把图片发送至服务器
            ////
            //MessageBox.Show("操作完成，3秒后程序关闭。。。。。。", "提示", MessageBoxIcon.Information);
            //Tip tip = new Tip("操作完成，3秒后程序关闭。。。。。。");
            //tip.Show();
            //System.Threading.Thread.Sleep(3000);
            //tip.Dispose();


        }


        

        private void Camera_S_Load(object sender, EventArgs e)
        {
            
            panel1.Controls.Add(pic);
            pic.Size = panel1.Size;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            panel1.SendToBack();
        }


        private void Camera_S_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clscamera.videoSource.Stop();
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            //将图片发送至服务器
            if (Done)
            {
                Function.saveFile(ConfigInfo.FileDir+"GP.jpg", "", "FJ");//GP:高拍
                //Directory.Delete("tempWork", true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //如果没有拍照呢
            this.Close();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //panel1.Visible = false;
            panel1.SendToBack();
            Function.creatTFolder();
            Done = false;
           

        }
    }
}

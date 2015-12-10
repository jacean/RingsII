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
    public partial class Camera : Form
    {
        public Camera()
        {
            InitializeComponent();

           
        }

        Dictionary<string, string> dictXm = new Dictionary<string, string>();


        private void button1_Click(object sender, EventArgs e)
        {

            Clscamera.Cameraint(cobCam.SelectedIndex);
            Camera_S forms = new Camera_S();
            forms.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clscamera.Cameraint(cobCam.SelectedIndex);
            Camera_M formm = new Camera_M();
            formm.ShowDialog();//这种模式下，formm关闭后返回到本窗体
            this.Close();
            this.Dispose();
        }

        private void Camera_start_Load(object sender, EventArgs e)
        {

            //if (rw_dog.findPort().ToString() == "-92")
            //{
            //    MessageBox.Show("未插入加密狗，请插入后重试！");
            //    this.Close();
            //    this.Dispose();
            //    Application.Exit();//只是程序退出的话后面还会继续执行
            //    return;
            //}
            List<string> list = Clscamera.GetDevices();
            if (list.Count > 0)
            {
                foreach (var x in list)
                {
                    cobCam.Items.Add(x);
                }
                cobCam.SelectedIndex = list.Count - 1;

            }
            else
            {
                MessageBox.Show("未检测到设备,请连接设备后再试");
                Application.Exit();
                return;
            }

            //读取加密狗

            rw_dog dog = new rw_dog();
            labID.Text = dog.jRead(220, 4);
            //labID.Text = "0031";
            ConfigInfo.UserID = labID.Text;
            dictXm = Function.getlistXM();//获取项目列表时进行员工名的判断并赋值给全局变量
            labName.Text =ConfigInfo.UserName;

            string dftXm = "";
            using (StreamReader sr = new StreamReader(Application.StartupPath+"\\Info\\config.ini", Encoding.UTF8))
            {
                string aline = "";

                while ((aline = sr.ReadLine()) != null)
                    if (aline.StartsWith("XM:"))
                    {
                        dftXm = aline.Substring(3);
                        break;
                    }
            }

            foreach (var x in dictXm)
            {
                cobXM.Items.Add(x.Value);
            }
            
                for (int c = 0; c <cobXM.Items.Count; c++)
                {
                    string xm = cobXM.Items[c].ToString();
                    if (dftXm.Equals(xm)) { cobXM.SelectedIndex = c; }
                }
                if (dftXm == "") cobXM.SelectedIndex = 0;

           
            //创建上传数据目录
            Function.dirPrepare();
        }

        private void cobXM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function.updateConfig("XM",cobXM.SelectedItem.ToString());
            foreach (var x in dictXm)
            {
                if (cobXM.SelectedItem.ToString() == x.Value)
                    ConfigInfo.CurrentProject = x.Key;
            }
        }

      


    }
}

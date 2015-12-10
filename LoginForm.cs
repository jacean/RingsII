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
    public partial class LoginForm : Form
    {
        private MainForm mainForm;
        public LoginForm()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (this.checkLogin() == false)
            {
                MessageBox.Show("账号或密码错误");
                return;
            }
            Function.getVersion();
            Function.checkUpdate();

            this.mainForm = new MainForm();
            this.mainForm.Show();
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private bool checkLogin()
        {
            //TODO
            //联网验证用户名、密码
            //验证成功，写入文件
            bool loginOK = true;        // (this.userIDTextBox.Text == "1111");
            if (loginOK)
            {
                GlobalFunc.UserDefaults_Get();

                ConfigInfo.UserID = this.userIDTextBox.Text;
                ConfigInfo.UserName = "未连线";
                ConfigInfo.Donkey = "A687";

                GlobalFunc.UserDefaults_Write();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //删除升级残留文件
            Function.delTempUpdate();

            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            if (Tools.RunningInstance() != null)
            {
                MessageBox.Show("这个程序已经启动，不能再次打开！");
                this.Close();
                this.Dispose();
                Application.Exit();
                return;
            }
            if (rw_dog.findPort().ToString() == "-92")
            {
                MessageBox.Show("未插入加密狗，请插入后重试！");
                this.Close();
                this.Dispose();
                Application.Exit();//只是程序退出的话后面还会继续执行
                return;
            }
            timer1.Interval = 1000;
            timer1.Start();
            

            rw_dog dog = new rw_dog();
            userIDTextBox.Text = dog.jRead(220, 4);
            pwdTextBox.Text = dog.jGetID();
            ConfigInfo.Donkey = dog.jGetID();
            dirPrepare();
            loginBtn_Click(null,null);
            //如果验证员工号错误则退出，在判断的地方加退出代码
            //程序逻辑为启动程序->检测加密狗->无则退出，有则验证->正确则进入，错误则退出并提示


        }

        private void dirPrepare()
        {
            if (Directory.Exists(ConfigInfo.TempDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.TempDir);
            }
            //if (Directory.Exists(ConfigInfo.FileDir) == false)
            //{
            //    Directory.CreateDirectory(ConfigInfo.FileDir);
            //}
            //if (Directory.Exists(ConfigInfo.HeaderDir) == false)
            //{
            //    Directory.CreateDirectory(ConfigInfo.HeaderDir);
            //}
            if (Directory.Exists(ConfigInfo.ConfigDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.ConfigDir);
            }
            if (Directory.Exists(ConfigInfo.DataDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.DataDir);
            }
            if (Directory.Exists(ConfigInfo.UserDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.UserDir);
            }
            Directory.CreateDirectory(ConfigInfo.LogDir);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rw_dog.findPort().ToString() == "-92")
            {
                timer1.Stop();
                MessageBox.Show("未插入加密狗，请插入后重试！");

                this.Close();
                this.Dispose();
                Application.Exit();//只是程序退出的话后面还会继续执行
                return;
            }

        }
    }
}

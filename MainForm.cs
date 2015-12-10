using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Rings
{
    public partial class MainForm : Form
    {
        private bool exitApp = false;
        //private FloatForm floatForm;
        //private bool showFloatForm;
        public MainForm()
        {
            InitializeComponent();
            this.configServerURL();

            //Sync from actual Rings Server if connected
            masterData.Sync_ServerForMasters();

            this.userNameLabel.Text = ConfigInfo.UserName;
            this.getProjectInfo();
            this.notifyIcon.Visible = false;
        }

        private void getProjectInfo()
        {
            this.projectComboBox.Items.Clear();
            GlobalFunc.LoadListFromFile(this.projectComboBox, ConfigInfo.ProjectList);
            GlobalFunc.Combo_Set(this.projectComboBox, ConfigInfo.CurrentProject);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 10;
            this.Top = 150;
            this.dragAndDropBox1.onFileDrop += (file, shiftDown) =>
            {
                if (shiftDown)
                {
                    //源码检查
                    ClassifyForm.saveFile(file, "", "YM");
                }
                else
                {
                    //不需要传递ringsID？
                    ClassifyForm classifyForm = new ClassifyForm(file, "");
                    classifyForm.Show();
                }
            };
            ScreenShotForm screenShotForm = new ScreenShotForm();
            //floatForm = new FloatForm();
            //floatForm.Show();
            //this.showFloatForm = true;
            this.syncTimer.Interval = 1000;
            this.syncTimer.Start();


        }

        private void configServerURL()
        {
            Dictionary<string, string> dictionary = GlobalFunc.GetConfigValue(ConfigInfo.ConfigFile, ',');
            //This is the master server, ask this server with a fixed URL
            // then this server will return the url for the actual Rings Server
            ConfigInfo.ServerURL = dictionary["url"];
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                notifyIcon.ContextMenuStrip.Show();
            }
            else
            {
                this.showMenuItem_Click(null, null);
            }
        }

        private void showMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            //this.notifyIcon.Visible = false;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.exitApp = true;
            //System.Environment.Exit(0);
            this.notifyIcon.Visible = false;
            this.notifyIcon.Dispose();
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.exitApp == false)
            {
                e.Cancel = true;
                this.Hide();
                this.notifyIcon.Visible = true;
                this.notifyIcon.ShowBalloonTip(500);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.notifyIcon.Visible = false;
            this.notifyIcon.Dispose();
        }

        private void syncProcess()
        {

            //if (File.Exists(ConfigInfo.FilesToSync))
            //{
            List<string> filesToSync = new List<string>();
            //string temp = "";
            //using (StreamReader sr = new StreamReader(ConfigInfo.FilesToSync, Encoding.Default))
            //{
            //    while ((temp = sr.ReadLine()) != null)
            //    {
            //        filesToSync.Add(temp);
            //    }
            //}

            filesToSync.AddRange(Directory.GetFiles(ConfigInfo.DataDir));
            if (filesToSync.Count == 0)
            {
                this.syncTimer.Start();
                return;
            }
            try
            {
                this.uploadFiles(filesToSync);
                string syncTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.Invoke(new Action(() =>
                {
                    this.Sts.Text = syncTime;
                }));
                this.syncTimer.Start();
                //File.Delete(ConfigInfo.FilesToSync);
                //MessageBox.Show("同步完成！");
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    //this.connectErrorLabel.Visible = true;
                    //this.syncBtn.Visible = true;
                }));

                MessageBox.Show(ex.Message);
            }


            // }
        }

        private void uploadFiles(List<string> filesToSync)
        {
            using (WebClient webclient = new WebClient())
            {
                foreach (var file in filesToSync)
                {
                    webclient.UploadFile(ConfigInfo.ServerURL, file);
                    File.Delete(file);
                }
            }
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<string> listToWrite = new List<string>();
            //listToWrite.Add(projectComboBox.SelectedItem.ToString());
            //string temp = "";
            //foreach (var item in projectComboBox.Items)
            //{
            //    if ((temp=item.ToString())!=listToWrite[0])
            //    {
            //        listToWrite.Add(temp);
            //    }
            //}
            //GlobalFunc.WriteListToFile(listToWrite.ToArray(), ConfigInfo.ProjectList, false);
            ConfigInfo.CurrentProject = ((ListItem)projectComboBox.SelectedItem).ID;
            GlobalFunc.UserDefaults_Write();
        }

        private void floatWindMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.showFloatForm)
            //{
            //    this.floatForm.Hide();
            //    this.showFloatForm = false;
            //}
            //else
            //{
            //    this.floatForm.Show();
            //    this.showFloatForm = true;
            //}
        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            this.syncTimer.Stop();

            //ThreadStart threadStart = this.syncProcess;
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            this.syncTimer.Start();
            //进行更新检测


        }

        private void dragAndDropBox1_Load(object sender, EventArgs e)
        {

        }

        private void newProjectBtn_Click(object sender, EventArgs e)
        {

        }
        #region
        /*
        //事件调用
        private void toolsBox01_Click(object sender, EventArgs e)
        {
            //清空Temp文件夹


            ReqForm reqForm = new ReqForm();
            reqForm.ShowDialog();
        }
        //管理界面
        private void toolsBox02_Click(object sender, EventArgs e)
        {
            string url = ConfigInfo.RingsServerURL + "/jsp/jlogin.jsp";
            System.Diagnostics.Process.Start(url);
        }
        //加密狗调用
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
           StringBuilder DevicePath = new StringBuilder("", 260);
            DevicePath = rw_dog.findPort();
            if (DevicePath.ToString() == "-92")
            {
                MessageBox.Show("未找到加密狗，请插入加密狗后再试！");


            }
            else
            {
                secDog dog = new secDog();
                dog.ShowDialog();
            }
        }
        //高拍仪调用
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Camera_start camera_start = new Camera_start();
            camera_start.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process pcs=Process.GetCurrentProcess();

            if (DialogResult.Yes == MessageBox.Show("确定要卸载吗？", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                this.notifyIcon.Visible = false;
                this.notifyIcon.Dispose();
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
                //Process.Start("Uninstall.exe", pcs.ProcessName+"  \""+dir+"\"  Rings2Sync");
                MessageBox.Show(dir.ToString());
                Process.Start(dir + @"\uninstall.bat", "Rings \"" + dir.ToString() + "\"");
                
                
            }               
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("请确认更新！", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                this.notifyIcon.Visible = false;
                this.notifyIcon.Dispose();
                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
                string upd = dir.ToString() + "\\Update.exe";
                string uin = dir.ToString() + "\\uninstall.bat";
                string uzip = dir.ToString() + "\\ICSharpCode.SharpZipLib.dll";
                string temp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyyMMdd");
                if (Directory.Exists(temp)) Directory.Delete(temp,true);
                Directory.CreateDirectory(temp);
                File.Copy(uin,temp+"\\uninstall.bat");
                File.Copy(upd, temp + "\\Update.exe");
                File.Copy(uzip, temp + "\\ICSharpCode.SharpZipLib.dll");
                //update.exe : 项目压缩文件，程序安装目录(程序启动目录来自动判断)，快捷方式图标,要杀掉的额外程序
                //dir=G:\ASJ\Intern\Rings_new\bin\Debug
                MessageBox.Show(dir.ToString());
                Process.Start(temp+"\\Update.exe", "http://127.0.0.1:8080/Files/RingsII.zip  \""+dir.ToString()+"\" Resource\\asjlogo64_64.ico Rings2Sync");
                
                
            }   
        }
        */
        #endregion





        #region 面板zhedie
        /*
        private void labTool_Click(object sender, EventArgs e)
        {
            isHide(labTool, panel1,ref height1);
        }
        public static int height1 = 0;
        public static int height2= 0;
        public static int height3 = 0;
        public void isHide(System.Windows.Forms.Label lab, System.Windows.Forms.Panel pan,ref int height)
        {
            if (pan.Height > lab.Height)
            {
                height = pan.Height;
                pan.Height = lab.Height;
            }
            else
            {
                pan.Height = height;
            }
        }

        private void labDB_Click(object sender, EventArgs e)
        {
            isHide(labDB, panel2,ref height2);
        }

        private void labVer_Click(object sender, EventArgs e)
        {
            isHide(labVer, panel3,ref height3);
        }
        */
        #endregion

        private void lbSJ_Click(object sender, EventArgs e)
        {

            //清空Temp文件夹
            ReqForm reqForm = new ReqForm();
            reqForm.ShowDialog();
        }

        private void lbGL_Click(object sender, EventArgs e)
        {
            string url = ConfigInfo.RingsServerURL + "/jsp/jPassThrough.jsp?UserID=" + ConfigInfo.UserID + "&DKey=" + ConfigInfo.Donkey;
            System.Diagnostics.Process.Start(url);
        }

        private void lbGPY_Click(object sender, EventArgs e)
        {
            //Camera camera = new Camera();
            //camera.ShowDialog();
        }

        private void lbJMG_Click(object sender, EventArgs e)
        {
            StringBuilder DevicePath = new StringBuilder("", 260);
            DevicePath = rw_dog.findPort();
            if (DevicePath.ToString() == "-92")
            {
                MessageBox.Show("未找到加密狗，请插入加密狗后再试！");
            }
            else
            {
                DonkeyDog dog = new DonkeyDog();
                dog.ShowDialog();
            }
        }

        private void lbGX_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("请确认是否更新！", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                this.notifyIcon.Visible = false;
                this.notifyIcon.Dispose();
                Function.update();    
            }
        }

        private void lbBJ_Click(object sender, EventArgs e)
        {
            DirCompare dcom = new DirCompare();
            dcom.ShowDialog();
            dcom.Close();
            dcom.Dispose();
        }

        private void lbCQ_Click(object sender, EventArgs e)
        {
            DB_Layout DB = new DB_Layout();
            DB.ShowDialog();
            DB.Close();
            DB.Dispose();
        }

        private void lbMC_Click(object sender, EventArgs e)
        {
            MC_YMList mc = new MC_YMList(1);
            mc.ShowDialog();
            mc.Close();
            mc.Dispose();
        }

        private void lbYM_Click(object sender, EventArgs e)
        {
            MC_YMList ym = new MC_YMList(0);
            ym.ShowDialog();
            ym.Close();
            ym.Dispose();
        }

        private void LbBS_Click(object sender, EventArgs e)
        {
            frmMain fm = new frmMain();
            fm.ShowDialog();
            fm.Close();
            fm.Dispose();
        }


        private void startProgram(string pgmID)
        {
            Process p = Process.Start(Application.StartupPath + @"\" + pgmID);
            p.WaitForExit();
        }
       

        private void lbBD_Click(object sender, EventArgs e)
        {
            startProgram("PatchDeploy.exe");
        }

        private void lbZB_Click(object sender, EventArgs e)
        {
            startProgram("PrepareDeploy.exe");
        }
    }
}

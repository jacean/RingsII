using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Rings
{
    public partial class frmAutoStart : Form
    {
        public frmAutoStart()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            startProgram("SetupAutoStart.msi");
        }
        private void startProgram(string pgmID)
        {
            Process p = Process.Start(Application.StartupPath + @"\" + pgmID);
            p.WaitForExit();
        }

        private void btnBRW_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.Cancel) { return; }
            string dir =fd.SelectedPath+@"\";
            if (!File.Exists(dir + "ASJAutoStart.exe"))
            {
                MessageBox.Show("选择的文件夹不对，找不到 ASJAutoStart.exe！");
                return;
            }
            txtDir.Text = dir;
            StreamWriter sw = new StreamWriter("jAutoStart.ini", false);
            sw.WriteLine(dir);
            sw.Flush();
            sw.Close();
        }

        private void frmAutoStart_Load(object sender, EventArgs e)
        {
            if (!File.Exists("jAutoStart.ini"))
            {
                btnConfig.Enabled = false;
                return;
            }

            StreamReader sr = new StreamReader("jAutoStart.ini");
            txtDir.Text = sr.ReadLine();
            sr.Close();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = "notepad.exe";
            pInfo.Arguments = txtDir.Text + "Startup.lst";
            Process p = Process.Start(pInfo);
            p.WaitForExit();            
        }
    }
}

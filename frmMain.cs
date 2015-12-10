using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Rings
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = Application.StartupPath + @"\BackupUtility.exe";
            pInfo.Arguments = "/setup";
            Process p = Process.Start(pInfo);
            p.WaitForExit();
        }
        private void startProgram(string pgmID)
        {
            Process p = Process.Start(Application.StartupPath + @"\" + pgmID);
            p.WaitForExit();
        }

        private void btnAutoStart_Click(object sender, EventArgs e)
        {
            frmAutoStart frm = new frmAutoStart();
            frm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            startProgram("jExport.exe");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            startProgram("jImport.exe");
        }

        private void btnExeSQL_Click(object sender, EventArgs e)
        {
            startProgram("jExecSQLFile.exe");
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            startProgram("ClientDeploy.exe");
        }

        private void btnUServer_Click(object sender, EventArgs e)
        {
//            startProgram("ASJAutoStart");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
//            startProgram("ASJAutoStart");
        }

        private void btnRings_Click(object sender, EventArgs e)
        {
            download_File("SetupCaptureScreen.msi");
        }

        private void btnASJPrintPlug_Click(object sender, EventArgs e)
        {
            download_File("ASJPrintPluginSetup.msi");
        }
        private void download_File(string file)
        {
            if (fd.ShowDialog() == DialogResult.Cancel) { return; }

            string tFile = fd.SelectedPath + @"\" + file;
            File.Copy(Application.StartupPath + @"\" + file, tFile, true);
            MessageBox.Show("已复制到：" + tFile);
        }
    }
}

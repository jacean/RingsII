using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Rings
{
    class Function
    {
        public static Dictionary<string,string> getlistXM()
        {
            StreamReader sr = new StreamReader("Info\\listXm.lst", Encoding.UTF8);
            Dictionary<string, string> dictXm=new Dictionary<string,string>();
            string aLine = "";
            while ((aLine = sr.ReadLine()) != null)
            {
                if (aLine.StartsWith("P"))
                {
                    string PrjCode = Tools.ParmList(aLine, Tools.DL, 2);
                    string PrjName = Tools.ParmList(aLine, Tools.DL, 3);
                    dictXm.Add(PrjCode, PrjName);
                }
                if (aLine.StartsWith("U"))
                {
                    string UserCode = Tools.ParmList(aLine, Tools.DL, 2);
                    string UserName = Tools.ParmList(aLine, Tools.DL, 3);
                    if (UserCode.Equals(ConfigInfo.UserID))
                    {
                        ConfigInfo.UserName = UserName;
                    }
                }
            }
            
            sr.Close();
            return dictXm;
        }
        public static void updateConfig(string start,string value)
        {
            List<string> temp = new List<string>();
            using (StreamReader sr = new StreamReader("Info\\config.ini"))
            {
                string t = "";
                while ((t = sr.ReadLine()) != null)
                {
                    if (t.StartsWith(start))
                    {
                        t = start + ":" + value;
                    }
                    temp.Add(t);
                }
            }

            File.WriteAllLines("Info\\config.ini",temp.ToArray());
            
        }

        public static void creatTFolder()
        {
            if (Directory.Exists(ConfigInfo.FileDir))
            {
                Directory.Delete(ConfigInfo.FileDir,true);
            }
            Directory.CreateDirectory(ConfigInfo.FileDir);
        }
        public static void sendServer(string zipFile)
        { 
            
        }
        public static void creatPack()
        { 
            
        }

        public static void saveFile(string file, string RingsID, string LX)
        {

            string destFileName = "RINGS_" + Tools.getTimeStamp();
            string destPath = ConfigInfo.FileDir + destFileName;
            if (Directory.Exists(ConfigInfo.FileDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.FileDir);
            }
            
            //File.Copy(file, destPath);
            File.Move(file,destPath);
            List<string> header = new List<string>();
            GlobalFunc.WriteHeader(ref header, LX);

            header.Add("File=" + Path.GetFileName(file));

            header.Add("TGR=" + ConfigInfo.UserName);
            Input input = new Input("请输入文件说明！点击确定提交：", "");
            input.ShowDialog();

            header.Add("Comment=" + input.Comment);

            header.Add("TempRingsID=" + RingsID);

            GlobalFunc.AddToZipDir(header);

            GlobalFunc.ProjectStaff_Update(ConfigInfo.UserName);

        }

        public static void dirPrepare()
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

        public static void getVersion()
        {
            string version = "";
            using (StreamReader sr = new StreamReader(Application.StartupPath+"\\Info\\config.ini", Encoding.UTF8))
            {
                string aline = "";

                while ((aline = sr.ReadLine()) != null)
                    if (aline.StartsWith("VS:"))
                    {
                        version = aline.Substring(3);
                        break;
                    }
            }
            ConfigInfo.Version = int.Parse(version.Replace(".", ""));
        }

        public static void checkUpdate()
        { 
            //从服务器获取版本信息，与当前版本做比较
            string version="";
            version="0.0";//获取服务器信息
            int ver = int.Parse(version.Replace(".", ""));
            //ConfigInfo.Version应该写在配置文档里
            if(ConfigInfo.Version>=ver)
            {
                return;
            }
            if (MessageBox.Show("发现新版本：" + version + "\n是否更新？", "更新提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                update();
            }

        }
        public static void update()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            string upd = dir.ToString() + "\\Update.exe";
            //string uin = dir.ToString() + "\\uninstall.bat";
            string uzip = dir.ToString() + "\\ICSharpCode.SharpZipLib.dll";
            string temp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyyMMdd");
            if (Directory.Exists(temp)) Directory.Delete(temp, true);
            Directory.CreateDirectory(temp);
            //File.Copy(uin, temp + "\\uninstall.bat");
            File.Copy(upd, temp + "\\Update.exe");
            File.Copy(uzip, temp + "\\ICSharpCode.SharpZipLib.dll");
            //update.exe : 项目压缩文件，程序安装目录(程序启动目录来自动判断)，快捷方式图标,要杀掉的额外程序
            //dir=G:\ASJ\Intern\Rings_new\bin\Debug
            //MessageBox.Show(dir.ToString());
            Process.Start(temp + "\\Update.exe", "http://127.0.0.1:8080/Files/RingsII.zip  \"" + dir.ToString() + "\" Resource\\asjlogo64_64.ico Rings2Sync");
            
        }
        public static void delTempUpdate()
        {
            string temp = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyyMMdd");
            if (Directory.Exists(temp)) Directory.Delete(temp, true);
        }

        public static bool torf(string value)
        {
            int v=0;
            try
            { v = int.Parse(value); }
            catch(Exception ex)
            {}
            if (v < 0)
            {
                return false;
            }
            return true;
        }
    }
}

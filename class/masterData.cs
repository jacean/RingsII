using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace Rings
{
    class masterData
    {
        public static void Sync_ServerForMasters()
        {
            //First Level Server
            string portalServer = ConfigInfo.ServerURL;

            //if (!Tools.InternetAvailable())
            //{
            //    return;
            //}

            //Ask portal server for the URL of actual Rings Server
            //if return blank, implies error reading
            ConfigInfo.RingsServerURL = getServerResponse(portalServer);
            if (ConfigInfo.RingsServerURL.Equals("")) { return; }

            //Get the files, if error encountered, quit
            if (!DownloadFiles("UserMasters_" + ConfigInfo.UserID)) { return; }

            //Sync Files
            StreamReader sr = new StreamReader(ConfigInfo.TempDir + "UserMasters.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter(ConfigInfo.ProjectList, false, Encoding.Default);
            string aLine = "";
            while ((aLine = sr.ReadLine()) != null)
            {
                if (aLine.StartsWith("P"))
                {
                    string PrjCode = Tools.ParmList(aLine, Tools.DL, 2);
                    string PrjName = Tools.ParmList(aLine, Tools.DL, 3);
                    sw.WriteLine(PrjCode + Tools.DL + PrjName);
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
            sw.Flush();
            sw.Close();
            sr.Close();

            GlobalFunc.UserDefaults_Write();

            //启动同步程序
            Process.Start(Application.StartupPath + @"\Rings2Sync.exe");
        }
        public static string getServerResponse(string url)
        {
            string tmp = "";
            try
            {
                WebClient wc = new WebClient();
                Stream st = wc.OpenRead(url);
                StreamReader sr = new StreamReader(st);
                tmp = sr.ReadToEnd();
                sr.Close();
            }
            catch { }
            return tmp;
        }
        public static bool DownloadFiles(string fileType)
        {
            WebClient wc = new WebClient();
            string url = ConfigInfo.RingsServerURL + "/jsp/ASJ_RingsServer.jsp?Type=" + fileType + "&User=" + ConfigInfo.UserID + "&DK=" + ConfigInfo.Donkey;
            string localFile = ConfigInfo.TempDir + "UserMasters.txt";
            File.Delete(localFile);
            wc.DownloadFile(url, localFile);
            return true;
        }
        private static string getBodyContent(string html)
        {
            string tmp = "";
            int strPos = html.ToLower().IndexOf("<body>");
            if (strPos == -1)
            {
                strPos = 0;
            }
            else
            {
                strPos += 6;
            }
            int endPos = html.ToLower().IndexOf("</body>");
            if (endPos == -1)
            {
                tmp = html.Substring(strPos);
            }
            else
            {
                tmp = html.Substring(strPos, endPos - strPos);
            }
            return tmp.Replace("\r","").Replace("\n","");
        }
    }
}

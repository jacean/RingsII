using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rings
{
    static class ConfigInfo
    {
        //Portal 服务器URL
        public static string ServerURL = "";
        public static string RingsServerURL = "";

        //数据目录
        public static string DataDir = Application.StartupPath + @"\Data\";
        //配置文件目录
        public static string ConfigDir = Application.StartupPath + @"\Config\";
        //当前用户目录
        public static string UserDir = Application.StartupPath + @"\User\";
        //临时文件目录
        public static string TempDir = Application.StartupPath + @"\Temp\";
        //日志目录
        public static string LogDir = Application.StartupPath + @"\Log\";
        //待压缩文件目录
        public static string FilesToZipDir = Application.StartupPath + @"\Temp\FilesToZip\";

        //项目附件目录
        public static string FileDir = FilesToZipDir + @"File\";
        //项目数据目录
        public static string DetailsDir = FilesToZipDir + @"Details\";
        //附件头文件
        public static string Header = FilesToZipDir + @"Header.txt";

        //待同步文件信息
        //public static string FilesToSync = TempDir + "FilesToSync.txt";

        //用户信息
        public static string UserInfo = UserDir + "UserInfo.txt";
        //项目信息
        public static string ProjectList = UserDir + "ProjectList.txt";

        //配置文件
        public static string ConfigFile = ConfigDir + "Config.ini";
        //保存需求信息的目录
        public static string EventDir = "";


        //当前用户ID
        public static string UserID = "";
        //当前用户名
        public static string UserName = "";
        //当前项目
        public static string CurrentProject = "";
        //当前用户加密狗序号
        public static string Donkey = "";

        public static int Version = 0;

        public static string SQLconn = "data source=WANJQ;initial catalog=WJQ;user id=sa; pwd=wanjq";

        public static string InfoDir = Application.StartupPath + @"\Info\";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace Rings
{
    class Tools
    {
        [DllImport("my3l_ex.dll")]
        public static extern int FindPort(int start, StringBuilder OutKeyPath);
        [DllImport("my3l_ex.dll")]
        public static extern int GetIDVersionEx(ref int id, ref short ver, StringBuilder KeyPath);
        [DllImport("My3l_ex.dll")]
        public static extern int ReadString(StringBuilder outstring, short Address, int len, StringBuilder KeyPath_2);
        [DllImport("My3l_ex.dll")]
        public static extern int WriteString(string InString, short Address, StringBuilder KeyPath_2);

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static string DL = "!";

        public static bool InternetAvailable()
        {
            int I = 0;
            return InternetGetConnectedState(out I, 0);
        }
        public static string getNowTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        static public string getNowDate()
        {
            string tmp = DateTime.Now.ToString("yyyyMMdd");
            return tmp;
        }
        public static string getTimeStamp()
        {
            DateTime dt = DateTime.Now;
            string tmp = dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0') + dt.Day.ToString().PadLeft(2, '0');
            tmp += dt.Hour.ToString().PadLeft(2, '0') + dt.Minute.ToString().PadLeft(2, '0') + dt.Second.ToString().PadLeft(2, '0');
            return tmp;
        }
        public static String get_CheckListBox(CheckedListBox chk)
        {
            string tmp = "";
            for (int r = 0; r < chk.Items.Count; r++)
            {
                if (chk.GetItemChecked(r))
                {
                    string ID = ((ListItem)chk.Items[r]).ID;
                    tmp += " " + ID;
                }
            }
            return tmp.Trim();
        }
        public static string[] split(string strinput, string strSplit)
        {
            char tmp = strSplit.ToCharArray()[0];
            return strinput.Split(tmp);
        }

        public static int ParmCount(string InpVal, string Delimiter)
        {
            return split(InpVal, Delimiter).Length;
        }

        public static string ParmList(
         string InpVal,
         string Delimiter,
         int Position)
        {

            if (InpVal.Equals(""))
            {
                return "";
            }
            string tmp = "";
            try
            {
                tmp = (split(InpVal, Delimiter))[Position - 1];
            }
            catch
            {
                tmp = "";
            }
            return tmp;
        }
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //Loop through the running processes in with the same name 
            foreach (Process process in processes)
            {
                //Ignore the current process 
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file. 
                    if (Assembly.GetExecutingAssembly().Location.
                         Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance.  
                        return process;

                    }
                }
            }
            //No other instance was found, return null.  
            return null;
        }
    }
}

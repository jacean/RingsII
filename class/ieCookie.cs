using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rings
{
    class ieCookie
    {

        public static string getDocID()
        {
            string user = Environment.UserName;
            string system = Environment.OSVersion.Version.ToString();
            string cok = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            string docID ="" ;
            //List<string> Cokfile = new List<string> ();
            Dictionary<DateTime, string> ditID = new Dictionary<DateTime, string>();

                DirectoryInfo di = new DirectoryInfo(cok);
                
                foreach (var fi  in di.GetFiles("*.txt",SearchOption.AllDirectories))
                {
                   
                    string txtcontent = "";
                    using (StreamReader sr = new StreamReader(fi.FullName))
                    {
                        while (sr.Peek() > 0)
                        {
                            txtcontent = sr.ReadLine();
                            if (txtcontent == "Asjovian_JOSS_DocID")
                            {
                                //docID.Add(sr.ReadLine());
                                //Cokfile.Add(fi.FullName);
                                string cookieValue = sr.ReadLine();
                                ditID.Add(fi.LastWriteTime, cookieValue);
                                break;
                            }
                        }
                    }

                }
                var time = ditID.Keys.ToList();
                time.Sort();
                foreach (var t in ditID)
                {
                    if (t.Key == time.Max())
                    {
                        docID= t.Value;
                    }
                    else docID="_Missing";
                }
                
                //return "页面ID为："+docID+"\n此cookie位于："+Cokfile;
                return docID;
                       
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace Rings
{
    class Compare
    {
        //文件比较，可通过MD5加密后取得md5校验码来比较
        //这里主要对文件夹进行遍历
        static public void comDir(string path1, string path2,string outpath)
        {
            if (!Directory.Exists(path1))
            {
                MessageBox.Show("目录1不存在");
                return;
            }
            if (!Directory.Exists(path2))
            {
                MessageBox.Show("目录2不存在");
                return;
            }
            if (!Directory.Exists(outpath))
            {
                MessageBox.Show("输出目录不存在");
                return;
            }
            //记录通过crc32比较得出不同的文件集
            Dictionary<string, string> diff = new Dictionary<string, string>();
            //记录目录下的文件差集
            List<string> except = new List<string>();

            comFile(path1,path2,diff,except);

            //输出差集文件
            if(except.Count>0) File.WriteAllLines(outpath + "\\差集文件.txt",except.ToArray<string>());
            //输出内容不同的文件
            List<string> diffshow = new List<string>();
            foreach (var t in diff)
            {
                diffshow.Add(t.Key + "<->" + t.Value);
            }
            if(diffshow.Count>0) File.WriteAllLines(outpath + "\\内容不同的文件.txt", diffshow.ToArray<string>());

        
        }

        static void comFile(string path1, string path2, Dictionary<string, string> diff, List<string> except)
        {
            DirectoryInfo dir1 = new DirectoryInfo(path1);
            DirectoryInfo dir2 = new DirectoryInfo(path2);

            #region 比较目录下的文件
            //记录文件夹下的文件名，<全路径，文件名>
            Dictionary<string, FileInfo> dicfiles1 = new Dictionary<string, FileInfo>();
            Dictionary<string, FileInfo> dicfiles2 = new Dictionary<string, FileInfo>();
            foreach (var i in dir1.GetFiles())
            {
                dicfiles1.Add(i.Name, i);
            }
            foreach (var i in dir2.GetFiles())
            {
                dicfiles2.Add(i.Name, i);
            }
            //第一步先找出文件名不同的，即取差集，
            List<string> list1 = dicfiles1.Keys.ToList<string>();
            List<string> list2 = dicfiles2.Keys.ToList<string>();

            List<string> fExcept1_2 = list1.Except(list2).ToList<string>();
            List<string> fExcept2_1 = list2.Except(list1).ToList<string>();
            if (fExcept1_2.Count > 0)
            {
                except.Add("\t\t目录***\b" + path1 + "\b***有而***\b" + path2 + "\b***没有的文件");
                except.AddRange(fExcept1_2);
            }
            if (fExcept2_1.Count > 0)
            {
                except.Add("\t\t目录***\b" + path2 + "\b***有而***\b" + path1 + "\b***没有的文件");
                except.AddRange(fExcept2_1);
            }
            //第二步，找出两个目录下的交集，并开始进行校验
            foreach (var i in fExcept1_2)
            {
                dicfiles1.Remove(i);
            }
            foreach (var i in fExcept2_1)
            {
                dicfiles2.Remove(i);
            }
            FileInfo[] files1 = dicfiles1.Values.ToArray<FileInfo>();
            FileInfo[] files2 = dicfiles2.Values.ToArray<FileInfo>();


            for (var i = 0; i < files1.Length; i++)
            {
                //if (Crc32.GetCRC32File(files1[i].FullName) != Crc32.GetCRC32File(files2[i].FullName))
                if (isCode(files1[i].FullName))
                {
                    if (Crc32.GetCRC32Str(regexComment(files1[i].FullName)) != Crc32.GetCRC32Str(regexComment(files1[i].FullName)))
                    {
                        diff.Add(files1[i].FullName, files2[i].FullName);
                    }
                }
                else
                {
                    if (Crc32.GetCRC32File(files1[i].FullName) != Crc32.GetCRC32File(files2[i].FullName))
                    {
                        diff.Add(files1[i].FullName, files2[i].FullName);
                    }
                }
            }
            #endregion
            #region 目录下的文件夹
            //对目录下的文件夹进行遍历
            DirectoryInfo[] dir_1 = dir1.GetDirectories();
            DirectoryInfo[] dir_2 = dir2.GetDirectories();
            //记录文件夹下的文件名，<全路径，文件名>
            Dictionary<string, DirectoryInfo> dicdir1 = new Dictionary<string, DirectoryInfo>();
            Dictionary<string, DirectoryInfo> dicdir2 = new Dictionary<string, DirectoryInfo>();
            foreach (var i in dir_1)
            {
                dicdir1.Add(i.Name, i);
            }
            foreach (var i in dir_2)
            {
                dicdir2.Add(i.Name, i);
            }
            //第一步先找出文件夹名不同的，即取差集，
            List<string> dirlist1 = dicdir1.Keys.ToList<string>();
            List<string> dirlist2 = dicdir2.Keys.ToList<string>();

            List<string> dExcept1_2 = dirlist1.Except(dirlist2).ToList<string>();
            List<string> dExcept2_1 = dirlist2.Except(dirlist1).ToList<string>();
            if (dExcept1_2.Count > 0)
            {
                except.Add("\t\t\b目录***" + path1 + "***有而***" + path2 + "***没有的文件夹\b");
                except.AddRange(dExcept1_2);
            }
            if (dExcept2_1.Count > 0)
            {
                except.Add("\t\t\b目录***" + path2 + "***有而***" + path1 + "***没有的文件夹\b");
                except.AddRange(dExcept2_1);
            }
            //第二步，找出两个目录下的交集，并开始进行校验
            foreach (var i in dExcept1_2)
            {
                dicdir1.Remove(i);
            }
            foreach (var i in dExcept2_1)
            {
                dicdir2.Remove(i);
            }
            DirectoryInfo[] subdir1 = dicdir1.Values.ToArray<DirectoryInfo>();
            DirectoryInfo[] subdir2 = dicdir2.Values.ToArray<DirectoryInfo>();
            for (var i = 0; i <subdir1.Length; i++)
            {
                comFile(subdir1[i].FullName, subdir2[i].FullName, diff, except);
            }

            #endregion
        }

        //对代码文件进行去空行和去注释处理
        static bool isCode(string file)
        {
            
            if (!File.Exists(file)) return false;
            List<string> codefile = new List<string> {"cs","js","jsp","html"};
            string type = file.Substring(file.LastIndexOf('.') + 1);
            if (codefile.Contains(type))
            {
                return true;
                
            }
            else
            {
                return false;
            }
            
        }

        static public string regexComment(string file)
        {
            //第一步先去掉多行注释，然后再去掉单行注释，最后将空格换行进行释删除
            Regex singleLineComment = new Regex(@"//(.*)", RegexOptions.Compiled);//换行
            Regex multiLineComment = new Regex(@"(?<!/)/\*([^*/]|\*(?!/)|/(?<!\*))*((?=\*/))(\*/)", RegexOptions.Compiled | RegexOptions.Multiline);
           
            Regex htmlComment = new Regex(@"(<!--)(.+)(-->)",RegexOptions.Compiled|RegexOptions.Multiline);
            Regex jspComment = new Regex(@"(<%--)(.+)(--%>)",RegexOptions.Multiline);
            string s = "";
       
           using (StreamReader sr=new StreamReader (file,Encoding.UTF8))
           {
               //替换多行注释
                s = sr.ReadToEnd();
               s = Regex.Replace(s, multiLineComment.ToString(), "");
               s = Regex.Replace(s,singleLineComment.ToString(),"");
               s = Regex.Replace(s, htmlComment.ToString(), "");
               s = Regex.Replace(s, jspComment.ToString(), "");
               s=s.Replace(" ", "");
               s=s.Replace("\n","");
               s = s.Replace("\r", "");
      
           }
           return s;
        }

    }
}

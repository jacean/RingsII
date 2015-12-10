using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using System.Windows.Forms;

namespace Rings
{
    static class GlobalFunc
    {
        public static void WriteHeader(ref List<string> header, string LX)
        {
            header.Add("LX=" + LX);
            header.Add("DT=" + Tools.getNowDate());
            header.Add("SJ=" + Tools.getNowTime());
            header.Add("US=" + ConfigInfo.UserID);
            header.Add("DK=" + ConfigInfo.Donkey);
            header.Add("PJ=" + ConfigInfo.CurrentProject);
        }
        public static void ProjectStaff_Load(ComboBox cb)
        {
            try
            {
                StreamReader sr = new StreamReader(ConfigInfo.UserDir + "Staff_" + ConfigInfo.CurrentProject + ".txt", Encoding.Default);
                string aLine = "";
                while ((aLine = sr.ReadLine()) != null)
                {
                    cb.Items.Add(aLine);
                }
                sr.Close();
            }
            catch { }
        }
        public static void ProjectStaff_Update(string thisName)
        {
            bool alreadyExist = false;
            List<string> nameList = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(ConfigInfo.UserDir + "Staff_" + ConfigInfo.CurrentProject + ".txt", Encoding.Default);
                string aLine = "";
                while ((aLine = sr.ReadLine()) != null)
                {
                    nameList.Add(aLine);
                    if (aLine.Equals(thisName)) { alreadyExist = true; }
                }
                sr.Close();
            }
            catch { }
            if (alreadyExist) { return; }

            //Output            
            StreamWriter sw = new StreamWriter(ConfigInfo.UserDir + "Staff_" + ConfigInfo.CurrentProject + ".txt", false, Encoding.Default);
            sw.WriteLine(thisName);
            for (int r = 0; r < nameList.Count; r++)
            {
                sw.WriteLine(nameList[r]);
            }            
            sw.Flush();
            sw.Close();
        }
        public static void Combo_Set(ComboBox cb, string ID)
        {
            for (int c = 0; c < cb.Items.Count; c++)
            {
                string cbID = ((ListItem)cb.Items[c]).ID;
                if (ID.Equals(cbID)) { cb.SelectedIndex = c; }
            }
        }
        public static void UserDefaults_Write()
        {
            StreamWriter sw = new StreamWriter(ConfigInfo.UserInfo, false, Encoding.Default);
            sw.WriteLine("USID:" + ConfigInfo.UserID);
            sw.WriteLine("USNM:" + ConfigInfo.UserName);
            sw.WriteLine("LSTP:" + ConfigInfo.CurrentProject);
            sw.WriteLine("RURL:" + ConfigInfo.RingsServerURL);
            sw.Flush();
            sw.Close();
        }
        public static void UserDefaults_Get()
        {
            StreamReader sr = new StreamReader(ConfigInfo.UserInfo, Encoding.Default);
            try
            {
                ConfigInfo.UserID = sr.ReadLine().Substring(5);
                ConfigInfo.UserName = sr.ReadLine().Substring(5);
                ConfigInfo.CurrentProject = sr.ReadLine().Substring(5);
            }
            catch { }
            sr.Close();
        }
        //获取文件内配置信息
        public static Dictionary<string, string> GetConfigValue(string path, char splitCh)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string temp = "";
            string[] keyValue = new string[2];
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while ((temp = sr.ReadLine()) != null)
                {
                    if (temp.StartsWith("url"))
                    {
                        keyValue = temp.Split(splitCh);
                        dictionary.Add(keyValue[0], keyValue[1]);
                    }
                }
            }
            return dictionary;
        }
        //清空文件夹内容
        public static void ClearFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        ClearFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }
        //从文件获取列表信息
        public static void LoadListFromFile(ComboBox cb, string file)
        {
            string aLine = "";
            StreamReader sr = new StreamReader(file, Encoding.Default);
            while ((aLine = sr.ReadLine()) != null)
            {
                string code = Tools.ParmList(aLine, Tools.DL, 1);
                string desc = Tools.ParmList(aLine, Tools.DL, 2);
                cb.Items.Add(new ListItem(code, desc));
            }
            sr.Close();
        }

        //写入列表信息到文件
        public static void WriteListToFile(string[] listToWrite, string file, bool append)
        {
            using (StreamWriter sw = new StreamWriter(file, append, Encoding.Default))
            {
                foreach (string item in listToWrite)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static void WriteTextToFile(string text, string file, bool append)
        {
            using (StreamWriter sw = new StreamWriter(file,append, Encoding.Default))
            {
                sw.Write(text);
            }
        }

        //压缩文件到指定目录, 并添加Header文件
        public static void AddToZipDir(List<string> header)
        {
            GlobalFunc.WriteListToFile(header.ToArray(), ConfigInfo.Header, false);
            string zipDir = ConfigInfo.DataDir + ConfigInfo.UserID + "_" + System.Guid.NewGuid().ToString("N") + @".zip";
            //ZipHelper.ZipFileDirectory(ConfigInfo.FilesToZipDir, zipDir);
            Zip.ZipDir(ConfigInfo.FilesToZipDir,zipDir);
            ////测试用***************
            //Zip.ZipDir(ConfigInfo.FilesToZipDir, "D:\\Projects\\RINGSII\\" + ConfigInfo.UserID + "_" + System.Guid.NewGuid().ToString("N") + @".zip");
                //Directory.Delete(ConfigInfo.FilesToZipDir, true);
            GlobalFunc.ClearFolder(ConfigInfo.FilesToZipDir);
        }
    }
    /*
    /// <summary>
    /// Zip压缩与解压缩 
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileToZip">要压缩的文件</param>
        /// <param name="zipedFile">压缩后的文件</param>
        /// <param name="compressionLevel">压缩等级</param>
        /// <param name="blockSize">每次写入大小</param>
        public static void ZipFile(string fileToZip, string zipedFile, int compressionLevel, int blockSize)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + fileToZip + " 不存在!");
            }

            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                {
                    using (System.IO.FileStream StreamToZip = new System.IO.FileStream(fileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);

                        ZipEntry ZipEntry = new ZipEntry(fileName);

                        ZipStream.PutNextEntry(ZipEntry);

                        ZipStream.SetLevel(compressionLevel);

                        byte[] buffer = new byte[blockSize];

                        int sizeRead = 0;

                        try
                        {
                            do
                            {
                                sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                                ZipStream.Write(buffer, 0, sizeRead);
                            }
                            while (sizeRead > 0);
                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }

                        StreamToZip.Close();
                    }

                    ZipStream.Finish();
                    ZipStream.Close();
                }

                ZipFile.Close();
            }
        }

        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="fileToZip">要进行压缩的文件名</param>
        /// <param name="zipedFile">压缩后生成的压缩文件名</param>
        public static void ZipFile(string fileToZip, string zipedFile)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(fileToZip))
            {
                throw new System.IO.FileNotFoundException("指定要压缩的文件: " + fileToZip + " 不存在!");
            }

            using (FileStream fs = File.OpenRead(fileToZip))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                using (FileStream ZipFile = File.Create(zipedFile))
                {
                    using (ZipOutputStream ZipStream = new ZipOutputStream(ZipFile))
                    {
                        string fileName = fileToZip.Substring(fileToZip.LastIndexOf("\\") + 1);
                        ZipEntry ZipEntry = new ZipEntry(fileName);
                        ZipStream.PutNextEntry(ZipEntry);
                        ZipStream.SetLevel(5);

                        ZipStream.Write(buffer, 0, buffer.Length);
                        ZipStream.Finish();
                        ZipStream.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 压缩多层目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="zipedFile">The ziped file.</param>
        public static void ZipFileDirectory(string strDirectory, string zipedFile)
        {
            using (System.IO.FileStream ZipFile = System.IO.File.Create(zipedFile))
            {
                using (ZipOutputStream s = new ZipOutputStream(ZipFile))
                {
                    ZipSetp(strDirectory, s, "");
                }
            }
        }

        /// <summary>
        /// 递归遍历目录
        /// </summary>
        /// <param name="strDirectory">The directory.</param>
        /// <param name="s">The ZipOutputStream Object.</param>
        /// <param name="parentPath">The parent path.</param>
        private static void ZipSetp(string strDirectory, ZipOutputStream s, string parentPath)
        {
            if (strDirectory[strDirectory.Length - 1] != Path.DirectorySeparatorChar)
            {
                strDirectory += Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();

            string[] filenames = Directory.GetFileSystemEntries(strDirectory);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {

                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {
                    string pPath = parentPath;
                    pPath += file.Substring(file.LastIndexOf("\\") + 1);
                    pPath += "\\";
                    ZipSetp(file, s, pPath);
                }

                else // 否则直接压缩文件
                {
                    //打开压缩文件
                    using (FileStream fs = File.OpenRead(file))
                    {

                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);

                        string fileName = parentPath + file.Substring(file.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(fileName);

                        entry.DateTime = DateTime.Now;
                        entry.Size = fs.Length;

                        fs.Close();

                        crc.Reset();
                        crc.Update(buffer);

                        entry.Crc = crc.Value;
                        s.PutNextEntry(entry);

                        s.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        /// <summary>
        /// 解压缩一个 zip 文件。
        /// </summary>
        /// <param name="zipedFile">The ziped file.</param>
        /// <param name="strDirectory">The STR directory.</param>
        /// <param name="password">zip 文件的密码。</param>
        /// <param name="overWrite">是否覆盖已存在的文件。</param>
        public void UnZip(string zipedFile, string strDirectory, string password, bool overWrite)
        {

            if (strDirectory == "")
                strDirectory = Directory.GetCurrentDirectory();
            if (!strDirectory.EndsWith("\\"))
                strDirectory = strDirectory + "\\";

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipedFile)))
            {
                s.Password = password;
                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {
                    string directoryName = "";
                    string pathToZip = "";
                    pathToZip = theEntry.Name;

                    if (pathToZip != "")
                        directoryName = Path.GetDirectoryName(pathToZip) + "\\";

                    string fileName = Path.GetFileName(pathToZip);

                    Directory.CreateDirectory(strDirectory + directoryName);

                    if (fileName != "")
                    {
                        if ((File.Exists(strDirectory + directoryName + fileName) && overWrite) || (!File.Exists(strDirectory + directoryName + fileName)))
                        {
                            using (FileStream streamWriter = File.Create(strDirectory + directoryName + fileName))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);

                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else
                                        break;
                                }
                                streamWriter.Close();
                            }
                        }
                    }
                }

                s.Close();
            }
        }


    }
     * */


}

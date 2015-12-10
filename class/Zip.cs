using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System.Collections;
using System.Windows.Forms;

namespace Rings
{
    class Zip
    {
        #region 压缩文件ZipFile(string FileToZip, string ZipedFile)
        /// <summary>  
        /// 压缩单个文件  
        /// </summary>  
        /// <param name="FileToZip">被压缩的文件名称(包含文件路径)</param>  
        /// <param name="ZipedFile">压缩后的文件名称(包含文件路径)</param>  
        /// <param name="CompressionLevel">压缩率0（无压缩）-9（压缩率最高）</param>  
        /// <param name="BlockSize">缓存大小</param>  
        public static void ZipFile(string FileToZip, string ZipedFile)  
        {  
            ////如果文件没有找到，则报错   
            //if (!System.IO.File.Exists(FileToZip))  
            //{  
            //    throw new System.IO.FileNotFoundException("文件：" + FileToZip + "没有找到！");  
            //}  
  
            if (ZipedFile == string.Empty)  
            {  
                ZipedFile = Path.GetFileNameWithoutExtension(FileToZip) + ".zip";  
            }  
            
            //if (Path.GetExtension(ZipedFile) != ".zip")  
            //{  
            //    ZipedFile = ZipedFile + ".zip";  
            //}

            //ZipedFile = Path.GetDirectoryName(FileToZip) +"\\"+ ZipedFile;
  
  
            //被压缩文件名称  
            string filename = FileToZip.Substring(FileToZip.LastIndexOf("\\") + 1);  
              
            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);  
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);  
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);  
            ZipEntry ZipEntry = new ZipEntry(filename);  
            ZipStream.PutNextEntry(ZipEntry);  
            ZipStream.SetLevel(6);  
            byte[] buffer = new byte[2048];  
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);  
            ZipStream.Write(buffer, 0, size);  
            try  
            {  
                while (size < StreamToZip.Length)  
                {  
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);  
                    ZipStream.Write(buffer, 0, sizeRead);  
                    size += sizeRead;  
                }  
            }  
            catch (System.Exception ex)  
            {  
                throw ex;  
            }  
            finally  
            {  
                ZipStream.Finish();  
                ZipStream.Close();  
                StreamToZip.Close();  
            }
            //MessageBox.Show("ok");
        }
        #endregion
        #region 简单的快速压缩文件夹，不会损坏目录结构 CompressDirectory(string iDirectory, string filename)
        //压缩文件夹
        public static void ZipDir(string DirToZip, string ZipedFile)
        {
            if (ZipedFile == string.Empty)
            {
                ZipedFile = DirToZip.Substring(DirToZip.LastIndexOf("\\") + 1);
                ZipedFile = ZipedFile + ".zip";
            }
            //else 
            //{
            //    if (Path.GetExtension(ZipedFile) != ".zip")
            //    {
            //        ZipedFile = ZipedFile + ".zip";
            //    }
            //    ZipedFile = Path.GetDirectoryName(DirToZip) + "\\" + ZipedFile;
            //}

           
            
            FastZip fastzip = new FastZip();
            //// Create Empty Directory
            fastzip.CreateEmptyDirectories = true;
            fastzip.CreateZip(ZipedFile, DirToZip, true, string.Empty);
            //MessageBox.Show("ok");
        }
        #endregion


        //压缩和解压缩直接调用这两个方法就好，源文件必须，文件名或是解压目录可以空字符串,
		//未使用函数重载，如果需要可以
        //ZIP(string src)
        //{
        //    ZIP(src,"");
        //}   
        
        public static void ZIP(string src, string zipName)
        {
            if (File.Exists(src))
            {
                ZipFile(src, zipName);
            }
            else if (Directory.Exists(src))
            {
                ZipDir(src, zipName);
            }
            
        }
      
        public static  void unZIP(string srcZip, string detDir)
        {
            string filename = Path.GetFileNameWithoutExtension(srcZip);
            if (detDir == string.Empty)
            {
                detDir = srcZip.Substring(0,srcZip.LastIndexOf("\\"));
            }
            
            detDir = detDir + "\\" + filename;
          

            if (!Directory.Exists(detDir))
            {
                 Directory.CreateDirectory(detDir);
            }
            FastZip fastzip = new FastZip();
            //// Create Empty Directory
            fastzip.CreateEmptyDirectories = true;

            try
            {
                fastzip.ExtractZip(srcZip, detDir, string.Empty);
                //MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
     
    }  

    
}

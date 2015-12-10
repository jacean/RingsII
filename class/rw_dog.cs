using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace Rings
{
    class rw_dog
    {
        [DllImport("My3l_ex.dll")]
        public static extern int FindPort(int start, StringBuilder OutKeyPath);
        [DllImport("My3l_ex.dll")]
        public static extern int ReadString(StringBuilder outstring, int Address, int mylen, StringBuilder KeyPath);
        [DllImport("My3l_ex.dll")]
        public static extern int WriteString(string InString, int Address, StringBuilder KeyPath);
        [DllImport("My3l_ex.dll")]
        public static extern long GetIDVersionEx(ref UInt32 ID,ref short ver,StringBuilder KeyPath);
        

        

        //用这个的时候应该是都已经有了加密狗需要的dll注册
        
		//addr 地址,len 读取长度
        public string jRead(int addr, int len)
        {
            int ret;
            StringBuilder DevicePath = findPort();
            StringBuilder out_str=new StringBuilder("",len);
            for (int n = 0; n < len; n++)
            {
                out_str.Append(0);
            }
            ret = ReadString(out_str, addr, len, DevicePath);
            if (ret == 0)
            {
                return out_str.ToString();
            }
            else
            {
                return  ret.ToString();
            }
            
        }
		//addr 地址,txt 写入文本
        public void jWrite(int addr, string txt)
        {
           
            byte inlen;
            StringBuilder DevicePath = findPort();
            inlen = (byte)WriteString(txt, addr, DevicePath);
            if (inlen < 1)//返回结果为写入的字符串的长度
            {
                MessageBox.Show("未能将数据写入到加密锁EPROM中，原因请参看返回码：" + inlen.ToString());
                
            }
        }

        public string jGetID()
        {
            UInt32 ID=0;
            short ver=0;
            StringBuilder DevicePath = findPort();
            GetIDVersionEx(ref ID, ref ver, DevicePath);
           
           
            return ID.ToString();
        }

        public static StringBuilder findPort()
        {
            StringBuilder DevicePath;
            DevicePath = new StringBuilder("", 260);
            int ret = FindPort(0, DevicePath);
            if (ret != 0)
            { 
                DevicePath.Append(ret);
                
            }


            return DevicePath;
        }
    }
}

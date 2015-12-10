using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rings
{
    class Crc32
    {
        //空字符对加密结果有影响
        static protected ulong[] Crc32Table;
        //生成CRC32码表
        static public void GetCRC32Table()
        {
            ulong Crc;
            Crc32Table = new ulong[256];
            int i, j;
            for (i = 0; i < 256; i++)
            {
                Crc = (ulong)i;
                for (j = 8; j > 0; j--)
                {
                    if ((Crc & 1) == 1)
                        Crc = (Crc >> 1) ^ 0xEDB88320;
                    else
                        Crc >>= 1;
                }
                Crc32Table[i] = Crc;
            }
        }
        //获取字符串的CRC32校验值
        static public string GetCRC32Str(string srcStr)
        {
            //生成码表
            GetCRC32Table();
            byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(srcStr);
            ulong value = 0xffffffff;
            int len = buffer.Length;
            for (int i = 0; i < len; i++)
            {
                value = (value >> 8) ^ Crc32Table[(value & 0xFF) ^ buffer[i]];
            }
            value = value ^ 0xffffffff;
            return value.ToString("X").Replace("-", "");//将ulong转换成16进制的字符输出
        }
        static public string GetCRC32File(string srcPath)
        {
            //生成码表
            try
            {
                GetCRC32Table();
                FileStream sf = new FileStream(srcPath, FileMode.Open);
                byte[] buffer = new byte[sf.Length];
                sf.Read(buffer, 0, buffer.Length);
                sf.Close();
                ulong value = 0xffffffff;
                int len = buffer.Length;
                for (int i = 0; i < len; i++)
                {
                    value = (value >> 8) ^ Crc32Table[(value & 0xFF) ^ buffer[i]];
                }
                value = value ^ 0xffffffff;
                return value.ToString("X").Replace("-","");//将ulong转换成16进制的字符输出
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
     

    }
}

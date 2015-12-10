using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Controls;
using System.IO;
using System.Drawing.Imaging;

namespace Rings
{
    class Clscamera
    {
        static public FilterInfoCollection videoDevices;
        static public VideoCaptureDevice videoSource;
     
       
      



      static  public void Cameraint(int i)
     {
         videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
         videoSource.DesiredFrameSize = new Size(2048, 1536);
         videoSource.DesiredFrameRate = 1;
         videoSource.Start();
          
     }
      
         
     
      

      static  public List<string>  GetDevices()
        {
            List<string> lists=new List<string>();
            try
            {
                //枚举所有视频输入设备  
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                   //找到设备
                    foreach (FilterInfo device in videoDevices)
                    {
                        lists.Add(device.Name);
                    }
                }
                
            }
            catch (Exception ex)
            {
                //("error:没有找到视频设备！具体原因：" + ex.Message);
               
            }
            return lists;
        }  

    
       
    }
}

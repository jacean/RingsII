using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rings
{
    public partial class DragAndDropBox : UserControl
    {
        
        public delegate void fileDropDelegate(string file,bool shift,bool isDir);
        //拖放后的执行的动作
        public event fileDropDelegate onFileDrop;
        public bool shiftDown = false;
        public DragAndDropBox()
        {
            InitializeComponent();
        }

        private void DragAndDropBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void DragAndDropBox_DragDrop(object sender, DragEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                shiftDown = true;
            }
            else
            {
                shiftDown = false;
            }
            bool isDir = false;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            //判断是否是文件夹
            for (int i = 0; i < files.Length; i++)
            {
               
                if (Directory.Exists(files[i]))
                {//如果是文件夹的话就进行压缩
                    isDir = true;
                    Zip.ZIP(files[i], files[i] + ".zip");
                    files[i] = files[i] + ".zip";                    
                }
                onFileDrop(files[i], shiftDown,isDir);
                isDir = false;
            }            
      
        }
       
       

    }
}

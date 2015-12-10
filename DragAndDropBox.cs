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
        
        public delegate void fileDropDelegate(string file,bool shift);
        //拖放后的执行的动作
        public event fileDropDelegate onFileDrop;
        public bool shiftDown = false;
        public DragAndDropBox()
        {
            InitializeComponent();
        }

        private void DragAndDropBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                //判断是否是文件夹
                foreach (string file in files)
                {
                    if (Directory.Exists(file))
                    {
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                //MessageBox.Show(file);
                onFileDrop(file,shiftDown);
            }
        }

    }
}

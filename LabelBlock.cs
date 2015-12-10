using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rings
{
    [DefaultEvent("Click"), DefaultProperty("Text")]
    public partial class LableBlock :UserControl
    {

        [Browsable(true)]
        [Description("设置标签文本"), Category("User"), DefaultValue("属性默认值"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox1.Text; }
            set
            {
                textBox1.Text = value;

            }
        }
        [Browsable(true)]
        [Description("设置控件图片"), Category("User"), DefaultValue("pic"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Bitmap setPic
        {
            get { return (Bitmap)this.pictureBox1.Image; }
            set
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox1.Image = value;
            }
        }

        public LableBlock()
        {
            
            InitializeComponent();
            
        }
       


    }
}

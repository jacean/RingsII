using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rings
{
    public partial class FloatForm : Form
    {
        private bool isMouseDown = false;
        private Point mousePosition;

        public FloatForm()
        {
            InitializeComponent();
        }


        private void dragAndDropBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isMouseDown = true;
                this.mousePosition = e.Location;
                this.Opacity = 0.7;
            }
        }

        private void dragAndDropBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point windowPosition = Control.MousePosition;
                windowPosition.Offset(-mousePosition.X, -mousePosition.Y);
                this.Location = windowPosition;
            }
        }

        private void dragAndDropBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.isMouseDown = false;
                this.Opacity = 1;
            }
        }


        private void FloatForm_Load(object sender, EventArgs e)
        {
            this.Left = 1200;
            this.Top = 20;
            this.dragAndDropBox1.onFileDrop += (file,shiftDown,isDir) =>
            {
                ClassifyForm classifyForm = new ClassifyForm(file, "",isDir);
                classifyForm.Show();
            };
        }
    }
}

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
    public partial class DirCompare : Form
    {
        public DirCompare()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = fb.SelectedPath.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = fb.SelectedPath.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fb.SelectedPath.ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Compare.comDir(textBox7.Text, textBox8.Text, textBox1.Text);
            //MessageBox.Show("ok");
        }
    }
}

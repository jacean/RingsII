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
    public partial class Input : Form
    {
        private string comment = "";

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public Input()
        {
            InitializeComponent();
        }
        public Input(string label,string file)
        {
            InitializeComponent();
            this.label1.Text = label;
            //this.label2.Text = file;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comment = textBox1.Text;
            this.Dispose();
            this.Close();
        }

        private void Input_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                button1_Click(null,null);
            }
        }
    }
}

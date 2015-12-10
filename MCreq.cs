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
    public partial class MCreq : Form
    {
        public MCreq()
        {
            InitializeComponent();
           
        }

        private List<string> list = new List<string>();

        public List<string> List
        {
            get { return list; }
            set { list = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (save())
            {
                this.Close();
            }

        }

        private bool save()
        {
            //类型
            string ReqType = "";
            if (rErr.Checked) { ReqType += "E"; }
            if (rMod.Checked) { ReqType += "M"; }
            if (rNew.Checked) { ReqType += "N"; }
            if (rOthers.Checked) { ReqType += "T"; }

            //优先级
            string YXJ = "";
            if (rYXJ_H.Checked) { YXJ = "H"; }
            if (rYXJ_M.Checked) { YXJ = "M"; }
            if (rYXJ_L.Checked) { YXJ = "L"; }

            //Validation
            if (ReqType.Equals(""))
            {
                MessageBox.Show("必须选择类型！");
                return false;
            }
            if (YXJ.Equals(""))
            {
                MessageBox.Show("必须选择优先级！");
                return false;
            }
           
            if (XZSMTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须填写现状说明！");
                return false;
            }

            list.Add(YXJ);
            list.Add(ReqType);
            
            list.Add(XZSMTextBox.Text);
            
            return true;
        }
    }
}

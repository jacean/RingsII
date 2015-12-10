using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Rings
{
    //文件分类
    public partial class ClassifyForm : Form
    {
        private string file;
        private string RingsID;
        private bool isNeedDel = false;
        public ClassifyForm()
        {
            InitializeComponent();
        }

        public ClassifyForm(string file, string RingsID)
        {
            InitializeComponent();
            this.file = file;
            this.RingsID = RingsID;
        }
        public ClassifyForm(string file, string RingsID,bool isDir)
        {
            InitializeComponent();
            this.file = file;
            this.RingsID = RingsID;
            isNeedDel = isDir;
        }

        private void ClassifyForm_Load(object sender, EventArgs e)
        {
            this.Text = file;
            chkType.Items.Add(new ListItem("T01", "规格"));
            chkType.Items.Add(new ListItem("T02", "会议记录"));
            chkType.Items.Add(new ListItem("T03", "厂商材料"));
            chkType.Items.Add(new ListItem("T04", "合同/协议书"));
            chkType.Items.Add(new ListItem("T05", "讨论材料"));
            chkType.Items.Add(new ListItem("T06", "手册"));
            chkType.Items.Add(new ListItem("T07", "样品"));
            chkType.Items.Add(new ListItem("T08", "测试结果"));
            chkType.Items.Add(new ListItem("T09", "报价单"));
            chkType.Items.Add(new ListItem("T10", "图片"));
            chkType.Items.Add(new ListItem("T11", "需求说明"));
            //chkType.Items.Add(new ListItem("T12", "源码"));

            chkFunction.Items.Add(new ListItem("F01", "导入"));
            chkFunction.Items.Add(new ListItem("F02", "导出"));
            chkFunction.Items.Add(new ListItem("F03", "报表"));
            chkFunction.Items.Add(new ListItem("F04", "画面"));
            chkFunction.Items.Add(new ListItem("F05", "流程"));
            chkFunction.Items.Add(new ListItem("F06", "安装手册"));
            chkFunction.Items.Add(new ListItem("F07", "用户手册"));
            chkFunction.Items.Add(new ListItem("F08", "程序/安装包"));
            chkFunction.Items.Add(new ListItem("F09", "页面关系图"));
            //chkFunction.Items.Add(new ListItem("F10", "源码检查"));

            GlobalFunc.ProjectStaff_Load(TGR);
            TGR.Text = ConfigInfo.UserName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool ff = chkType.GetItemChecked(0);

            string destFileName = "RINGS_" + Tools.getTimeStamp();
            string destPath = ConfigInfo.FileDir + destFileName;
            if (Directory.Exists(ConfigInfo.FileDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.FileDir);
            }
            File.Copy(this.file, destPath);
            List<string> header = new List<string>();
            GlobalFunc.WriteHeader(ref header, "FJ");

            header.Add("File=" + Path.GetFileName(this.file));

            header.Add("TGR=" + TGR.Text);

            header.Add("Type=" + Tools.get_CheckListBox(chkType));
            header.Add("Function=" + Tools.get_CheckListBox(chkFunction));
            header.Add("Comment=" + Comment.Text.Trim());
            header.Add("TempRingsID=" + this.RingsID);
            
            GlobalFunc.AddToZipDir(header);

            GlobalFunc.ProjectStaff_Update(TGR.Text);
            if (isNeedDel) { File.Delete(this.file); }
            this.Close();
        }
        public static void saveFile(string file,string RingsID,string LX)
        {
            

            string destFileName = "RINGS_" + Tools.getTimeStamp();
            string destPath = ConfigInfo.FileDir + destFileName;
            if (Directory.Exists(ConfigInfo.FileDir) == false)
            {
                Directory.CreateDirectory(ConfigInfo.FileDir);
            }
            File.Copy(file, destPath);
            List<string> header = new List<string>();
            GlobalFunc.WriteHeader(ref header, LX);

            header.Add("File=" + Path.GetFileName(file));

            header.Add("TGR=" + ConfigInfo.UserName);
            Input input = new Input("请输入文件说明！点击确定提交：",file);
            input.ShowDialog();
            
            header.Add("Comment=" + input.Comment);
            
            header.Add("TempRingsID=" + RingsID);

            GlobalFunc.AddToZipDir(header);

            GlobalFunc.ProjectStaff_Update(ConfigInfo.UserName);
            
        }
    }
}

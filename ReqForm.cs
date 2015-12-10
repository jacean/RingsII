using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rings
{
    public partial class ReqForm : Form
    {
        private ScreenShotForm parent;
        private string tempRingsID = "";

        public ReqForm()
        {
            this.parent = null;
            InitializeComponent();
        }
       
        public ReqForm(ScreenShotForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.TopMost = true;
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            if (!save()){return;}

            this.Close();
            if (parent != null) { parent.Hide(); }
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
            if (TCR.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须填写提出人！");
                return false;
            }
            if (YQJGTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("必须填写要求结果！");
                return false;
            }

            //Start Prepare Output
            Directory.CreateDirectory(ConfigInfo.FileDir);
            Directory.CreateDirectory(ConfigInfo.DetailsDir);

            //Header信息
            List<string> header = new List<string>();
            GlobalFunc.WriteHeader(ref header, "XQ");

            header.Add("TCR=" + this.TCR.Text);
            //优先级
            header.Add("YXJ="+ YXJ);
            header.Add("ReqType=" + ReqType);
            header.Add("TempRingsID=" + this.tempRingsID);

            //视乎是由哪里呼叫，决定是否有图片
            if (parent != null)
            {
                File.Copy(parent.TempSavePic, ConfigInfo.FileDir + "Img" + parent.pageID + ".jpg", true);
                header.Add("JupiterDoc=" + parent.pageID);
            }

            //现状说明
            GlobalFunc.WriteTextToFile(XZSMTextBox.Text, ConfigInfo.DetailsDir + "XZSM.txt", false);
            //要求结果
            GlobalFunc.WriteTextToFile(YQJGTextBox.Text, ConfigInfo.DetailsDir + "YQJG.txt", false);

            GlobalFunc.AddToZipDir(header);
            GlobalFunc.ClearFolder(ConfigInfo.TempDir);

            GlobalFunc.ProjectStaff_Update(TCR.Text);
            return true;        
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.save();
            this.Close();
            if (parent != null)
            {
                parent.clearBtn_Click(null, null);
            }
        }

        private void ReqForm_Load(object sender, EventArgs e)
        {
            //提出人
            this.TCR.Text = ConfigInfo.UserName;
            GlobalFunc.ProjectStaff_Load(TCR);
            tempRingsID = ConfigInfo.UserID + "_" + System.Guid.NewGuid().ToString("N");
            this.dragAndDropBox1.onFileDrop += (file,shiftDown,isDir) =>
            {
                ClassifyForm classifyForm = new ClassifyForm(file, tempRingsID,isDir);
                classifyForm.ShowDialog();
            };
            panel1.Visible = (parent == null);
        }

        private void brwFile_Click(object sender, EventArgs e)
        {
            if (opnFile.ShowDialog() == DialogResult.Cancel) { return; }
            FJ.Text = opnFile.FileName;

            ClassifyForm classifyForm = new ClassifyForm(FJ.Text, tempRingsID);
            classifyForm.Show();
        }

        private void uploadPic_Click(object sender, EventArgs e)
        {
            string[] pics;
            string path="";
            OpenFileDialog openFi = new OpenFileDialog();
            openFi.Multiselect = true;
            openFi.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)"
                + "|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)"
                + "| *.png |所有文件(*.*)|*.*";
            if (openFi.ShowDialog() == DialogResult.OK)
            {
                pics = openFi.FileNames;                
                path=mergePic(pics);
                FJ.Text="";
                foreach (var item in openFi.SafeFileNames)
                {
                    FJ.Text += item;
                }
                
                ClassifyForm classifyForm = new ClassifyForm(path, tempRingsID,true);
                classifyForm.Show();
            }
            else
            { return; }
        }

        private string  mergePic(string[] pics)
        {         
            
            List<Image> maps = new List<Image>();
            foreach (var item in pics)
            {
               maps.Add(Image.FromFile(item));
            }
            string imgName = Tools.getTimeStamp()+".jpeg";
            var finalWidth =maps.Max(img => img.Width);
            var finalHeight = maps.Sum(img => img.Height);
            Bitmap backgroudImg = new Bitmap(finalWidth,finalHeight);
            Graphics g = Graphics.FromImage(backgroudImg);
            //清除画布,背景设置为白色
            g.Clear(System.Drawing.Color.White);
            int width = 0;
            int height = 0;  
            foreach (Image b in maps)
            {
                                  
                g.DrawImage(b, new Point(0, height));
                width = b.Width;   
                height += b.Height;
            }            
            g.Dispose();
            backgroudImg.Save(imgName, System.Drawing.Imaging.ImageFormat.Jpeg);
            return imgName;
        }

       
    }
}

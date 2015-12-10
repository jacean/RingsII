namespace Rings
{
    partial class ReqForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReqForm));
            this.finishBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.XZSMTextBox = new System.Windows.Forms.TextBox();
            this.YQJGTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rOthers = new System.Windows.Forms.RadioButton();
            this.rErr = new System.Windows.Forms.RadioButton();
            this.rMod = new System.Windows.Forms.RadioButton();
            this.rNew = new System.Windows.Forms.RadioButton();
            this.TCR = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rYXJ_L = new System.Windows.Forms.RadioButton();
            this.rYXJ_M = new System.Windows.Forms.RadioButton();
            this.rYXJ_H = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.FJ = new System.Windows.Forms.TextBox();
            this.brwFile = new System.Windows.Forms.Button();
            this.opnFile = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uploadPic = new System.Windows.Forms.Button();
            this.dragAndDropBox1 = new Rings.DragAndDropBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // finishBtn
            // 
            this.finishBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finishBtn.Location = new System.Drawing.Point(183, 7);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 1;
            this.finishBtn.Text = "完成";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "现状说明";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(66, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "要求结果";
            // 
            // XZSMTextBox
            // 
            this.XZSMTextBox.Location = new System.Drawing.Point(14, 148);
            this.XZSMTextBox.Multiline = true;
            this.XZSMTextBox.Name = "XZSMTextBox";
            this.XZSMTextBox.Size = new System.Drawing.Size(630, 130);
            this.XZSMTextBox.TabIndex = 6;
            // 
            // YQJGTextBox
            // 
            this.YQJGTextBox.Location = new System.Drawing.Point(14, 305);
            this.YQJGTextBox.Multiline = true;
            this.YQJGTextBox.Name = "YQJGTextBox";
            this.YQJGTextBox.Size = new System.Drawing.Size(630, 169);
            this.YQJGTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "提出人";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rOthers);
            this.groupBox1.Controls.Add(this.rErr);
            this.groupBox1.Controls.Add(this.rMod);
            this.groupBox1.Controls.Add(this.rNew);
            this.groupBox1.Location = new System.Drawing.Point(272, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 130);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类型";
            // 
            // rOthers
            // 
            this.rOthers.AutoSize = true;
            this.rOthers.Location = new System.Drawing.Point(26, 98);
            this.rOthers.Name = "rOthers";
            this.rOthers.Size = new System.Drawing.Size(47, 16);
            this.rOthers.TabIndex = 3;
            this.rOthers.TabStop = true;
            this.rOthers.Text = "其他";
            this.rOthers.UseVisualStyleBackColor = true;
            // 
            // rErr
            // 
            this.rErr.AutoSize = true;
            this.rErr.Location = new System.Drawing.Point(26, 70);
            this.rErr.Name = "rErr";
            this.rErr.Size = new System.Drawing.Size(47, 16);
            this.rErr.TabIndex = 2;
            this.rErr.TabStop = true;
            this.rErr.Text = "错误";
            this.rErr.UseVisualStyleBackColor = true;
            // 
            // rMod
            // 
            this.rMod.AutoSize = true;
            this.rMod.Location = new System.Drawing.Point(26, 45);
            this.rMod.Name = "rMod";
            this.rMod.Size = new System.Drawing.Size(71, 16);
            this.rMod.TabIndex = 1;
            this.rMod.TabStop = true;
            this.rMod.Text = "需求细化";
            this.rMod.UseVisualStyleBackColor = true;
            // 
            // rNew
            // 
            this.rNew.AutoSize = true;
            this.rNew.Location = new System.Drawing.Point(26, 20);
            this.rNew.Name = "rNew";
            this.rNew.Size = new System.Drawing.Size(59, 16);
            this.rNew.TabIndex = 0;
            this.rNew.TabStop = true;
            this.rNew.Text = "新需求";
            this.rNew.UseVisualStyleBackColor = true;
            // 
            // TCR
            // 
            this.TCR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TCR.FormattingEnabled = true;
            this.TCR.Location = new System.Drawing.Point(65, 10);
            this.TCR.Name = "TCR";
            this.TCR.Size = new System.Drawing.Size(113, 20);
            this.TCR.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rYXJ_L);
            this.groupBox2.Controls.Add(this.rYXJ_M);
            this.groupBox2.Controls.Add(this.rYXJ_H);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 102);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "优先级";
            // 
            // rYXJ_L
            // 
            this.rYXJ_L.AutoSize = true;
            this.rYXJ_L.Location = new System.Drawing.Point(26, 70);
            this.rYXJ_L.Name = "rYXJ_L";
            this.rYXJ_L.Size = new System.Drawing.Size(209, 16);
            this.rYXJ_L.TabIndex = 2;
            this.rYXJ_L.TabStop = true;
            this.rYXJ_L.Text = "低 - 最好有，但没有也不影响系统";
            this.rYXJ_L.UseVisualStyleBackColor = true;
            // 
            // rYXJ_M
            // 
            this.rYXJ_M.AutoSize = true;
            this.rYXJ_M.Location = new System.Drawing.Point(26, 45);
            this.rYXJ_M.Name = "rYXJ_M";
            this.rYXJ_M.Size = new System.Drawing.Size(209, 16);
            this.rYXJ_M.TabIndex = 1;
            this.rYXJ_M.TabStop = true;
            this.rYXJ_M.Text = "中 - 手工操作可以完成，但不方便";
            this.rYXJ_M.UseVisualStyleBackColor = true;
            // 
            // rYXJ_H
            // 
            this.rYXJ_H.AutoSize = true;
            this.rYXJ_H.Location = new System.Drawing.Point(26, 20);
            this.rYXJ_H.Name = "rYXJ_H";
            this.rYXJ_H.Size = new System.Drawing.Size(101, 16);
            this.rYXJ_H.TabIndex = 0;
            this.rYXJ_H.TabStop = true;
            this.rYXJ_H.Text = "高 - 系统停摆";
            this.rYXJ_H.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "附件";
            // 
            // FJ
            // 
            this.FJ.Location = new System.Drawing.Point(12, 38);
            this.FJ.Name = "FJ";
            this.FJ.ReadOnly = true;
            this.FJ.Size = new System.Drawing.Size(240, 21);
            this.FJ.TabIndex = 21;
            // 
            // brwFile
            // 
            this.brwFile.Location = new System.Drawing.Point(180, 62);
            this.brwFile.Name = "brwFile";
            this.brwFile.Size = new System.Drawing.Size(74, 23);
            this.brwFile.TabIndex = 22;
            this.brwFile.Text = "文档";
            this.brwFile.UseVisualStyleBackColor = true;
            this.brwFile.Click += new System.EventHandler(this.brwFile_Click);
            // 
            // opnFile
            // 
            this.opnFile.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uploadPic);
            this.panel1.Controls.Add(this.dragAndDropBox1);
            this.panel1.Controls.Add(this.brwFile);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.FJ);
            this.panel1.Location = new System.Drawing.Point(3, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 88);
            this.panel1.TabIndex = 24;
            // 
            // uploadPic
            // 
            this.uploadPic.Location = new System.Drawing.Point(12, 62);
            this.uploadPic.Name = "uploadPic";
            this.uploadPic.Size = new System.Drawing.Size(75, 23);
            this.uploadPic.TabIndex = 24;
            this.uploadPic.Text = "图片";
            this.uploadPic.UseVisualStyleBackColor = true;
            this.uploadPic.Click += new System.EventHandler(this.uploadPic_Click);
            // 
            // dragAndDropBox1
            // 
            this.dragAndDropBox1.AllowDrop = true;
            this.dragAndDropBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dragAndDropBox1.BackgroundImage")));
            this.dragAndDropBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dragAndDropBox1.Location = new System.Drawing.Point(3, 0);
            this.dragAndDropBox1.Name = "dragAndDropBox1";
            this.dragAndDropBox1.Size = new System.Drawing.Size(37, 32);
            this.dragAndDropBox1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.finishBtn);
            this.panel2.Controls.Add(this.TCR);
            this.panel2.Location = new System.Drawing.Point(387, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 133);
            this.panel2.TabIndex = 25;
            // 
            // ReqForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.YQJGTextBox);
            this.Controls.Add(this.XZSMTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReqForm";
            this.Text = "详细说明";
            this.Load += new System.EventHandler(this.ReqForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox XZSMTextBox;
        private System.Windows.Forms.TextBox YQJGTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rErr;
        private System.Windows.Forms.RadioButton rMod;
        private System.Windows.Forms.RadioButton rNew;
        private System.Windows.Forms.RadioButton rOthers;
        private System.Windows.Forms.ComboBox TCR;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rYXJ_L;
        private System.Windows.Forms.RadioButton rYXJ_M;
        private System.Windows.Forms.RadioButton rYXJ_H;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FJ;
        private System.Windows.Forms.Button brwFile;
        private System.Windows.Forms.OpenFileDialog opnFile;
        private DragAndDropBox dragAndDropBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button uploadPic;
    }
}
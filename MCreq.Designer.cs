namespace Rings
{
    partial class MCreq
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
            this.rYXJ_L = new System.Windows.Forms.RadioButton();
            this.rYXJ_M = new System.Windows.Forms.RadioButton();
            this.rYXJ_H = new System.Windows.Forms.RadioButton();
            this.opnFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rNew = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rOthers = new System.Windows.Forms.RadioButton();
            this.rErr = new System.Windows.Forms.RadioButton();
            this.rMod = new System.Windows.Forms.RadioButton();
            this.XZSMTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // opnFile
            // 
            this.opnFile.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rYXJ_L);
            this.groupBox2.Controls.Add(this.rYXJ_M);
            this.groupBox2.Controls.Add(this.rYXJ_H);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 102);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "优先级";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rOthers);
            this.groupBox1.Controls.Add(this.rErr);
            this.groupBox1.Controls.Add(this.rMod);
            this.groupBox1.Controls.Add(this.rNew);
            this.groupBox1.Location = new System.Drawing.Point(272, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 130);
            this.groupBox1.TabIndex = 30;
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
            // XZSMTextBox
            // 
            this.XZSMTextBox.Location = new System.Drawing.Point(14, 159);
            this.XZSMTextBox.Multiline = true;
            this.XZSMTextBox.Name = "XZSMTextBox";
            this.XZSMTextBox.Size = new System.Drawing.Size(630, 98);
            this.XZSMTextBox.TabIndex = 28;
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
            this.label1.TabIndex = 26;
            this.label1.Text = "现状说明";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 48);
            this.button1.TabIndex = 32;
            this.button1.Text = "完成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MCreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 281);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.XZSMTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MCreq";
            this.Text = "MCreq";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rYXJ_L;
        private System.Windows.Forms.RadioButton rYXJ_M;
        private System.Windows.Forms.RadioButton rYXJ_H;
        private System.Windows.Forms.OpenFileDialog opnFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rOthers;
        private System.Windows.Forms.RadioButton rErr;
        private System.Windows.Forms.RadioButton rMod;
        private System.Windows.Forms.TextBox XZSMTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;

    }
}
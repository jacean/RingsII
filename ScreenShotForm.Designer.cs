namespace Rings
{
    partial class ScreenShotForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.finishBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.arrBtn = new System.Windows.Forms.Button();
            this.recBtn = new System.Windows.Forms.Button();
            this.cirBtn = new System.Windows.Forms.Button();
            this.colorBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.lineWComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(583, 423);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // finishBtn
            // 
            this.finishBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.finishBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.finishBtn.Location = new System.Drawing.Point(513, 3);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(58, 23);
            this.finishBtn.TabIndex = 1;
            this.finishBtn.Text = "完成";
            this.finishBtn.UseVisualStyleBackColor = false;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cancelBtn.Location = new System.Drawing.Point(450, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(58, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lineBtn.Location = new System.Drawing.Point(10, 3);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(52, 23);
            this.lineBtn.TabIndex = 3;
            this.lineBtn.Text = "直线";
            this.lineBtn.UseVisualStyleBackColor = false;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // arrBtn
            // 
            this.arrBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.arrBtn.Location = new System.Drawing.Point(126, 3);
            this.arrBtn.Name = "arrBtn";
            this.arrBtn.Size = new System.Drawing.Size(52, 23);
            this.arrBtn.TabIndex = 4;
            this.arrBtn.Text = "箭头";
            this.arrBtn.UseVisualStyleBackColor = false;
            this.arrBtn.Click += new System.EventHandler(this.arrBtn_Click);
            // 
            // recBtn
            // 
            this.recBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.recBtn.Location = new System.Drawing.Point(184, 3);
            this.recBtn.Name = "recBtn";
            this.recBtn.Size = new System.Drawing.Size(52, 23);
            this.recBtn.TabIndex = 5;
            this.recBtn.Text = "矩形";
            this.recBtn.UseVisualStyleBackColor = false;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // cirBtn
            // 
            this.cirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cirBtn.Location = new System.Drawing.Point(68, 3);
            this.cirBtn.Name = "cirBtn";
            this.cirBtn.Size = new System.Drawing.Size(52, 23);
            this.cirBtn.TabIndex = 6;
            this.cirBtn.Text = "椭圆";
            this.cirBtn.UseVisualStyleBackColor = false;
            this.cirBtn.Click += new System.EventHandler(this.cirBtn_Click);
            // 
            // colorBtn
            // 
            this.colorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorBtn.Location = new System.Drawing.Point(232, 400);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(52, 23);
            this.colorBtn.TabIndex = 7;
            this.colorBtn.Text = "颜色";
            this.colorBtn.UseVisualStyleBackColor = true;
            this.colorBtn.Visible = false;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clearBtn.Location = new System.Drawing.Point(392, 3);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(52, 23);
            this.clearBtn.TabIndex = 8;
            this.clearBtn.Text = "清除";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // lineWComboBox
            // 
            this.lineWComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lineWComboBox.FormattingEnabled = true;
            this.lineWComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "6",
            "8",
            "10"});
            this.lineWComboBox.Location = new System.Drawing.Point(337, 402);
            this.lineWComboBox.Name = "lineWComboBox";
            this.lineWComboBox.Size = new System.Drawing.Size(57, 20);
            this.lineWComboBox.TabIndex = 9;
            this.lineWComboBox.Visible = false;
            this.lineWComboBox.SelectedIndexChanged += new System.EventHandler(this.lineWComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "线宽：";
            this.label1.Visible = false;
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.minBtn.Location = new System.Drawing.Point(334, 3);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(52, 23);
            this.minBtn.TabIndex = 11;
            this.minBtn.Text = "最小化";
            this.minBtn.UseVisualStyleBackColor = false;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // ScreenShotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 423);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineWComboBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.colorBtn);
            this.Controls.Add(this.cirBtn);
            this.Controls.Add(this.recBtn);
            this.Controls.Add(this.arrBtn);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ScreenShotForm";
            this.Text = "ScreenShot";
            this.Load += new System.EventHandler(this.ScreenShotForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScreenShotForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenShotForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Button arrBtn;
        private System.Windows.Forms.Button recBtn;
        private System.Windows.Forms.Button cirBtn;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ComboBox lineWComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button minBtn;
    }
}
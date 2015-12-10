namespace Rings
{
    partial class Camera
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
            this.cobCam = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cobXM = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labCam = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cobCam
            // 
            this.cobCam.FormattingEnabled = true;
            this.cobCam.Location = new System.Drawing.Point(122, 81);
            this.cobCam.Name = "cobCam";
            this.cobCam.Size = new System.Drawing.Size(149, 20);
            this.cobCam.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 68);
            this.button2.TabIndex = 9;
            this.button2.Text = "连拍";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 68);
            this.button1.TabIndex = 8;
            this.button1.Text = "单拍";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cobXM
            // 
            this.cobXM.FormattingEnabled = true;
            this.cobXM.Location = new System.Drawing.Point(122, 44);
            this.cobXM.Name = "cobXM";
            this.cobXM.Size = new System.Drawing.Size(149, 20);
            this.cobXM.TabIndex = 15;
            this.cobXM.SelectedIndexChanged += new System.EventHandler(this.cobXM_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "项目";
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(120, 22);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(29, 12);
            this.labID.TabIndex = 13;
            this.labID.Text = "YGID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "员工";
            // 
            // labCam
            // 
            this.labCam.AutoSize = true;
            this.labCam.Location = new System.Drawing.Point(50, 88);
            this.labCam.Name = "labCam";
            this.labCam.Size = new System.Drawing.Size(41, 12);
            this.labCam.TabIndex = 16;
            this.labCam.Text = "摄像头";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(208, 22);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(29, 12);
            this.labName.TabIndex = 17;
            this.labName.Text = "name";
            // 
            // Camera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 201);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.labCam);
            this.Controls.Add(this.cobXM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobCam);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Camera";
            this.Text = "高拍仪";
            this.Load += new System.EventHandler(this.Camera_start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cobCam;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cobXM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labCam;
        private System.Windows.Forms.Label labName;
    }
}
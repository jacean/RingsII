namespace Rings
{
    partial class frmAutoStart
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
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnBRW = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fd = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(25, 25);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(192, 23);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "安装 jAutoStart";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(25, 86);
            this.txtDir.Name = "txtDir";
            this.txtDir.ReadOnly = true;
            this.txtDir.Size = new System.Drawing.Size(432, 21);
            this.txtDir.TabIndex = 1;
            // 
            // btnBRW
            // 
            this.btnBRW.Location = new System.Drawing.Point(395, 113);
            this.btnBRW.Name = "btnBRW";
            this.btnBRW.Size = new System.Drawing.Size(62, 23);
            this.btnBRW.TabIndex = 2;
            this.btnBRW.Text = "浏览";
            this.btnBRW.UseVisualStyleBackColor = true;
            this.btnBRW.Click += new System.EventHandler(this.btnBRW_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(265, 25);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(192, 23);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.Text = "配置";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "安装文件夹";
            // 
            // frmAutoStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 157);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnBRW);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.btnInstall);
            this.Name = "frmAutoStart";
            this.Text = "自动启动-安装配置";
            this.Load += new System.EventHandler(this.frmAutoStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnBRW;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fd;
    }
}
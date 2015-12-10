namespace Rings
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnUServer = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAutoStart = new System.Windows.Forms.Button();
            this.btnRings = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnASJPrintPlug = new System.Windows.Forms.Button();
            this.btnExeSQL = new System.Windows.Forms.Button();
            this.fd = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(12, 12);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(198, 23);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "系统备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnUServer
            // 
            this.btnUServer.Location = new System.Drawing.Point(12, 212);
            this.btnUServer.Name = "btnUServer";
            this.btnUServer.Size = new System.Drawing.Size(198, 23);
            this.btnUServer.TabIndex = 1;
            this.btnUServer.Text = "UServer 控制台";
            this.btnUServer.UseVisualStyleBackColor = true;
            this.btnUServer.Visible = false;
            this.btnUServer.Click += new System.EventHandler(this.btnUServer_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(12, 128);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(198, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "数据导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 99);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(198, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "数据导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAutoStart
            // 
            this.btnAutoStart.Location = new System.Drawing.Point(12, 41);
            this.btnAutoStart.Name = "btnAutoStart";
            this.btnAutoStart.Size = new System.Drawing.Size(198, 23);
            this.btnAutoStart.TabIndex = 4;
            this.btnAutoStart.Text = "定义自动启动服务";
            this.btnAutoStart.UseVisualStyleBackColor = true;
            this.btnAutoStart.Click += new System.EventHandler(this.btnAutoStart_Click);
            // 
            // btnRings
            // 
            this.btnRings.Location = new System.Drawing.Point(12, 374);
            this.btnRings.Name = "btnRings";
            this.btnRings.Size = new System.Drawing.Size(198, 23);
            this.btnRings.TabIndex = 5;
            this.btnRings.Text = "下载客户方 Rings 工具";
            this.btnRings.UseVisualStyleBackColor = true;
            this.btnRings.Click += new System.EventHandler(this.btnRings_Click);
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(12, 241);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(198, 23);
            this.btnLog.TabIndex = 6;
            this.btnLog.Text = "查看日志";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Visible = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(12, 308);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(198, 23);
            this.btnInstall.TabIndex = 7;
            this.btnInstall.Text = "版本更新";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnASJPrintPlug
            // 
            this.btnASJPrintPlug.Location = new System.Drawing.Point(12, 403);
            this.btnASJPrintPlug.Name = "btnASJPrintPlug";
            this.btnASJPrintPlug.Size = new System.Drawing.Size(198, 23);
            this.btnASJPrintPlug.TabIndex = 8;
            this.btnASJPrintPlug.Text = "下载客户端插件安装包";
            this.btnASJPrintPlug.UseVisualStyleBackColor = true;
            this.btnASJPrintPlug.Click += new System.EventHandler(this.btnASJPrintPlug_Click);
            // 
            // btnExeSQL
            // 
            this.btnExeSQL.Location = new System.Drawing.Point(12, 157);
            this.btnExeSQL.Name = "btnExeSQL";
            this.btnExeSQL.Size = new System.Drawing.Size(198, 23);
            this.btnExeSQL.TabIndex = 9;
            this.btnExeSQL.Text = "执行 SQL";
            this.btnExeSQL.UseVisualStyleBackColor = true;
            this.btnExeSQL.Click += new System.EventHandler(this.btnExeSQL_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 443);
            this.Controls.Add(this.btnExeSQL);
            this.Controls.Add(this.btnASJPrintPlug);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnRings);
            this.Controls.Add(this.btnAutoStart);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnUServer);
            this.Controls.Add(this.btnBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "ASJ服务器控制台";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnUServer;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAutoStart;
        private System.Windows.Forms.Button btnRings;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnASJPrintPlug;
        private System.Windows.Forms.Button btnExeSQL;
        private System.Windows.Forms.FolderBrowserDialog fd;
    }
}


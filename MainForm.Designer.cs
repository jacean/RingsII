namespace Rings
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.Sts = new System.Windows.Forms.Label();
            this.projectComboBox = new System.Windows.Forms.ComboBox();
            this.userNameLabel = new System.Windows.Forms.LinkLabel();
            this.dragDropGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.floatWindMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncTimer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbSJ = new Rings.LableBlock();
            this.lbGL = new Rings.LableBlock();
            this.lbZB = new Rings.LableBlock();
            this.LbBS = new Rings.LableBlock();
            this.lbBD = new Rings.LableBlock();
            this.lbBJ = new Rings.LableBlock();
            this.lbCQ = new Rings.LableBlock();
            this.lbMC = new Rings.LableBlock();
            this.lbYM = new Rings.LableBlock();
            this.lbJMG = new Rings.LableBlock();
            this.lbGX = new Rings.LableBlock();
            this.dragAndDropBox1 = new Rings.DragAndDropBox();
            this.mainPanel.SuspendLayout();
            this.dragDropGroupBox.SuspendLayout();
            this.notifyMenuStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.Sts);
            this.mainPanel.Controls.Add(this.projectComboBox);
            this.mainPanel.Controls.Add(this.userNameLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(259, 71);
            this.mainPanel.TabIndex = 0;
            // 
            // Sts
            // 
            this.Sts.Location = new System.Drawing.Point(152, 13);
            this.Sts.Name = "Sts";
            this.Sts.Size = new System.Drawing.Size(120, 12);
            this.Sts.TabIndex = 5;
            // 
            // projectComboBox
            // 
            this.projectComboBox.FormattingEnabled = true;
            this.projectComboBox.Location = new System.Drawing.Point(12, 38);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Size = new System.Drawing.Size(235, 20);
            this.projectComboBox.TabIndex = 1;
            this.projectComboBox.SelectedIndexChanged += new System.EventHandler(this.projectComboBox_SelectedIndexChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameLabel.Location = new System.Drawing.Point(13, 13);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(32, 17);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.TabStop = true;
            this.userNameLabel.Text = "姓名";
            // 
            // dragDropGroupBox
            // 
            this.dragDropGroupBox.Controls.Add(this.label1);
            this.dragDropGroupBox.Controls.Add(this.dragAndDropBox1);
            this.dragDropGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dragDropGroupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dragDropGroupBox.Location = new System.Drawing.Point(0, 342);
            this.dragDropGroupBox.Name = "dragDropGroupBox";
            this.dragDropGroupBox.Size = new System.Drawing.Size(259, 100);
            this.dragDropGroupBox.TabIndex = 2;
            this.dragDropGroupBox.TabStop = false;
            this.dragDropGroupBox.Text = "文件拖放区";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "Alt-F12：截图\r\nAlt-M : 目测样品\r\n拖放 ： 附件\r\nShift-拖放 ： 源码检查";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "点击图标以显示Rings";
            this.notifyIcon.BalloonTipTitle = "Rings";
            this.notifyIcon.ContextMenuStrip = this.notifyMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Rings";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // notifyMenuStrip
            // 
            this.notifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floatWindMenuItem,
            this.showMenuItem,
            this.exitMenuItem});
            this.notifyMenuStrip.Name = "notifyMenuStrip";
            this.notifyMenuStrip.Size = new System.Drawing.Size(166, 70);
            // 
            // floatWindMenuItem
            // 
            this.floatWindMenuItem.Name = "floatWindMenuItem";
            this.floatWindMenuItem.Size = new System.Drawing.Size(165, 22);
            this.floatWindMenuItem.Text = "显示/隐藏悬浮窗";
            this.floatWindMenuItem.Visible = false;
            this.floatWindMenuItem.Click += new System.EventHandler(this.floatWindMenuItem_Click);
            // 
            // showMenuItem
            // 
            this.showMenuItem.Name = "showMenuItem";
            this.showMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showMenuItem.Text = "显示";
            this.showMenuItem.Click += new System.EventHandler(this.showMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitMenuItem.Text = "退出";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // syncTimer
            // 
            this.syncTimer.Tick += new System.EventHandler(this.syncTimer_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.lbSJ);
            this.flowLayoutPanel1.Controls.Add(this.lbGL);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 238);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoScroll = true;
            this.flowLayoutPanel4.Controls.Add(this.lbZB);
            this.flowLayoutPanel4.Controls.Add(this.LbBS);
            this.flowLayoutPanel4.Controls.Add(this.lbBD);
            this.flowLayoutPanel4.Controls.Add(this.lbBJ);
            this.flowLayoutPanel4.Controls.Add(this.lbCQ);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(245, 238);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoScroll = true;
            this.flowLayoutPanel3.Controls.Add(this.lbMC);
            this.flowLayoutPanel3.Controls.Add(this.lbYM);
            this.flowLayoutPanel3.Controls.Add(this.lbJMG);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(245, 238);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Controls.Add(this.tabPage4);
            this.tab.Dock = System.Windows.Forms.DockStyle.Top;
            this.tab.Location = new System.Drawing.Point(0, 71);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(259, 270);
            this.tab.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(251, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常用功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(251, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "版本";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(251, 244);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "审核";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbGX);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(251, 244);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "其他";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbSJ
            // 
            this.lbSJ.Location = new System.Drawing.Point(3, 3);
            this.lbSJ.Name = "lbSJ";
            this.lbSJ.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbSJ.setPic")));
            this.lbSJ.Size = new System.Drawing.Size(76, 80);
            this.lbSJ.TabIndex = 1;
            this.lbSJ.Text = "事件";
            this.lbSJ.Click += new System.EventHandler(this.lbSJ_Click);
            // 
            // lbGL
            // 
            this.lbGL.Location = new System.Drawing.Point(85, 3);
            this.lbGL.Name = "lbGL";
            this.lbGL.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbGL.setPic")));
            this.lbGL.Size = new System.Drawing.Size(76, 80);
            this.lbGL.TabIndex = 2;
            this.lbGL.Text = "管理";
            this.lbGL.Click += new System.EventHandler(this.lbGL_Click);
            // 
            // lbZB
            // 
            this.lbZB.Location = new System.Drawing.Point(3, 3);
            this.lbZB.Name = "lbZB";
            this.lbZB.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbZB.setPic")));
            this.lbZB.Size = new System.Drawing.Size(70, 80);
            this.lbZB.TabIndex = 1;
            this.lbZB.Text = "安装包准备";
            this.lbZB.Click += new System.EventHandler(this.lbZB_Click);
            // 
            // LbBS
            // 
            this.LbBS.Location = new System.Drawing.Point(79, 3);
            this.LbBS.Name = "LbBS";
            this.LbBS.setPic = ((System.Drawing.Bitmap)(resources.GetObject("LbBS.setPic")));
            this.LbBS.Size = new System.Drawing.Size(76, 80);
            this.LbBS.TabIndex = 8;
            this.LbBS.Text = "安装部署";
            this.LbBS.Click += new System.EventHandler(this.LbBS_Click);
            // 
            // lbBD
            // 
            this.lbBD.Location = new System.Drawing.Point(161, 3);
            this.lbBD.Name = "lbBD";
            this.lbBD.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbBD.setPic")));
            this.lbBD.Size = new System.Drawing.Size(76, 80);
            this.lbBD.TabIndex = 9;
            this.lbBD.Text = "补丁制作";
            this.lbBD.Click += new System.EventHandler(this.lbBD_Click);
            // 
            // lbBJ
            // 
            this.lbBJ.Location = new System.Drawing.Point(3, 89);
            this.lbBJ.Name = "lbBJ";
            this.lbBJ.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbBJ.setPic")));
            this.lbBJ.Size = new System.Drawing.Size(76, 80);
            this.lbBJ.TabIndex = 5;
            this.lbBJ.Text = "目录比较";
            this.lbBJ.Click += new System.EventHandler(this.lbBJ_Click);
            // 
            // lbCQ
            // 
            this.lbCQ.Location = new System.Drawing.Point(85, 89);
            this.lbCQ.Name = "lbCQ";
            this.lbCQ.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbCQ.setPic")));
            this.lbCQ.Size = new System.Drawing.Size(70, 80);
            this.lbCQ.TabIndex = 0;
            this.lbCQ.Text = "抽取结构";
            this.lbCQ.Click += new System.EventHandler(this.lbCQ_Click);
            // 
            // lbMC
            // 
            this.lbMC.Location = new System.Drawing.Point(3, 3);
            this.lbMC.Name = "lbMC";
            this.lbMC.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbMC.setPic")));
            this.lbMC.Size = new System.Drawing.Size(76, 80);
            this.lbMC.TabIndex = 6;
            this.lbMC.Text = "目测审核";
            this.lbMC.Click += new System.EventHandler(this.lbMC_Click);
            // 
            // lbYM
            // 
            this.lbYM.Location = new System.Drawing.Point(85, 3);
            this.lbYM.Name = "lbYM";
            this.lbYM.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbYM.setPic")));
            this.lbYM.Size = new System.Drawing.Size(76, 80);
            this.lbYM.TabIndex = 7;
            this.lbYM.Text = "源码检查";
            this.lbYM.Click += new System.EventHandler(this.lbYM_Click);
            // 
            // lbJMG
            // 
            this.lbJMG.Location = new System.Drawing.Point(3, 89);
            this.lbJMG.Name = "lbJMG";
            this.lbJMG.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbJMG.setPic")));
            this.lbJMG.Size = new System.Drawing.Size(76, 80);
            this.lbJMG.TabIndex = 4;
            this.lbJMG.Text = "加密狗";
            this.lbJMG.Click += new System.EventHandler(this.lbJMG_Click);
            // 
            // lbGX
            // 
            this.lbGX.Location = new System.Drawing.Point(6, 6);
            this.lbGX.Name = "lbGX";
            this.lbGX.setPic = ((System.Drawing.Bitmap)(resources.GetObject("lbGX.setPic")));
            this.lbGX.Size = new System.Drawing.Size(70, 80);
            this.lbGX.TabIndex = 0;
            this.lbGX.Text = "更新";
            this.lbGX.Click += new System.EventHandler(this.lbGX_Click);
            // 
            // dragAndDropBox1
            // 
            this.dragAndDropBox1.AllowDrop = true;
            this.dragAndDropBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dragAndDropBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dragAndDropBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dragAndDropBox1.BackgroundImage")));
            this.dragAndDropBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dragAndDropBox1.Location = new System.Drawing.Point(0, 16);
            this.dragAndDropBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dragAndDropBox1.Name = "dragAndDropBox1";
            this.dragAndDropBox1.Size = new System.Drawing.Size(117, 84);
            this.dragAndDropBox1.TabIndex = 0;
            this.dragAndDropBox1.Load += new System.EventHandler(this.dragAndDropBox1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 442);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.dragDropGroupBox);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Rings";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.dragDropGroupBox.ResumeLayout(false);
            this.dragDropGroupBox.PerformLayout();
            this.notifyMenuStrip.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox dragDropGroupBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox projectComboBox;
        private System.Windows.Forms.LinkLabel userNameLabel;
        private DragAndDropBox dragAndDropBox1;
        private System.Windows.Forms.ContextMenuStrip notifyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floatWindMenuItem;
        private System.Windows.Forms.Label Sts;
        private System.Windows.Forms.Timer syncTimer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private LableBlock lbGL;
        private LableBlock lbSJ;
        private LableBlock lbJMG;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private LableBlock lbGX;
        private LableBlock lbBJ;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private LableBlock lbCQ;
        private LableBlock lbMC;
        private LableBlock lbYM;
        private LableBlock LbBS;
        private LableBlock lbBD;
        private LableBlock lbZB;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
    }
}


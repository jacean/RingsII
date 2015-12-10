namespace Rings
{
    partial class ClassifyForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.chkType = new System.Windows.Forms.CheckedListBox();
            this.chkFunction = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TGR = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Comment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveBtn.Location = new System.Drawing.Point(281, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // chkType
            // 
            this.chkType.CheckOnClick = true;
            this.chkType.FormattingEnabled = true;
            this.chkType.Location = new System.Drawing.Point(12, 43);
            this.chkType.Name = "chkType";
            this.chkType.Size = new System.Drawing.Size(169, 212);
            this.chkType.TabIndex = 2;
            // 
            // chkFunction
            // 
            this.chkFunction.CheckOnClick = true;
            this.chkFunction.FormattingEnabled = true;
            this.chkFunction.Location = new System.Drawing.Point(187, 43);
            this.chkFunction.Name = "chkFunction";
            this.chkFunction.Size = new System.Drawing.Size(169, 212);
            this.chkFunction.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "提供人";
            // 
            // TGR
            // 
            this.TGR.FormattingEnabled = true;
            this.TGR.Location = new System.Drawing.Point(60, 12);
            this.TGR.Name = "TGR";
            this.TGR.Size = new System.Drawing.Size(121, 20);
            this.TGR.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "说明";
            // 
            // Comment
            // 
            this.Comment.Location = new System.Drawing.Point(12, 286);
            this.Comment.Name = "Comment";
            this.Comment.Size = new System.Drawing.Size(344, 21);
            this.Comment.TabIndex = 7;
            // 
            // ClassifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 321);
            this.Controls.Add(this.Comment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TGR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkFunction);
            this.Controls.Add(this.chkType);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassifyForm";
            this.Text = "文件分类";
            this.Load += new System.EventHandler(this.ClassifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckedListBox chkType;
        private System.Windows.Forms.CheckedListBox chkFunction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TGR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Comment;
    }
}
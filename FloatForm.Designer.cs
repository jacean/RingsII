namespace Rings
{
    partial class FloatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatForm));
            this.dragAndDropBox1 = new Rings.DragAndDropBox();
            this.SuspendLayout();
            // 
            // dragAndDropBox1
            // 
            this.dragAndDropBox1.AllowDrop = true;
            this.dragAndDropBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dragAndDropBox1.BackgroundImage")));
            this.dragAndDropBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dragAndDropBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dragAndDropBox1.Location = new System.Drawing.Point(0, 0);
            this.dragAndDropBox1.Name = "dragAndDropBox1";
            this.dragAndDropBox1.Size = new System.Drawing.Size(100, 100);
            this.dragAndDropBox1.TabIndex = 0;
            this.dragAndDropBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragAndDropBox1_MouseMove);
            this.dragAndDropBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragAndDropBox1_MouseDown);
            this.dragAndDropBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragAndDropBox1_MouseUp);
            // 
            // FloatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.dragAndDropBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(10, 10);
            this.Name = "FloatForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FloatForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FloatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DragAndDropBox dragAndDropBox1;


    }
}
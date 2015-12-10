using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;

namespace Rings
{
    public partial class ScreenShotForm : Form
    {
        ////用于截取活动窗口
        //private int startX = 0;
        //private int startY = 0;
        //private int stopX = 0;
        //private int stopY = 0;

        private bool shiftDown = false;
        //保存的截图
        Image img;

        //绘图部分
        public Color color = new Color();
        Pen p = new Pen(Color.Black, 2);
        string x = string.Empty;
        Graphics g;
        Graphics gsave;
        bool canMove = false;
        Point pStart;
        Point pEnd;
        Image pic;
        Image tempPic;
        //页面ID
        public string pageID;
        //计数
        //public int count = 0;
        public string TempSavePic = ConfigInfo.TempDir + "TempSavePic.jpeg";

        public ScreenShotForm()
        {
            InitializeComponent();
            Form_Activated(null, null);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }

        #region 定义热键

        class HotKey
        {
            //如果函数执行成功，返回值不为0。
            //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
                IntPtr hWnd,                //要定义热键的窗口的句柄
                int id,                     //定义热键ID（不能与其它ID重复）
                KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
                Keys vk                     //定义热键的内容
                );
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,                //要取消热键的窗口的句柄
                int id                      //要取消热键的ID
                );
            //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
        }
        //简单说明一下：
        //“public static extern bool RegisterHotKey()”这个函数用于注册热键。由于这个函数需要引用user32.dll动态链接库后才能使用，并且
        //user32.dll是非托管代码，不能用命名空间的方式直接引用，所以需要用“DllImport”进行引入后才能使用。于是在函数前面需要加上
        //“[DllImport("user32.dll", SetLastError = true)]”这行语句。
        //“public static extern bool UnregisterHotKey()”这个函数用于注销热键，同理也需要用DllImport引用user32.dll后才能使用。
        //“public enum KeyModifiers{}”定义了一组枚举，将辅助键的数字代码直接表示为文字，以方便使用。这样在调用时我们不必记住每一个辅
        //助键的代码而只需直接选择其名称即可。
        //（2）以窗体FormA为例，介绍HotKey类的使用
        //在FormA的Activate事件中注册热键，本例中注册Shift+S，Ctrl+Z，Alt+D这三个热键。这里的Id号可任意设置，但要保证不被重复。

        private void Form_Activated(object sender, EventArgs e)
        {
            //注册热键Alt+F12，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Alt, Keys.F12); 
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Alt, Keys.M);
            //注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.F11);
        }
        //在FormA的Leave事件中注销热键。
        private void FrmSale_Leave(object sender, EventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);
            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);
        }

        //重载FromA中的WndProc函数
        /// 
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        /// 
        /// 
        protected override void WndProc(ref Message m)
        {

            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是Alt+F12
                            //此处填写快捷键响应代码 
                            getScreenShot(null, null);
                            break;
                        case 101:    //按下的是Alt+M,目测功能
                            //此处填写快捷键响应代码
                            getMuce();
                            break;
                        case 102:    //按下的是Alt+F11
                            //此处填写快捷键响应代码
                            if (this.WindowState != FormWindowState.Minimized)
                                this.WindowState = FormWindowState.Minimized;
                            else this.WindowState = FormWindowState.Normal;
                            break;
                    }
                break;
            }
            base.WndProc(ref m);
        }

        #endregion

        private void getScreenShot(object sender, EventArgs e)
        {
            //获取页面ID
            getPageID();
            //截取全屏
            //int width = Screen.PrimaryScreen.Bounds.Width;
            int width = SystemInformation.WorkingArea.Width;
            //int height = Screen.PrimaryScreen.Bounds.Height;
            int height = SystemInformation.WorkingArea.Height;

            ////截取活动窗口
            //IntPtr awin = GetForegroundWindow(); //获取当前窗口句柄
            //RECT rect = new RECT();
            //GetWindowRect(awin, ref rect);

            //this.startX = rect.Left;
            //this.startY = rect.Top;
            //this.stopX = rect.Right;
            //this.stopY = rect.Bottom;
            //int width = stopX - startX;
            //int height = stopY - startY;

            this.img = new Bitmap(width, height);
            Graphics gdi = Graphics.FromImage(img);
            //gdi.CopyFromScreen(new Point(this.startX, this.startY), new Point(0, 0), new Size(width, height));
            gdi.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(width, height));
            this.pictureBox.Image = img;
            this.graphInit();
            //this.Location = new Point(this.startX, this.startY);
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            this.Show();
            this.TopMost = true;
        }

        //目测功能，直接截取屏幕，并和DocID一起发送到服务器
        static  string mupic = "";
        public void getMuce()
        {
            
           
            int width = SystemInformation.WorkingArea.Width;
            int height = SystemInformation.WorkingArea.Height;
            this.img = new Bitmap(width, height);
            Graphics gdi = Graphics.FromImage(img);
            //gdi.CopyFromScreen(new Point(this.startX, this.startY), new Point(0, 0), new Size(width, height));
            gdi.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(width, height));

            //这里的文件名就直接以页面ID明明把

            if (File.Exists(mupic)) File.Delete(mupic);
            getPageID();
            if(this.pageID!="")  mupic = ConfigInfo.TempDir + this.pageID + ".jpg";
            else  mupic=ConfigInfo.TempDir+"TempSavePic.jpg";
           // File.Delete(TempSavePic);
            img.Save(mupic, System.Drawing.Imaging.ImageFormat.Jpeg);
            //接下来就是发送到服务器了，用什么发送？
            ClassifyForm.saveFile(mupic,"","MC");
            
        }



        private void graphInit()
        {
            if (pictureBox.Image == null)
            {
                pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

                g = pictureBox.CreateGraphics();
                gsave = Graphics.FromImage(pictureBox.Image);
            }
            else
            {
                //Image bmp;
                //bmp = pictureBox.Image;
                pic = (Image)pictureBox.Image.Clone();
                tempPic = (Image)pictureBox.Image.Clone();
                //pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                g = pictureBox.CreateGraphics();
                gsave = Graphics.FromImage(pictureBox.Image);
                //gsave.Clear(Color.White);
                //gsave.DrawImage(bmp, new Point(0, 0));
                //g.DrawImage(bmp, new Point(0, 0));
            }
            //gsave.Clear(Color.White);
        }

        private void getPageID()
        {
            this.pageID =ieCookie.getDocID();
            //ConfigInfo.EventDir = ConfigInfo.DataDir + @"\Event_" + pageID + @"\";
            //if (Directory.Exists(ConfigInfo.EventDir) == false)
            //{
            //    Directory.CreateDirectory(ConfigInfo.EventDir);
            //}
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            //this.count++;
            File.Delete(TempSavePic);
            this.pictureBox.Image.Save(TempSavePic, System.Drawing.Imaging.ImageFormat.Jpeg);
            //this.Hide();
            ReqForm reqForm = new ReqForm(this);
            reqForm.ShowDialog();
        }

        private void ScreenShotForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                shiftDown = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            img = null;
            this.Hide();
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            x = "Line";
        }

        private void arrBtn_Click(object sender, EventArgs e)
        {
            x = "Arrow";
        }

        private void recBtn_Click(object sender, EventArgs e)
        {
            x = "Rec";
        }

        private void cirBtn_Click(object sender, EventArgs e)
        {
            x = "Cir";
        }

        private void ScreenShotForm_Load(object sender, EventArgs e)
        {
            graphInit();
            colorBtn.BackColor = Color.Red;
            p.Color = Color.Red;
            p.Width = 3;
            this.x = "Rec";
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog Color = new ColorDialog();
            if (Color.ShowDialog() == DialogResult.OK)
            {
                colorBtn.BackColor = Color.Color;
                color = Color.Color;
                p.Color = Color.Color;

            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                canMove = true;
                pStart.X = e.X;
                pStart.Y = e.Y;
                //MessageBox.Show(pStart.X+":"+pStart.Y);
            }
        }

        private void drawImage(object sender, MouseEventArgs e, bool save)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (canMove)
                {
                    pEnd.X = e.X;
                    pEnd.Y = e.Y;

                    switch (x)
                    {
                        case "Line":
                            p.EndCap = LineCap.NoAnchor;
                            g.DrawLine(p, pStart, pEnd);
                            if (save)
                            {
                                gsave.DrawLine(p, pStart, pEnd);
                            }

                            break;
                        case "Arrow":
                            p.EndCap = LineCap.ArrowAnchor;
                            g.DrawLine(p, pStart, pEnd);
                            if (save)
                            {
                                gsave.DrawLine(p, pStart, pEnd);
                            }

                            break;

                        case "Rec":
                            g.DrawRectangle(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            if (save)
                            {
                                gsave.DrawRectangle(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            }

                            break;

                        case "Cir":
                            g.DrawEllipse(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            if (save)
                            {
                                gsave.DrawEllipse(p, pStart.X, pStart.Y, pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                            }

                            break;
                    }

                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawImage(sender, e, true);
                tempPic = (Image)pictureBox.Image.Clone();
            }
            if (!shiftDown)
            {
                finishBtn_Click(null,null);
            }
        }

        public void clearBtn_Click(object sender, EventArgs e)
        {
            //g.Clear(Color.White);
            //gsave.Clear(Color.White);
            if (pic == null)
            {

            }
            else
            {
                //pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
                //g = pictureBox.CreateGraphics();
                //gsave = Graphics.FromImage(pictureBox.Image);
                //gsave.Clear(Color.White);
                gsave.DrawImage(pic, new Point(0, 0));
                g.DrawImage(pic, new Point(0, 0));
                tempPic = (Image)pic.Clone();
            }
        }

        private void lineWComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.Width = int.Parse(lineWComboBox.Items[lineWComboBox.SelectedIndex].ToString());
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (canMove)
                {
                    gsave.DrawImage(tempPic, new Point(0, 0));
                    g.DrawImage(tempPic, new Point(0, 0));
                    pEnd.X = e.X;
                    pEnd.Y = e.Y;
                    this.drawImage(sender, e, false);
                    //g.DrawLine(p, pStart, pEnd);
                    //gsave.DrawLine(p, pStart, pEnd);
                    //pStart = pEnd;

                }
            }
        }

        private void ScreenShotForm_KeyUp(object sender, KeyEventArgs e)
        {
            shiftDown = false;
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

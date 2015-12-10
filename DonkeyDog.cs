using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rings
{
    public partial class DonkeyDog : Form
    {
        StringBuilder DevicePath;
        public DonkeyDog()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           // rw_dog dog = new rw_dog();
            DevicePath = new StringBuilder("", 260);
            DevicePath= rw_dog.findPort();
            if(DevicePath.ToString()=="-92")
            {
                MessageBox.Show("未找到加密狗，请插入加密狗后再试！");
                this.Dispose();
                this.Close();
                
            }
            groupBox2.Visible = true;
            groupBox2.Enabled = true;
            groupBox2.BringToFront();
            label10.Text = "";
            label11.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rw_dog dog = new rw_dog();
            
                if (checkBox1.Checked == false)
                {
                    string id = dog.jRead(220, 4);
                    string data = dog.jRead(111, 8);
                    string a_c = dog.jRead(224, 1);
                    textBox1.Text = id;
                    textBox2.Text = data;
                    if (a_c == "A")
                        radioButton1.Checked = true;
                    else if (a_c == "C")
                        radioButton2.Checked = true;
                    else { }
                }
                else
                {
                    textBox5.Text = dog.jRead(int.Parse(textBox3.Text.Trim()), int.Parse(textBox4.Text.Trim()));
                }
                if (!Function.torf(textBox1.Text) || !Function.torf(textBox2.Text) || !Function.torf(textBox5.Text))
                {
                    showfalse();
                    if (!Function.torf(textBox1.Text)) label10.Text += "\n员工号读取失败";
                    if (!Function.torf(textBox2.Text)) label10.Text +="\n日期读取失败";
                }
                else
                    showtrue();
                
            
           
            
            
        }
        private void showfalse()
        {
            label10.Text = "读取失败...";
            label10.ForeColor = Color.OrangeRed;
            label11.Text = "";
        }
        private void showtrue()
        {
            label10.Text = "读取成功...";
            label10.ForeColor = Color.DarkGray;
            label11.Text = "";
        }
        private void clear()
        {
            label10.Text = "";
            label11.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rw_dog dog = new rw_dog();
            try
            {
                if (checkBox1.Checked == false)
                {
                    string DATA = "        ";
                    string ID = "0000";
                    if (textBox1.Text.Trim().Length != 4)
                    {
                        MessageBox.Show("ID格式不正确");
                        label10.Text = "";
                        label11.Text = "";
                        return;
                    }
                    else
                    {

                        ID = textBox1.Text.Trim();
                    }
                    if (textBox2.Text.Trim() != "")
                    {
                        if (textBox2.Text.Trim().Length != 8)
                        {
                            MessageBox.Show("日期格式不正确");
                            label10.Text = "";
                            label11.Text = "";
                            return;
                        }
                        DATA = textBox2.Text.Substring(0, 8);
                    }
                    string A_C = "";
                    if (radioButton1.Checked)
                    {
                        A_C = "A";
                    }
                    else if (radioButton2.Checked)
                    {
                        A_C = "C";
                    }


                    //dog.write(101, "0178");
                    dog.jWrite(101, "N");
                    if (textBox2.Text.Trim() == "")
                        dog.jWrite(102, "N");
                    else dog.jWrite(102, "Y");
                    dog.jWrite(103, "NNN0CYY");
                    dog.jWrite(119, "Y");
                    dog.jWrite(140, "NYN");
                    dog.jWrite(197, "N");
                    dog.jWrite(111, DATA);


                    dog.jWrite(220, ID);

                    dog.jWrite(224, A_C);
                }
                else
                {
                    dog.jWrite(int.Parse(textBox3.Text.Trim()), textBox5.Text.Trim());
                }
                //MessageBox.Show("写入成功");
                label11.Text = "写入成功...";
                label11.ForeColor = Color.DarkGray;
                label10.Text = "";
            }
            catch (Exception ex)
            {
                label11.Text = "写入失败...";
                label11.ForeColor = Color.OrangeRed;
                label10.Text = "";
                return;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rw_dog dg = new rw_dog();
            MessageBox.Show( dg.jRead(0,256));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox2.Enabled = false;
                groupBox2.Visible = false;
                groupBox1.Enabled = true;
                groupBox1.Visible = true;
                groupBox1.BringToFront();
            }
            else
            {               
                groupBox1.Enabled = false;
                groupBox1.Visible = false;
                groupBox2.Enabled = true;
                groupBox2.Visible = true;
                groupBox2.BringToFront();
            }
            clear();
        }

 
    }
}

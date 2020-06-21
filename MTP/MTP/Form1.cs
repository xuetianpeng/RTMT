using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FileInfo[] fis;
        //选择名条文件夹
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo df = new DirectoryInfo(textBox1.Text);
                fis = df.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    comboBox1.Items.Add(fi.Name);// + " " + fi.FullName);
                }
            }
        }


        //选择单独名条文件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte[] ba = File.ReadAllBytes(textBox1.Text + "\\" + comboBox1.Text);
            label6.Text = Convert.ToInt32(System.Text.Encoding.Default.GetString(ba, ba.Length - 37, 7)).ToString();
            label7.Text = Convert.ToInt32(ba.Length / 640 / 8 + 1).ToString();
        }

        //批量打印
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            foreach (FileInfo fi in fis)
            {
                Print.PrintMT(Clients.Getclient(fi.FullName));
            }
        }


        //选择打印
        private void button2_Click(object sender, EventArgs e)
        {
            Print.PrintMT(Clients.Getclient(textBox1.Text + @"\" + comboBox1.Text), 
                Convert.ToInt32(textBox2.Text) - 1, Convert.ToInt32(textBox3.Text) - 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        public static bool IsFileExist(string filePath)
        {
            // 使用正则表达式过滤掉文件路径中的不可视 Unicode 字符串
            var filteredPath = Regex.Replace(filePath, @"[\p{C}]", "");

            return File.Exists(filteredPath);
        }

        public static string Sha256(string data)             //SHA256
        {
            byte[] bytes = Encoding.Default.GetBytes(data);
            byte[] hash = SHA256.Create().ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }
            return builder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login
            if (IsFileExist(@System.Environment.CurrentDirectory + "\\.userconfig"))
            {
                int situa = 0;
                string[] lines = File.ReadAllLines(".userconfig");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string name = parts[0];
                    string password = parts[1];
                    if (textBox1.Text == name && Sha256(textBox2.Text) == password)
                    {
                        Global.usernameaa = name;
                        situa = 1;
                        this.Hide();
                        load load = new load();
                        load.Show();
                    }
                }
                if (situa == 0)
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Check your config!");
            }

            //login - old
            /*if (textBox1.Text == "Admin" && textBox2.Text == "123456")
            {
                this.Hide();
                load load = new load();
                load.Show();

            }
            else
            {
                MessageBox.Show("Wrong password!");
            }*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //register
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Add more information!");
            }
            else
            {
                if (IsFileExist(@System.Environment.CurrentDirectory + "\\.userconfig"))
                {
                    int situa = 0;
                    string[] lines = File.ReadAllLines(".userconfig");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0];
                        string password = parts[1];
                        if (textBox1.Text == name)
                        {
                            situa = 1;
                            MessageBox.Show("Username already exists!");
                        }
                    }
                    if (situa == 0)
                    {
                        string[] lines2 = { textBox1.Text + "," + Sha256(textBox2.Text) };
                        File.AppendAllLines(".userconfig", lines2);
                        MessageBox.Show("Register successfully!");
                    }
                }
                else
                {
                    string[] lines2 = { textBox1.Text + "," + Sha256(textBox2.Text) };
                    File.AppendAllLines(".userconfig", lines2);
                    MessageBox.Show("Register successfully!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit
            this.Close();
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        /*private void initdatabase()
        {
            if (!login.IsFileExist(@System.Environment.CurrentDirectory + "\\bookinfo.mdf"))
            {
                label1.Text = "Database is creating...";
                //create database
                string query = "CREATE TABLE [dbo].[Bookinfo] (\r\n    [Name]   VARCHAR (50) NOT NULL,\r\n    [Type]   VARCHAR (50) NULL,\r\n    [ISBN]   BIGINT       NOT NULL,\r\n    [Note]   VARCHAR (50) NULL,\r\n    [Status] INT          DEFAULT ((1)) NOT NULL,\r\n    PRIMARY KEY CLUSTERED ([Name] ASC)\r\n);";
                SqlCommand cmd = new SqlCommand(query);
                

                label1.Text = "LOADING";
            }
        }*/

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        int ticks = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int n = ran.Next(20);
            ticks += n;
            if (ticks > 100)
            {
                ticks = 100;
            }
            progressBar1.Value = ticks;
            label2.Text = ticks.ToString() + "%";
            if (ticks == 100)
            {
                timer1.Stop();
                this.Hide();
                guide guide = new guide();
                guide.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

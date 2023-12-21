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

        private void initdatabaase()
        {
            if (login.IsFileExist(@System.Environment.CurrentDirectory + "\\bookinfo.mdf"))
            {
                //database exists
            }
            else
            {
                label2.Text = "Initializing database...";
                System.IO.File.Copy(@"https://fibrecase..japaneast.cloudapp.azure.com/bookinfo.mdf", @System.Environment.CurrentDirectory + "\\bookinfo.mdf");
                //database not exists
                SqlConnection con = new SqlConnection(Global.databaseurl);
                con.Open();
                string query = "create table bookinfo (name varchar(50),type varchar(50),isbn varchar(50),note varchar(50),status int)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

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

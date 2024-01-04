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
    public partial class lend : Form
    {
        public lend()
        {
            InitializeComponent();
            populate();
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

        private string str = System.Environment.CurrentDirectory;
        SqlConnection con = new SqlConnection(@Global.databaseurl);

        private void populate()
        {
            //show all books
            con.Open();

            string query = "select * from bookinfo";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            guide guide = new guide();
            guide.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //search button
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from bookinfo where name = '" + isbns.Text + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                outputcase.Text = "" +reader["name"].ToString() + "\n" + reader["type"].ToString() +"\n" + reader["isbn"].ToString() + "\n" + reader["note"].ToString() + "\n";
            }
            con.Close();

            populate();
        }

        private void outputcase_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //lend button
            
            con.Open();
            string query = "update bookinfo set status = 0 where isbn = '" + isbnt.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            outputcase.Text = "Book lent successfully!";
            populate();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            string query = "update bookinfo set status = 1 where isbn = '" + isbnt.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            outputcase.Text = "Book returned successfully!";
            populate();
        }

        private void lend_Load(object sender, EventArgs e)
        {

        }
    }
}

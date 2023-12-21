using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient ;

namespace WindowsFormsApp1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CodeLab\ProC++\Study\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\bookinfo.mdf;Integrated Security=True;Connect Timeout=30");

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
            //exit button
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || isbn.Text == "")
            {
                MessageBox.Show("Add more information!");
            }
            else
            {
                //add new book
                try
                {
                    con.Open();

                    string query = "insert into bookinfo values ('" + name.Text + "','" + type.Text + "','" + isbn.Text + "','" + note.Text + "','" + 1 + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    outputcase.Text = "Book added successfully!";

                    con.Close();
                }
                catch (Exception ex)    
                {
                    outputcase.Text = ex.Message;
                    con.Close();
                }
            }
            populate();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            guide guide = new guide();
            guide.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isbn.Text == "")
            {
                MessageBox.Show("Add more information!");
            }
            else
            {
                try
                {
                    con.Open();

                    string query = "delete from bookinfo where isbn = '" + isbn.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    outputcase.Text = "Book deleted successfully!";

                    con.Close();
                }
                catch (Exception ex)
                {
                    outputcase.Text = ex.Message;
                    con.Close();
                }
            }
            populate();
        }
    }
}

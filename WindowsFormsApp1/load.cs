using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        int ticks = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int n = ran.Next(5);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System.Admin
{
    public partial class Reviews_Section : Form
    {
        public Reviews_Section()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuestReview man = new GuestReview();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HostReview man = new HostReview();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

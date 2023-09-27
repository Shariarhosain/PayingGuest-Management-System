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
    public partial class ApproveAndCheckout : Form
    {
        public ApproveAndCheckout()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookinApprove man = new BookinApprove();

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
            CheckoutApprove  man = new CheckoutApprove();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckoutApprove man = new CheckoutApprove();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }
    }
}

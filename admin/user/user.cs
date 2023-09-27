using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System.Admin.User
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Guest_User gue_u = new Guest_User();

            gue_u.TopLevel = false;
            gue_u.AutoScroll = true;
            gue_u.Dock = DockStyle.Fill;
            panel1.Controls.Add(gue_u);
            gue_u.FormBorderStyle = FormBorderStyle.None;
            gue_u.BringToFront();
           
            
       
            gue_u.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Host_User hos_u = new Host_User();

            hos_u.TopLevel = false;
            hos_u.AutoScroll = true;
            hos_u.Dock = DockStyle.Fill;
            panel1.Controls.Add(hos_u);
            hos_u.FormBorderStyle = FormBorderStyle.None;
            hos_u.BringToFront();

            hos_u.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Host_User man = new Host_User();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel1.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Paying_Guest_Management_System.Guest
{
    public partial class guest_dashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public guest_dashboard()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuestBooking man = new GuestBooking();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Checkout man = new Checkout();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            History man = new History();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordReset_Guest man = new PasswordReset_Guest();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guest_dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Guest_Booking] WHERE BookedStatus = 'Approve' AND UserName='" + Login.Name2+"'", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
            con.Close();
            if (UserExist > 0)
            {
                label18.Text = UserExist.ToString();

                return;

            }
            else
            {
                label18.Text = "0";


            }
            
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM [Paying Guest].[dbo].[Guest_Booking] where RequestedCheckout='yes' AND UserName='" + Login.Name2 + "' ", con);
            int User = (int)check.ExecuteScalar();
            con.Close();
            if (User > 0)
            {
                label8.Text = User.ToString();

                return;

            }
            else
            {
                label8.Text = "0";


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_n = new SqlCommand("SELECT COUNT(*) FROM [Paying Guest].[dbo].[Guest_Booking]where BookedStatus='Pending' OR BookedStatus='NotApprove' AND UserName='" + Login.Name2 + "'", con);
            int User1 = (int)check_n.ExecuteScalar();
            con.Close();
            if (User1 > 0)
            {
                label3.Text = User1.ToString();

                return;

            }
            else
            {
                label3.Text = "0";


            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            guestReview man = new guestReview();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }
    }
}

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

namespace Paying_Guest_Management_System.Host
{
    public partial class host_dashboard : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        private Form activeForm;
        public host_dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Post myForm = new Post();
            if (activeForm != null)
                activeForm.Close();
            activeForm = myForm;
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel2.Controls.Add(myForm);
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.BringToFront();
            myForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OtherPost man = new OtherPost();
          
            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditPassword man = new EditPassword();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void host_dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            History_Host man = new History_Host();

            man.TopLevel = false;
            man.AutoScroll = true;
            man.Dock = DockStyle.Fill;
            panel2.Controls.Add(man);
            man.FormBorderStyle = FormBorderStyle.None;
            man.BringToFront();
            man.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check= new SqlCommand("  Select count(*) FROM [Paying Guest].[dbo].[Host_post] where HouseBooked = 'No'And UserName='" + Login.Name + "'", con);

            int UserExist1 = (int)check.ExecuteScalar();
            label7.Text = UserExist1.ToString();
            SqlCommand check_User_Name = new SqlCommand("  Select count(*) FROM [Paying Guest].[dbo].[Host_post] where HouseBooked = 'Yes'And UserName='"+Login.Name+"'", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
            label18.Text = UserExist.ToString();
            con.Close();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                con.Open();
          
            SqlCommand check_User_Name = new SqlCommand("  select COUNT(Checkout) FROM[Paying Guest].[dbo].[Guest_Booking_History] inner join[Paying Guest].[dbo].[Host_post] on[Guest_Booking_History].HouseNumber =[Host_post].HouseNumber where[Host_post].UserName ='" + Login.Name + "' and[Guest_Booking_History].Checkout is not null ", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
            label8.Text = UserExist.ToString();
            con.Close();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HostReview_guest man = new HostReview_guest();

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
    }
}

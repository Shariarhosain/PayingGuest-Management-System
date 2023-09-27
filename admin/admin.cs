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
using Paying_Guest_Management_System.Admin.User;

namespace Paying_Guest_Management_System.Admin
{
    public partial class admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        private Form activeForm;
        public admin()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            user myForm = new user();
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

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApproveAndCheckout myForm = new ApproveAndCheckout();
         
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel2.Controls.Add(myForm);
            myForm.FormBorderStyle = FormBorderStyle.None;

            myForm.BringToFront();

            myForm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Host_Registation] where Status='Pending'", con);
         
            int UserExist = (int)check_User_Name.ExecuteScalar();
            label18.Text = UserExist.ToString();
            SqlCommand check = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Guest_Registation] where Status='Pending'", con);

            int UserExist1 = (int)check.ExecuteScalar();
            label7.Text = UserExist1.ToString();
            con.Close();
          
               

             
               

               

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Guest_Registation] where Status='Approve'", con);

            int UserExist1 = (int)check.ExecuteScalar();
            label15.Text = UserExist1.ToString();

            SqlCommand check_User_Name = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Host_Registation] where Status='Approve'", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
             label8.Text = UserExist.ToString();
            con.Close();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Host_Registation] where Status='NotApprove'", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
            label23.Text = UserExist.ToString();
            SqlCommand check = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Guest_Registation] where Status='NotApprove'", con);

            int UserExist1 = (int)check.ExecuteScalar();
            label3.Text = UserExist1.ToString();
            con.Close();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Guest_Booking] where BookedStatus='NotApprove' OR BookedStatus='Pending'  ", con);

            int UserExist1 = (int)check.ExecuteScalar();
            label10.Text = UserExist1.ToString();
            SqlCommand check_User_Name = new SqlCommand("SELECT  count(*) FROM [Paying Guest].[dbo].[Guest_Booking] where BookedStatus='Approve' AND RequestedCheckout='Yes' ", con);

            int UserExist = (int)check_User_Name.ExecuteScalar();
            label21.Text = UserExist.ToString();

            con.Close();
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reviews_Section myForm = new Reviews_Section();

            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel2.Controls.Add(myForm);
            myForm.FormBorderStyle = FormBorderStyle.None;

            myForm.BringToFront();

            myForm.Show();
        }
    }
}

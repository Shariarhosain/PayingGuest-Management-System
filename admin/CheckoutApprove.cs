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

namespace Paying_Guest_Management_System.Admin
{
    public partial class CheckoutApprove : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public CheckoutApprove()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT  * from Guest_Booking where BookedStatus='" + "Approve" + "'AND RequestedCheckout='" + "Yes" + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gunaDataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text= gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(dateTimePicker1.Text))

                {

                    if (MessageBox.Show("Do You Want To Update This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        con.Open();
                        SqlCommand command = new SqlCommand("Update Guest_Booking_History set Checkout='"+dateTimePicker1.Text+"' where HouseNumber='" + textBox6.Text+ "' AND GuestUserName='"+ textBox1.Text + "'", con);
                        

                        command.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand command3 = new SqlCommand("Update Host_post set HouseBooked='"+"No"+"' where HouseNumber='" + textBox6.Text + "'", con);


                        command3.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand command2 = new SqlCommand("Delete from Guest_Booking where HouseNumber='" + textBox6.Text + "' ", con);
                        
                        command2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Checkout Approved");


                        textBox6.Text = "";
                        textBox1.Text = "";





                    }
                    else
                    {
                        MessageBox.Show("Data Not Updated", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }

                else
                {

                    MessageBox.Show("Please Fill Up All The Informaton");
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);

            }
            finally
            {
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Guest_booking_History  where BookedStatus='" + "Approve" + "' AND Checkout IS NOT NULL   ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            con.Close();
        }
    }
}

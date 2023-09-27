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
    public partial class BookinApprove : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");

        public BookinApprove()
        {
            InitializeComponent();
        }

        private void BookinApprove_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'OwnerName' ,Host_Registation.Phone,Host_Registation.Email ,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address AS 'House Location',Host_Post.Cost,Host_Post.HouseBooked,Guest_registation.Name AS 'Guest Name',Guest_registation.phone,Guest_registation.Email,Guest_registation.Gender,Guest_booking.BookedStatus,Guest_Registation.UserName FROM Host_Registation  INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username INNER JOIN Guest_Booking ON Host_Post.HouseNumber = Guest_Booking.HouseNumber INNER JOIN Guest_Registation ON Guest_Booking.UserName = Guest_Registation.UserName where Guest_Booking.BookedStatus='" + "pending" + "' OR Guest_Booking.BookedStatus='" + "NotApprove" + "'", con);

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
            comboBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            textBox6.Text= gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(dateTimePicker1.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))

                {
                    
                        if (MessageBox.Show("Do You Want To Update This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                        con.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO Guest_Booking_History VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16,@value17)", con);
                        command.Parameters.AddWithValue("@value1", gunaDataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        command.Parameters.AddWithValue("@value2", gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@value3", gunaDataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                        command.Parameters.AddWithValue("@value4", gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                        command.Parameters.AddWithValue("@value5", gunaDataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                        command.Parameters.AddWithValue("@value6", gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                        command.Parameters.AddWithValue("@value7", gunaDataGridView1.SelectedRows[0].Cells[6].Value.ToString());
                        command.Parameters.AddWithValue("@value8", gunaDataGridView1.SelectedRows[0].Cells[7].Value.ToString());
                        command.Parameters.AddWithValue("@value9", gunaDataGridView1.SelectedRows[0].Cells[8].Value.ToString());
                        command.Parameters.AddWithValue("@value10", dateTimePicker1.Text);
                        command.Parameters.AddWithValue("@value11", gunaDataGridView1.SelectedRows[0].Cells[9].Value.ToString());
                        command.Parameters.AddWithValue("@value12", gunaDataGridView1.SelectedRows[0].Cells[10].Value.ToString());
                        command.Parameters.AddWithValue("@value13", gunaDataGridView1.SelectedRows[0].Cells[11].Value.ToString());
                        command.Parameters.AddWithValue("@value14", gunaDataGridView1.SelectedRows[0].Cells[12].Value.ToString());
                        command.Parameters.AddWithValue("@value15", comboBox2.Text);
                        command.Parameters.AddWithValue("@value16", DBNull.Value);
                        command.Parameters.AddWithValue("@value17", gunaDataGridView1.SelectedRows[0].Cells[14].Value.ToString());

                        command.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand command2 = new SqlCommand("update Guest_Booking set BookedStatus='" + comboBox2.Text+"' where HouseNumber='"+ gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "'  ", con);
;
                        command2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Booking Status Approved");


                            comboBox2.Text = "";
                            



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

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Guest_booking_History where BookedStatus='"+"Approve"+ "'AND  Checkout is NULL  ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class GuestBooking : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        string gender;
        public GuestBooking()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username WHERE Host_Post.PreferableGender = @PreferableGender ", con);
                com.Parameters.AddWithValue("@PreferableGender",comboBox2.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username WHERE Host_Post.Cost BETWEEN '"+ textBox1.Text + "' And '" + textBox4.Text + "' ", con);
            
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username WHERE Host_Post.Address='"+ comboBox3.Text+"'", con);

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username WHERE Host_Post.Address='" + comboBox3.Text + "' AND Host_Post.Address='" + comboBox3.Text + "'  AND  Host_Post.Cost BETWEEN '" + textBox1.Text + "' And '" + textBox4.Text + "' AND Host_Post.PreferableGender = '"+comboBox2.Text+"'  ", con);

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

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username", con);
             
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

            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            gender= gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void GuestBooking_Load(object sender, EventArgs e)
        {
            textgg.Text = Login.Name2;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("SELECT Gender FROM Guest_Registation where  UserName='" + Login.Name2 + "' ", con);
            string name4 = (string)com1.ExecuteScalar();
            SqlCommand com2 = new SqlCommand("SELECT PreferableGender FROM Host_Post where  PreferableGender='Both' ", con);
            string name5 = (string)com2.ExecuteScalar();

            con.Close();
        
          


            
            try
            {
                if (gender==name4  || gender==name5  )
                {


                    if (!string.IsNullOrWhiteSpace(textBox6.Text))

                    {

                        con.Open();
                        SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Host_Post] WHERE ([HouseBooked] = @HouseBooked) AND ([HouseNumber] = @HouseNumber) ", con);
                        check_User_Name.Parameters.AddWithValue("@HouseBooked", "Yes");
                        check_User_Name.Parameters.AddWithValue("@HouseNumber", textBox6.Text);
                        int UserExist = (int)check_User_Name.ExecuteScalar();
                        con.Close();
                      


                        if (UserExist > 0)
                        {
                            MessageBox.Show("House is Booked. Sorry You can't booked. Choose Another One Or wait");
                        }


                        else
                        {

                            if (MessageBox.Show("Do You Want To Book This House", " Booked House", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                con.Open();
                                SqlCommand command = new SqlCommand("insert into  Guest_Booking values ('" + textgg.Text + "','" + textBox6.Text + "','" + "Pending" + "','"+"No"+"')", con);

                                command.ExecuteNonQuery();
                                con.Close();
                                con.Open();
                                SqlCommand com = new SqlCommand("update Host_Post set HouseBooked=@HouseBooked Where  HouseNumber='" + textBox6.Text + "'", con);
                                com.Parameters.AddWithValue("@HouseBooked", "Yes");
                                com.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Booked  Successfully but wait For Admin Confirmation");


                                textBox6.Text = "";



                            }
                            else
                            {
                                MessageBox.Show("House Not Booked ", "Insert Data Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                    }
                    else
                    {

                        MessageBox.Show("Please Fill Up All The Informaton");
                    }

                }

                else
                {

                    MessageBox.Show("Gender doesn't match");
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT * from Guest_Booking Where UserName='" + Login.Name2+"'", con);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gunaDataGridView2.DataSource = dt;
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
    }
}

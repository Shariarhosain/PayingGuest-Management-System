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
    public partial class EditPost : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public EditPost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Host_Post] WHERE ([HouseBooked] = @HouseBooked)", con);
                    check_User_Name.Parameters.AddWithValue("@HouseBooked", "Yes");
                    int UserExist = (int)check_User_Name.ExecuteScalar();
                    con.Close();
                    if (UserExist > 0)
                    {
                        MessageBox.Show("House Alredy  Booked You Can't Edit. Please Wait Until It's Availavble");
                        button2.Enabled = false;
                        button2.BackColor = Color.Red;

                        return;

                    }
                    else
                    {
                        con.Open();
                        SqlCommand comm = new SqlCommand("select * from Host_Post where HouseNumber=@HouseNumber", con);
                        comm.Parameters.AddWithValue("@HouseNumber", textBox6.Text);
                        SqlDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            MessageBox.Show("Information found");
                            
                            textBox3.Text = dr[1].ToString();
                            comboBox2.Text = dr[2].ToString();
                            comboBox3.Text = dr[3].ToString();
                            textBox4.Text = dr[4].ToString();
                            button2.Enabled = true;
                            button2.BackColor = Color.FromArgb(43, 174, 102);
                            

                        }

                        else
                        {
                            MessageBox.Show("No record found with this HouseNUmber ", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button2.Enabled = false;
                            button2.BackColor = Color.Red;

                            dr.Close();

                        }
                        
                    }

                    
                }
                else
                {
                    MessageBox.Show("Please insert House NUmber", "insert House NUmber", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textgg_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditPost_Load(object sender, EventArgs e)
        {
            textgg.Text = Login.Name;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username WHERE Host_Registation.Username = @Username ", con);
                com.Parameters.AddWithValue("@UserName", textgg.Text);
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
                if (!string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))

                {
                    

                        if (MessageBox.Show("Do You Want To Insert This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            con.Open();
                            SqlCommand command = new SqlCommand("UPDATE Host_post set  NumberOfRoom=@NumberOfRoom,PreferableGender=@PreferableGender,Address=@Address,Cost=@Cost,HouseBooked=@HouseBooked,UserName=@UserName where HouseNumber='"+textBox6.Text+"'", con);

                            //command.Parameters.AddWithValue("@HouseNumber", textBox6.Text);
                            command.Parameters.AddWithValue("@NumberOfRoom", textBox3.Text);
                            command.Parameters.AddWithValue("@PreferableGender", comboBox2.Text);
                            command.Parameters.AddWithValue("@Address", comboBox3.Text);
                            command.Parameters.AddWithValue("@Cost", textBox4.Text);
                            
                            command.Parameters.AddWithValue("@HouseBooked", "No");
                        command.Parameters.AddWithValue("@UserName", textgg.Text);
                        command.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Inserted Successfully");
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox6.Text = "";
                            comboBox2.Text = "";
                            comboBox3.Text = "";



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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

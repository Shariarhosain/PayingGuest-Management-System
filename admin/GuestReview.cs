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
    public partial class GuestReview : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");

        public GuestReview()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Guest_Registation where Status='Approve'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))

                {
                con.Open();
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Review] WHERE  GuestName='"+textBox1.Text+ "' and AdminGuestReview is not null ", con);

                int UserExist = (int)check_User_Name.ExecuteScalar();
                con.Close();



                    if (UserExist > 0)
                    {
                        MessageBox.Show("Review Already Done ");
                    }

                    else
                    {



                        if (MessageBox.Show("Do You Want To Review This Guest", "Review This Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            con.Open();
                            SqlCommand command = new SqlCommand("INSERT INTO Review VALUES (@value1, @value2, @value3, @value4, @value5, @value6)", con);
                            command.Parameters.AddWithValue("@value1", textBox1.Text);
                            command.Parameters.AddWithValue("@value2", DBNull.Value);
                            command.Parameters.AddWithValue("@value3", comboBox2.Text);
                            command.Parameters.AddWithValue("@value4", DBNull.Value);
                            command.Parameters.AddWithValue("@value5", DBNull.Value);
                            command.Parameters.AddWithValue("@value6", DBNull.Value);
                            //command.Parameters.AddWithValue("@value7", DBNull.Value);


                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Review Done");


                            comboBox2.Text = "";
                            textBox1.Text = "";





                        }
                        else
                        {
                            MessageBox.Show("Review Not Done", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand(" select Guest_Registation.Name,Guest_Registation.Phone,Guest_Registation.Email,Guest_Registation.Address,Guest_Registation.Gender,Guest_Registation.Status,[Review].AdminGuestReview,[Review].HostReview,[Review].GuestName AS 'GuestUserName' FROM [Paying Guest].[dbo].[Review] inner join [Paying Guest].[dbo].Guest_Registation on Review.GuestName=Guest_Registation.UserName where Guest_Registation.Status='Approve' and Review.AdminGuestReview is not null", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))

                {
                    con.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Review] WHERE  GuestName='" + textBox1.Text + "' and AdminGuestReview is not null ", con);

                    int UserExist = (int)check_User_Name.ExecuteScalar();
                    con.Close();



                    if (UserExist > 0)
                    {
                        MessageBox.Show("Review Found ");
                        if (MessageBox.Show("Do You Want To Review This Guest", "Review This Guest", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            con.Open();
                            SqlCommand command = new SqlCommand("Update Review set AdminGuestReview='" + comboBox2.Text + "' where GuestName='" + textBox1.Text + "'", con);



                            command.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Update Done");


                            comboBox2.Text = "";
                            textBox1.Text = "";





                        }
                        else
                        {
                            MessageBox.Show("Review Not Done", "Insert Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }

                    else
                    {


                        MessageBox.Show("Review Not Found ");


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

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = gunaDataGridView2.SelectedRows[0].Cells[8].Value.ToString();
            comboBox2.Text= gunaDataGridView2.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paying_Guest_Management_System.Admin.User
{
    public partial class Host_User : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public Host_User()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("select Name,Email,Phone,Address,Gender,UserName,Status from Host_Registation ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ( !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))

                { 

                    if (MessageBox.Show("Do You Want To Insert This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        con.Open();
                        SqlCommand command = new SqlCommand("update Host_Registation set Name=@Name,Email=@Email,Phone=@Phone,Address=@Address,Gender=@Gender,Status=@Status where UserName=@UserName", con);
                       
                        command.Parameters.AddWithValue("@Name", textBox6.Text);
                        command.Parameters.AddWithValue("@Email", textBox3.Text);
                        command.Parameters.AddWithValue("@Phone", textBox4.Text);
                        command.Parameters.AddWithValue("@Address", textBox5.Text);
                        command.Parameters.AddWithValue("@Gender", comboBox2.Text);
                        command.Parameters.AddWithValue("@UserName", textBox2.Text);
                        command.Parameters.AddWithValue("@Status", comboBox1.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Update Successfully");

                        textBox2.Text = "Ho-";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {

                    con.Open();
                    SqlCommand comm = new SqlCommand("select * from Host_Registation where UserName=@UserName", con);
                    comm.Parameters.AddWithValue("@UserName", textBox2.Text);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Information found");
                        textBox6.Text = dr[0].ToString();
                        textBox3.Text = dr[1].ToString();
                        textBox4.Text = dr[2].ToString();
                        textBox5.Text = dr[3].ToString();
                        comboBox2.Text = dr[4].ToString();
                        comboBox1.Text = dr[7].ToString();
                        button2.Enabled = true;
                        button2.BackColor = Color.FromArgb(43, 174, 102);


                    }

                    else
                    {
                        MessageBox.Show("No record found with this id", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button2.Enabled = false;
                        button2.BackColor = Color.Red;

                        dr.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Please insert into Id", "insert id", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]{11}$");
            if (regex.IsMatch(textBox4.Text))
            {
                errorProvider2.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.FromArgb(43, 174, 102);


            }
            else
            {
                errorProvider2.SetError(this.textBox4, " Provide only 11 Digite");
                button2.Enabled = false;
                button2.BackColor = Color.Red;

                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^([0-9a-zA-Z]([-.\\w\\+]*[0-9a-zA-Z\\+])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");

            if (regex.IsMatch(textBox3.Text))
            {
                errorProvider1.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.FromArgb(43, 174, 102);

            }
            else
            {
                errorProvider1.SetError(this.textBox3, " Provide valid Mail address");
                button2.Enabled = false;
                button2.BackColor = Color.Red;
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = gunaDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}

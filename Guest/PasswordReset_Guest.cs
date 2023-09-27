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
    public partial class PasswordReset_Guest : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public PasswordReset_Guest()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordReset_Guest_Load(object sender, EventArgs e)
        {
            textgg.Text = Login.Name2;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text))

                {


                    if (MessageBox.Show("Do You Want To Insert This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        con.Open();
                        SqlCommand command = new SqlCommand("update Guest_Registation set  Password=@Password where UserName='" + Login.Name2 + "'", con);

                        command.Parameters.AddWithValue("@Password", textBox2.Text);

                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Update Successfully");
                        textBox2.Text = "";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM  [Paying Guest].[dbo].[Guest_Registation] WHERE ([Password] = @Password)", con);
            check_User_Name.Parameters.AddWithValue("@Password", textBox1.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();
            con.Close();
            if (UserExist > 0)
            {



                errorProvider1.Clear();
                button2.Enabled = true;
                button2.BackColor = Color.FromArgb(43, 174, 102);
                return;

            }
            else
            {
                errorProvider1.SetError(this.textBox1, " Password Doesn't Match");
                button2.Enabled = false;
                button2.BackColor = Color.Red;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textgg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

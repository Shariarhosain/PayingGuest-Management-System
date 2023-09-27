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
    public partial class Checkout : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public Checkout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT  * from Guest_Booking where BookedStatus='"+"Approve"+ "'AND RequestedCheckout='" + "No" + "' and Username='"+Login.Name2+"'", con);

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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {



                con.Open();
                SqlCommand com = new SqlCommand("SELECT  * from Guest_Booking where BookedStatus='" + "Approve" + "' AND RequestedCheckout='"+"Yes"+"'", con);

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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(comboBox3.Text)&& !string.IsNullOrWhiteSpace(textBox6.Text))

                {
                    

                    if (MessageBox.Show("Do You Want To Update This Data", "Insert Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        con.Open();
                        SqlCommand command = new SqlCommand("Update Guest_Booking set RequestedCheckout='"+comboBox3.Text+"' where Housenumber='"+ textBox6.Text + "'", con);
                       

                        command.ExecuteNonQuery();
                        con.Close();
                        
                        MessageBox.Show("Checkout Status Requested");


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

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox3.Text = gunaDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox6.Text = gunaDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
    }
}

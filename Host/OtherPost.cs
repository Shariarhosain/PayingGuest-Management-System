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
    public partial class OtherPost : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public OtherPost()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Host_Registation.Name AS 'Owner Name' ,Host_Registation.Email ,Host_Registation.Phone,Host_Post.HouseNumber,Host_Post.NumberOfRoom,Host_Post.PreferableGender,Host_Post.Address,Host_Post.Cost,Host_Post.HouseBooked FROM Host_Registation INNER JOIN Host_Post ON Host_Registation.Username = Host_Post.username", con);
         
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            con.Close();
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
                com.Parameters.AddWithValue("@UserName", Login.Name);
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
    }
}

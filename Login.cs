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
using Paying_Guest_Management_System.Admin;
using Paying_Guest_Management_System.Guest;
using Paying_Guest_Management_System.Host;

namespace Paying_Guest_Management_System
{
   
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        private string id;
        private string password;
        public static string loginName;
        public static string loginName2;



        public string Id { get; set; }
        public string Password { get; set; }
        public static string Name
        {
            get { return loginName; }
            set { loginName = value; }

        }
        public static string Name2
        {
            get { return loginName2; }
            set { loginName2 = value; }

        }



        public Login( )
        {
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Id = textBox55.Text.ToString();
            Name = textBox55.Text;
            Name2 = textBox55.Text;
            Password = textBox2.Text;


            if (Id != "" && Password != "")
            {

                for (int i = 0; i < Id.Length; i++)
                {
                    if (Id[0] == 'a')
                    {



                        if ((Id == "admin") && (Password == "admin"))
                        {

                            admin adm = new admin();
                            adm.Show();
                            this.Hide();
                            if (Id != null)
                            {

                                adm.label4.Text = "Admin";
                                adm.label2.Text = "Admin";
                                con.Open();

                               
                            }

                        }
                        else
                        {

                            MessageBox.Show("please enter right Admin  User Name  and Password");


                        }



                    }
                    else if (Id[0] == 'G')
                    {
                        con.Open();
                        SqlCommand check = new SqlCommand("SELECT COUNT(*)  FROM  [Paying Guest].[dbo].[Guest_Registation] WHERE ([UserName] = @UserName) and ([Status] = @Status)", con);

                        check.Parameters.AddWithValue("@UserName", textBox55.Text);
                       
                        check.Parameters.AddWithValue("@Status", "Approve");

                        int UserExist = (int)check.ExecuteScalar();
                        con.Close();
                        if (UserExist > 0)
                        {
                            con.Open();
                            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*)  FROM  [Paying Guest].[dbo].[Guest_Registation] WHERE ([UserName] = @UserName) and ([Password] = @Password)", con);

                            check_User_Name.Parameters.AddWithValue("@UserName", textBox55.Text);
                            check_User_Name.Parameters.AddWithValue("@Password", textBox2.Text);
                          
                            con.Close();
                            SqlDataAdapter da = new SqlDataAdapter(check_User_Name);
                            DataTable dt = new DataTable();
                            da.Fill(dt);


                            if (dt.Rows[0][0].ToString() == "1")
                            {

                                guest_dashboard man = new guest_dashboard();
                                man.Show();
                                this.Hide();
                                
                                if (Id != null)
                                {

                                    man.label4.Text = "Guest";

                                    con.Open();


                                    SqlCommand User_Name = new SqlCommand("SELECT * FROM  Guest_Registation WHERE UserName = @UserName and Password = @Password", con);
                                    User_Name.Parameters.AddWithValue("@UserName", textBox55.Text);
                                    User_Name.Parameters.AddWithValue("@Password", textBox2.Text);
                                    
                                    SqlDataReader dr = User_Name.ExecuteReader();
                                    if (dr.Read())
                                    {

                                        man.label2.Text = dr[0].ToString().ToUpper();
                                       





                                    }

                                    con.Close();

                                }
                                



                            }
                            else
                            {

                                MessageBox.Show("please enter right User Name and Password ");


                            }
                        }
                        else
                        {
                            MessageBox.Show("your Id not Active");
                        }

                    }
                    else if (Id[0] == 'H')
                    {
                        con.Open();
                        SqlCommand check = new SqlCommand("SELECT COUNT(*)  FROM  [Paying Guest].[dbo].[Host_Registation] WHERE ([UserName] = @UserName) and ([Status] = @Status)", con);

                        check.Parameters.AddWithValue("@UserName", textBox55.Text);

                        check.Parameters.AddWithValue("@Status", "Approve");

                        int UserExist = (int)check.ExecuteScalar();
                        con.Close();
                        if (UserExist > 0)
                        {
                            con.Open();
                            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*)  FROM  [Paying Guest].[dbo].[Host_Registation] WHERE ([UserName] = @UserName) and ([Password] = @Password)", con);

                            check_User_Name.Parameters.AddWithValue("@UserName", textBox55.Text);
                            check_User_Name.Parameters.AddWithValue("@Password", textBox2.Text);

                            con.Close();
                            SqlDataAdapter da = new SqlDataAdapter(check_User_Name);
                            DataTable dt = new DataTable();
                            da.Fill(dt);


                            if (dt.Rows[0][0].ToString() == "1")
                            {

                                host_dashboard man = new host_dashboard();
                                man.Show();
                                this.Hide();

                                if (Id != null)
                                {

                                    man.label4.Text = "Host";

                                    con.Open();


                                    SqlCommand User_Name = new SqlCommand("SELECT * FROM  Host_Registation WHERE UserName = @UserName and Password = @Password", con);
                                    User_Name.Parameters.AddWithValue("@UserName", textBox55.Text);
                                    User_Name.Parameters.AddWithValue("@Password", textBox2.Text);

                                    SqlDataReader dr = User_Name.ExecuteReader();
                                    if (dr.Read())
                                    {

                                        man.label2.Text = dr[0].ToString().ToUpper();






                                    }

                                    con.Close();

                                }




                            }
                            else
                            {

                                MessageBox.Show("please enter right User Name and Password ");


                            }
                        }
                        else
                        {
                            MessageBox.Show("your Id not Active");
                        }

                    }





                    else
                    {

                        MessageBox.Show("please enter right User Name and Password ");

                    }
                    break;

                }

            }

            else
            {
                MessageBox.Show("please enter all information");
            }

        }
    }
}

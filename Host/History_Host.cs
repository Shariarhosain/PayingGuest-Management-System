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
    public partial class History_Host : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SHARIAR;Initial Catalog=Paying Guest;Persist Security Info=True;User ID=sa;Password=sanny");
        public History_Host()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand(" select [Guest_Booking_History].[OwnerName],[Guest_Booking_History].[OwnerPhone],[Guest_Booking_History].[OwnerEmail],[Guest_Booking_History].[HouseNumber],[Guest_Booking_History].[NumberOfRoom],[Guest_Booking_History].[PreferableGender],[HouseLocation],[Guest_Booking_History].[Cost],[Guest_Booking_History].[HouseBooked],[Guest_Booking_History].[HouseBooked_Date],[Guest_Booking_History].[GuestName],[GuestPhone],[Guest_Booking_History].[GuestEmail],[Guest_Booking_History].[GuestGender],[Guest_Booking_History].[BookedStatus],[Guest_Booking_History].[Checkout],[Guest_Booking_History].[GuestUserName]  FROM [Paying Guest].[dbo].[Guest_Booking_History] inner join [Paying Guest].[dbo].[Host_post] on   [Guest_Booking_History].HouseNumber=[Host_post].HouseNumber where [Guest_Booking_History].BookedStatus='Approve'and  [Host_post].[UserName]='"+Login.Name+"' and [Guest_Booking_History].Checkout is not null", con);
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
    }
}

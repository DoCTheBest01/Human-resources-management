using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Net;

namespace Human_resources_management
{
    public partial class frm_traffic : Form
    {
        public frm_traffic()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("کد پرسنلی وارد نشده است دوباره تلاش کنید", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                /*var conn = new SqlConnection();
                conn.ConnectionString = ("Data Source=DESKTOP-MSRBBB5/MYSQL; Initial Catalog = Shetab; Integrated Security = True");
                SqlConnection connection = new SqlConnection();
                conn.Open();
                string selectQuery = "SELECT TOP (1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Birthday_IN],[Password_IN],[Picture_IN]FROM[Shetab].[dbo].[Information] WHERE Information.Pcode_IN=@Pcode_IN";
                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@Pcode_IN", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Information");
                conn.Close();

                class2.TextBoxValue = textBox1.Text;
                frm_TrafficPanel trafficPanel = new frm_TrafficPanel();
                tr.Show();*/


                var connection = new SqlConnection();
                connection.ConnectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
                connection.Open();
                string selectQuery = "SELECT TOP (1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Birthday_IN],[Password_IN],[Picture_IN]FROM[Shetab].[dbo].[Information] WHERE Information.Pcode_IN=@Pcode_IN";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Pcode_IN", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Information");
                connection.Close();
                if (dataSet.Tables["Information"].Rows.Count == 1)
                {
                        frm_TrafficPanel trafficPanel = new frm_TrafficPanel(textBox1.Text);
                        trafficPanel.Show();    
                }
                else
                {
                    MessageBox.Show("این کد پرسنلی وجود ندارد");
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue == Ke)
            //{

            //}
        }
    }
}





    






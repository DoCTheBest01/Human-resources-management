using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Markup;

namespace Human_resources_management
{
    public partial class frm_AdminLogin : Form
    {
        public frm_AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("کد پرسنلی وارد نشده است دوباره تلاش کنید", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (String.IsNullOrWhiteSpace(textBox2.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("رمز عبور وارد نشده است دوباره تلاش کنید", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { // Get the directory where the executable is located
              //  string dataDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Combine the directory with the relative path to the MDF file
                //  string mdfFilePath = $"{dataDirectory}\\Shetab1_log.ldf";
                string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
                // Use the correct connection string
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string selectQuery = "SELECT TOP (1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Birthday_IN],[Password_IN],[Picture_IN]FROM[Shetab].[dbo].[Information] WHERE Information.Pcode_IN=@Pcode_IN";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Pcode_IN", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Information");
                connection.Close();
                if (textBox1.Text == "alisre")
                {
                    if (dataSet.Tables["Information"].Rows.Count == 1)
                    {
                        if (dataSet.Tables["Information"].Rows[0][5].ToString() == textBox2.Text)
                        {
                            class2.TextBoxValue = textBox1.Text;
                            frm_AdminPanel adminPanel = new frm_AdminPanel();
                            adminPanel.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("رمز اشتباه است", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("این کد پرسنلی وجود ندارد", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("شما مدیر نمی باشید", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}

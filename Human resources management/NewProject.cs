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

namespace Human_resources_management
{
    public partial class frm_NewProject : Form
    {
        public frm_NewProject()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
                // ساخت اتصال
                SqlConnection connection = new SqlConnection(connectionString);

                // باز کردن اتصال
                connection.Open();

                // دستور SQL برای افزودن داده
                string insertQuery = "Insert Into Proposal  (The_initial_amount,The_final_amount,gross_receipts,Account_not_deducted,Received_management,Percentage_of_financial_progress,Balance_including_deductions,total_balance,Contract_code,Pardis,The_nature_of_the_project,city_and_province,Agreement_date,Executor_of_the_contract,contract_supervisor) Values (@The_initial_amount,@The_final_amount,@gross_receipts,@Account_not_deducted,@Received_management,@Percentage_of_financial_progress,@Balance_including_deductions,@total_balance,@Contract_code,@Pardis,@The_nature_of_the_project,@city_and_province,@Agreement_date,@Executor_of_the_contract,@contract_supervisor) ";

                // ساخت یک شیء Command با استفاده از دستور SQL و اتصال
                SqlCommand command = new SqlCommand(insertQuery, connection);
                {
                    string value1 = textBox2.Text;//FName
                    string value2 = textBox1.Text;//LName
                    string value3 = textBox5.Text;//Icode
                    string value4 = textBox3.Text;//Birthday
                    string value5 = textBox4.Text;//Pcode
                    string value6 = textBox6.Text;//Password
                    string value7 = textBox7.Text;
                    string value8 = textBox8.Text;
                    string value9 = textBox9.Text;
                    string value10 = textBox10.Text;
                    string value11 = textBox12.Text;
                    string value12 = textBox11.Text;
                    string value13 = textBox13.Text;
                    string value14 = textBox14.Text;
                    string value15 = textBox16.Text;


                    // اضافه کردن پارامترها با مقادیر مورد نظر
                    command.Parameters.AddWithValue("@The_initial_amount", value1);
                    command.Parameters.AddWithValue("@The_final_amount", value2);
                    command.Parameters.AddWithValue("@gross_receipts", value5);
                    command.Parameters.AddWithValue("@Account_not_deducted", value3);
                    command.Parameters.AddWithValue("@Received_management", value4);
                    command.Parameters.AddWithValue("@Percentage_of_financial_progress", value6);
                    command.Parameters.AddWithValue("@Balance_including_deductions" , value7);
                    command.Parameters.AddWithValue("@total_balance", value8);
                    command.Parameters.AddWithValue("@Contract_code", value9);
                    command.Parameters.AddWithValue("@Pardis", value10);
                    command.Parameters.AddWithValue("@The_nature_of_the_project", value11);
                    command.Parameters.AddWithValue("@city_and_province", value12);
                    command.Parameters.AddWithValue("@Agreement_date", value13);
                    command.Parameters.AddWithValue("@Executor_of_the_contract", value14);
                    command.Parameters.AddWithValue("@contract_supervisor", value15);

                    // اجرای دستور SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show("داده با موفقیت ذخیره شد", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" این کاربر قبلا ثبت نام شده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

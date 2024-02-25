using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;


namespace Human_resources_management
{
    public partial class frm_TrafficPanel : Form
    {
        string personallycode;
        string Day;
        private string pId;
        public frm_TrafficPanel(string Pid)
        {
            InitializeComponent();
            // دریافت تاریخ و زمان فعلی
            DateTime currentDate = DateTime.Now;

            // بازیابی روز هفته
            DayOfWeek weekday = currentDate.DayOfWeek;
            Day = weekday.ToString();
            this.pId = Pid;
        }
        private void Form5_Load(object sender, EventArgs e)
        {

            string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            string selectQuery1 = "SELECT TOP(1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Picture_IN]FROM[Shetab].[dbo].[Information]WHERE Information.Pcode_IN=@Pcode_IN";
            SqlCommand command1 = new SqlCommand(selectQuery1, connection1);
            command1.Parameters.AddWithValue("@Pcode_IN", this.pId);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataSet dataSet1 = new DataSet();
            adapter1.Fill(dataSet1,"Information");
            connection1.Close();
            label5.Text = dataSet1.Tables["Information"].Rows[0][0].ToString();
            label9.Text = dataSet1.Tables["Information"].Rows[0][1].ToString();
            label8.Text = dataSet1.Tables["Information"].Rows[0][2].ToString();
            label7.Text = dataSet1.Tables["Information"].Rows[0][3].ToString();
            byte[] imageData = (byte[])dataSet1.Tables["Information"].Rows[0][4];

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // اگر آرایه بایت خالی باشد یا مقدار null داشته باشد
                MessageBox.Show("تصویر موجود نیست.");
            }
            if (Day == "Saturday")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else if (Day == "Sunday")
            {
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;

            }
            else if (Day == "Monday")
            {
                radioButton5.Enabled = true;
                radioButton6.Enabled = true;

            }
            else if (Day == "Tuesday")
            {
                radioButton7.Enabled = true;
                radioButton8.Enabled = true;

            }
            else if (Day == "Wednesday")
            {
                radioButton9.Enabled = true;
                radioButton10.Enabled = true;

            }
            else if (Day == "Thursday")
            {
                radioButton11.Enabled = true;
                radioButton12.Enabled = true;

            }
            else if (Day == "Friday")
            {
                radioButton13.Enabled = true;
                radioButton14.Enabled = true;

            }

            string connectionString1 = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString1);
            connection.Open();
            string selectQuery = "SELECT TOP(1) [Pcode_TP]AS [کد پرسنلی],[Enter_TP]AS [ورود],[Exit_TP]AS [خروج],[Time_TP]AS [زمان],[Date_TP]AS [تاریخ] FROM[Shetab].[dbo].[Traffic_Panel]  WHERE Traffic_Panel.Pcode_TP=@Pcode_TP  ORDER BY [Time_TP] DESC;";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Pcode_TP", label8.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Traffic_Panel");
            connection.Close();
          //  dataGridView1.DataBindings.Clear();
         //   dataGridView1.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
            if (dataSet.Tables["Traffic_Panel"].Rows.Count == 1)
            {
                if (Convert.ToBoolean(dataSet.Tables["Traffic_Panel"].Rows[0][1]) == true)
                {

                    radioButton1.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton5.Enabled = false;
                    radioButton7.Enabled = false;
                    radioButton9.Enabled = false;
                    radioButton11.Enabled = false;
                    radioButton13.Enabled = false;

                }
                else 
                {
                    radioButton2.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton6.Enabled = false;
                    radioButton8.Enabled = false;
                    radioButton10.Enabled = false;
                    radioButton12.Enabled = false;
                    radioButton14.Enabled = false;

                }
            }
            else
            {
                radioButton2.Enabled = false;
                radioButton4.Enabled = false;
                radioButton6.Enabled = false;
                radioButton8.Enabled = false;
                radioButton10.Enabled = false;
                radioButton12.Enabled = false;
                radioButton14.Enabled = false;

            }

    





        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label14.Text = DateTime.Now.ToLongTimeString();

            label15.Text = DateTime.Now.ToLongDateString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از ثبت داده اطمینان دارید؟", "شتاب", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {

                    // باز کردن اتصال
                    connection.Open();

                    // دستور SQL برای افزودن داده
                    string insertQuery = "Insert Into Traffic_Panel (Pcode_TP,Enter_TP,Exit_TP,Date_TP,Time_TP,Weekdays_TP) Values (@Pcode_TP,@Enter_TP,@Exit_TP,@Date_TP,@Time_TP,@Weekdays_TP)";

                    // ساخت یک شیء Command با استفاده از دستور SQL و اتصال
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    {
                        string value1 = label8.Text;//pcode
                        string value16 = label15.Text;//date
                        string value17 = label14.Text;//time
                        string value18 = Day;//week days
                                             //check box  های ورودی
                        bool value2 = radioButton1.Checked;
                        bool value3 = radioButton3.Checked;
                        bool value4 = radioButton5.Checked;
                        bool value5 = radioButton7.Checked;
                        bool value6 = radioButton9.Checked;
                        bool value7 = radioButton11.Checked;
                        bool value8 = radioButton13.Checked;

                        //check box  های خروجی
                        bool value9 = radioButton2.Checked;
                        bool value10 = radioButton4.Checked;
                        bool value11 = radioButton6.Checked;
                        bool value12 = radioButton8.Checked;
                        bool value13 = radioButton10.Checked;
                        bool value14 = radioButton12.Checked;
                        bool value15 = radioButton14.Checked;

                        // اضافه کردن پارامترها با مقادیر مورد نظر
                        command.Parameters.AddWithValue("@Pcode_TP", value1);
                        command.Parameters.AddWithValue("@Enter_TP", value2 | value3 | value4 | value5 | value6 | value7 | value8);
                        command.Parameters.AddWithValue("@Exit_TP", value9 | value10 | value11 | value12 | value13 | value14 | value15);
                        command.Parameters.AddWithValue("@Date_TP", value16);
                        command.Parameters.AddWithValue("@Time_TP", value17);
                        command.Parameters.AddWithValue("@Weekdays_TP", value18);
                        // اجرای دستور SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // چاپ تعداد ردیف‌هایی که تغییر کرده‌اند
                        MessageBox.Show("داده با موفقیت ذخیره شد", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        radioButton1.Enabled = false;
                        radioButton3.Enabled = false;
                        radioButton5.Enabled = false;
                        radioButton7.Enabled = false;
                        radioButton9.Enabled = false;
                        radioButton11.Enabled = false;
                        radioButton13.Enabled = false;


                        if (Day == "Saturday")
                        {
                            radioButton1.Enabled = false;
                            radioButton2.Enabled = true;
                        }
                        else if (Day == "Sunday")
                        {
                            radioButton3.Enabled = false;
                            radioButton4.Enabled = true;

                        }
                        else if (Day == "Monday")
                        {
                            radioButton5.Enabled = false;
                            radioButton6.Enabled = true;

                        }
                        else if (Day == "Tuesday")
                        {
                            radioButton7.Enabled = false;
                            radioButton8.Enabled = true;

                        }
                        else if (Day == "Wednesday")
                        {
                            radioButton9.Enabled = false;
                            radioButton10.Enabled = true;

                        }
                        else if (Day == "Thursday")
                        {
                            radioButton11.Enabled = false;
                            radioButton12.Enabled = true;

                        }
                        else if (Day == "Friday")
                        {
                            radioButton13.Enabled = false;
                            radioButton14.Enabled = true;

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("داده ثبت نشد", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}







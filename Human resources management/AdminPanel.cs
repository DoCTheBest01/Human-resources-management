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
using System.IO;
using System.Configuration;
namespace Human_resources_management
{
    public partial class frm_AdminPanel : Form
    {
        string personallycode;
        public frm_AdminPanel()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();

            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("آیا از خارج شدن برنامه اطمینان دارید", "شتاب", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                frm_AdminPanel form6 = new frm_AdminPanel();
                form6.Close();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void عضویتجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.BringToFront();
            groupBox2.SendToBack();
            groupBox3.SendToBack();
            groupBox4.SendToBack();

        }

        private void ترددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.BringToFront();
            groupBox2.SendToBack();
            groupBox1.SendToBack();
            groupBox4.SendToBack();
            string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string selectQuery = "SELECT TOP(1000) [Pcode_TP]AS [کد پرسنلی],[Enter_TP]AS [ورود],[Exit_TP]AS [خروج],[Time_TP]AS [زمان],[Date_TP]AS [تاریخ] FROM[Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Pcode_TP", label6.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Traffic_Panel");
            connection.Close();
            dataGridView2.DataBindings.Clear();
            dataGridView2.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
        }

        private void تردداعضاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox4.BringToFront();
            groupBox2.SendToBack();
            groupBox3.SendToBack();
            groupBox1.SendToBack();
        }

        private void پروژهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();
            groupBox1.SendToBack();
            groupBox3.SendToBack();
            groupBox4.SendToBack();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private byte[] Getpicture()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox3.Image.Save(stream, pictureBox3.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(openfiledialog.FileName);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("نام خانوادگی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("کد ملی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("تاریخ تولد وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("کد پرسنلی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("رمز عبور وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (pictureBox3.Image == null)
            {
                MessageBox.Show("عکس وارد نشده است", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (MessageBox.Show("آیا از ثبت داده اطمینان دارید؟", "شتاب", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                try
                {
                    string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
                    // ساخت اتصال
                    SqlConnection connection = new SqlConnection(connectionString);

                    // باز کردن اتصال
                    connection.Open();

                    // دستور SQL برای افزودن داده
                    string insertQuery = "Insert Into Information (FName_IN,LName_IN,Pcode_IN,Incode_IN,Birthday_IN,Password_IN,Picture_IN) Values (@FName_IN,@LName_IN,@Pcode_IN,@Incode_IN,@Birthday_IN,@Password_IN,@Picture_IN)";

                    // ساخت یک شیء Command با استفاده از دستور SQL و اتصال
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    {
                        string value1 = textBox1.Text;//FName
                        string value2 = textBox2.Text;//LName
                        string value3 = textBox3.Text;//Icode
                        string value4 = textBox4.Text;//Birthday
                        string value5 = textBox5.Text;//Pcode
                        string value6 = textBox6.Text;//Password
                        // اضافه کردن پارامترها با مقادیر مورد نظر
                        command.Parameters.AddWithValue("@FName_IN", value1);
                        command.Parameters.AddWithValue("@LName_IN", value2);
                        command.Parameters.AddWithValue("@Pcode_IN", value5);
                        command.Parameters.AddWithValue("@Incode_IN", value3);
                        command.Parameters.AddWithValue("@Birthday_IN", value4);                      
                        command.Parameters.AddWithValue("@Password_IN", value6);
                        command.Parameters.AddWithValue("@Picture_IN", Getpicture());
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

        private void Form6_Load_1(object sender, EventArgs e)
        {
            personallycode = class2.TextBoxValue;
            string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string selectQuery = "SELECT TOP(1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Picture_IN]FROM[Shetab].[dbo].[Information]WHERE Information.Pcode_IN=@Pcode_IN";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Pcode_IN", personallycode);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Information");
            connection.Close();
            label5.Text = dataSet.Tables["Information"].Rows[0][0].ToString();
            label8.Text = dataSet.Tables["Information"].Rows[0][1].ToString();
            label6.Text = dataSet.Tables["Information"].Rows[0][2].ToString();
            label7.Text = dataSet.Tables["Information"].Rows[0][3].ToString();
            byte[] imageData = (byte[])dataSet.Tables["Information"].Rows[0][4];

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string selectQuery = "SELECT TOP(1000) [Pcode_TP]AS [کد پرسنلی],[Enter_TP]AS [ورود],[Exit_TP]AS [خروج],[Time_TP]AS [زمان],[Date_TP]AS [تاریخ] FROM[Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Pcode_TP", textBox7.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Traffic_Panel");
            connection.Close();
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CV form9 = new frm_CV();
            form9.Show();
        }
    }
}

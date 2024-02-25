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

namespace Human_resources_management
{
    public partial class frm_UserPanel : Form
    {
        string personallycode;
        public frm_UserPanel()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

         
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
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
            label9.Text = dataSet.Tables["Information"].Rows[0][2].ToString();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();

            label6.Text = DateTime.Now.ToLongDateString();
        }

        private void رزومهفردیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ترددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-MSRBBB5\\MYSQL;Initial Catalog=Shetab;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string selectQuery = "SELECT TOP(1000) [Pcode_TP]AS [کد پرسنلی],[Enter_TP]AS [ورود],[Exit_TP]AS [خروج],[Time_TP]AS [زمان],[Date_TP]AS [تاریخ] FROM[Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP";
            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Pcode_TP", label9.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Traffic_Panel");
            connection.Close();
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

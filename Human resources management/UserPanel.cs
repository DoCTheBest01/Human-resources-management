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
        string pID;
        public frm_UserPanel(string pID)
        {
            InitializeComponent();
            this.pID = pID;
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
            DataSet dataSet;
            using (var connection = SQLProvider.Connect())
            {
                string selectQuery = "SELECT TOP(1000) [FName_IN], [LName_IN], [Pcode_IN], [Incode_IN], [Picture_IN] FROM [Shetab].[dbo].[Information] WHERE Information.Pcode_IN = @Pcode_IN";
                dataSet = connection.ExecQuery(selectQuery, "Information", new Dictionary<string, object>()
                {
                    { "@Pcode_IN", this.pID }
                });
            }
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

        private void trafficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet dataSet;
            using (var connection = SQLProvider.Connect())
            {
                string selectQuery = "SELECT TOP(1000) [Pcode_TP] AS [کد پرسنلی], [Enter_TP] AS [ورود], [Exit_TP] AS [خروج], [Time_TP] AS [زمان], [Date_TP] AS [تاریخ] FROM [Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP = @Pcode_TP";
                dataSet = connection.ExecQuery(selectQuery, "Traffic_Panel", new Dictionary<string, object>()
                {
                    { "@Pcode_TP", label9.Text }
                });
            }
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

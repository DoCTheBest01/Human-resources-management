using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Human_resources_management
{
    public partial class frm_AdminPanel : Form
    {
        string pID;
        public frm_AdminPanel(string pID)
        {
            InitializeComponent();
            this.pID = pID;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void frm_AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("آیا از خارج شدن برنامه اطمینان دارید", "شتاب", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void New_Party_ToolStripMenuItem_Click(object sender, EventArgs e) // عضو جدید
        {
            grp_AddNewParty.BringToFront();
            grp_Project.SendToBack();
            grp_AdminTraffic.SendToBack();
            grp_Traffic.SendToBack();

        }

        private void Self_Traffic_ToolStripMenuItem_Click(object sender, EventArgs e) // تردد ادمین
        {
            grp_AdminTraffic.BringToFront();
            grp_Project.SendToBack();
            grp_AddNewParty.SendToBack();
            grp_Traffic.SendToBack();
            DataSet dataSet;
            using (var connection = SQLProvider.Connect())
            {
                string selectQuery = "SELECT TOP(1000) [Pcode_TP] AS [کد پرسنلی], [Enter_TP] AS [ورود], [Exit_TP] AS [خروج], [Time_TP] AS [زمان], [Date_TP] AS [تاریخ] FROM [Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP";
                dataSet = connection.ExecQuery(selectQuery, "Traffic_Panel", new Dictionary<string, object>()
                {
                    { "@Pcode_TP", label6.Text }
                });
            }
            dataGridView2.DataBindings.Clear();
            dataGridView2.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
        }

        private void Traffic_ToolStripMenuItem_Click(object sender, EventArgs e) // تردد اعضا
        {
            grp_Traffic.BringToFront();
            grp_Project.SendToBack();
            grp_AdminTraffic.SendToBack();
            grp_AddNewParty.SendToBack();
        }

        private void Project_ToolStripMenuItem_Click(object sender, EventArgs e) // پروژه
        {
            grp_Project.BringToFront();
            grp_AddNewParty.SendToBack();
            grp_AdminTraffic.SendToBack();
            grp_Traffic.SendToBack();
        }

        private void grp_Traffic_Enter(object sender, EventArgs e)
        {

        }
        private byte[] Getpicture()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox3.Image.Save(stream, pictureBox3.Image.RawFormat);
            return stream.GetBuffer();
        }
        private void btn_ChoosePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(openfiledialog.FileName);
            }
        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("نام وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("نام خانوادگی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_ICode.Text == "")
            {
                MessageBox.Show("کد ملی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_birthday.Text == "")
            {
                MessageBox.Show("تاریخ تولد وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_PCode.Text == "")
            {
                MessageBox.Show("کد پرسنلی وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_Password.Text == "")
            {
                MessageBox.Show("رمز عبور وارد نشده است!", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (pictureBox3.Image == null)
            {
                MessageBox.Show("عکس وارد نشده است", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (MessageBox.Show("آیا از ثبت داده اطمینان دارید؟", "شتاب", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                int rowsAffected;
                using (var connection = SQLProvider.Connect())
                {
                    string insertQuery = "Insert Into Information (FName_IN,LName_IN,Pcode_IN,Incode_IN,Birthday_IN,Password_IN,Picture_IN) Values (@FName_IN,@LName_IN,@Pcode_IN,@Incode_IN,@Birthday_IN,@Password_IN,@Picture_IN)";
                    string value1 = textBox1.Text;//FName
                    string value2 = textBox2.Text;//LName
                    string value3 = txt_ICode.Text;//Icode
                    string value4 = txt_birthday.Text;//Birthday
                    string value5 = txt_PCode.Text;//Pcode
                    string value6 = txt_Password.Text;//Password
                    rowsAffected = connection.ExecCommand(insertQuery, new Dictionary<string, object>()
                    {
                        { "@FName_IN", value1 },
                        { "@LName_IN", value2 },
                        { "@Pcode_IN", value5 },
                        { "@Incode_IN", value3 },
                        { "@Birthday_IN", value4 },
                        { "@Password_IN", value6 },
                        { "@Picture_IN", Getpicture() }
                    });
                }
                MessageBox.Show("داده با موفقیت ذخیره شد", "شتاب", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void frm_AdminPanel_Load(object sender, EventArgs e)
        {
            DataSet dataSet;
            using (var connection = SQLProvider.Connect())
            {
                string selectQuery = "SELECT TOP(1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Picture_IN]FROM[Shetab].[dbo].[Information]WHERE Information.Pcode_IN=@Pcode_IN";
                dataSet = connection.ExecQuery(selectQuery, "Information", new Dictionary<string, object>()
                {
                    { "@Pcode_IN", this.pID },
                });
            }
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
            DataSet dataSet;
            using (var connection = SQLProvider.Connect())
            {
                string selectQuery = "SELECT TOP(1000) [Pcode_TP]AS [کد پرسنلی],[Enter_TP]AS [ورود],[Exit_TP]AS [خروج],[Time_TP]AS [زمان],[Date_TP]AS [تاریخ] FROM[Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP";
                dataSet = connection.ExecQuery(selectQuery, "Traffic_Panel", new Dictionary<string, object>()
                {
                    { "@Pcode_TP", txt_pID.Text }
                });
            }
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataBindings.Add(new Binding("dataSource", dataSet, "Traffic_Panel"));
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CV form9 = new frm_CV();
            form9.Show();
        }
        private void btn_PrintSelfTraffic_Click(object sender, EventArgs e)
        {
            DataSet dataSet;
            using (var conn = SQLProvider.Connect())
            {
                string selectQuery = "SELECT * FROM [Shetab].[dbo].[Traffic_Panel] WHERE Traffic_Panel.Pcode_TP=@Pcode_TP ORDER BY [Time_TP] DESC;";
                dataSet = conn.ExecQuery(selectQuery, new Dictionary<string, object>()
                {
                    { "@Pcode_TP", this.pID }
                });
            }

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckPathExists)
            {
                GeneratePdf(dataSet, dialog.FileName);
            }
        }
        private void btn_PrintTraffic_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable.Copy());

            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckPathExists)
            {
                GeneratePdf(dataSet, dialog.FileName);
            }
        }
        private static void GeneratePdf(DataSet dataSet, string outputPath)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            foreach (DataTable table in dataSet.Tables)
            {
                // Add a new page for each table in the DataSet
                PdfPage page = document.AddPage();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a font and brush for drawing text
                XFont font = new XFont("Arial", 12, XFontStyle.Regular);
                XBrush brush = XBrushes.Black;

                // Draw table headers
                int y = 20;
                foreach (DataColumn column in table.Columns)
                {
                    gfx.DrawString(column.ColumnName, font, brush, 20, y);
                    y += 20;
                }

                // Draw table data
                y = 40;
                foreach (DataRow row in table.Rows)
                {
                    int x = 20;
                    foreach (DataColumn column in table.Columns)
                    {
                        gfx.DrawString(row[column].ToString(), font, brush, x, y);
                        x += 150; // You can adjust the spacing between columns here
                    }
                    y += 20;
                }
            }

            // Save the document to the specified output path
            document.Save(outputPath);

            // Close the document
            document.Close();
        }

    }
}

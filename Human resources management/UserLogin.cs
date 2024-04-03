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

namespace Human_resources_management
{
    public partial class frm_UserLogin : Form
    {
        public frm_UserLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_Pcode.Text) || String.IsNullOrEmpty(txt_Pcode.Text))
            {
                MessageBox.Show("کد پرسنلی وارد نشده است دوباره تلاش کنید", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (String.IsNullOrWhiteSpace(txt_password.Text) || String.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("رمز عبور وارد نشده است دوباره تلاش کنید", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataSet dataSet;
                using (var connection = SQLProvider.Connect())
                {
                    string selectQuery = "SELECT TOP (1000) [FName_IN],[LName_IN],[Pcode_IN],[Incode_IN],[Birthday_IN],[Password_IN],[Picture_IN]FROM[Shetab].[dbo].[Information] WHERE Information.Pcode_IN=@Pcode_IN";
                    dataSet = connection.ExecQuery(selectQuery, "Information", new Dictionary<string, object>()
                    {
                        { "@Pcode_IN", txt_Pcode.Text }
                    });
                }
                if (dataSet.Tables["Information"].Rows.Count == 1)
                {
                    if (dataSet.Tables["Information"].Rows[0][5].ToString() == txt_password.Text)
                    {
                        frm_UserPanel userPanel = new frm_UserPanel(txt_Pcode.Text);
                        userPanel.Show();
                    }
                    else
                    {
                        MessageBox.Show("رمز اشتباه است");
                    }
                }
                else
                {
                    MessageBox.Show("این کد پرسنلی وجود ندارد");
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

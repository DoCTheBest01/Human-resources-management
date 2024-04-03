using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Human_resources_management
{
    public partial class frm_Welcome : Form
    {
        public frm_Welcome()
        {
            InitializeComponent();

            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime today = DateTime.Today;
            int year = persianCalendar.GetYear(today);
            int month = persianCalendar.GetMonth(today);
            int day = persianCalendar.GetDayOfMonth(today);

            var ds = new DataSet();
            using (var connection = SQLProvider.Connect())
            {
                string users_Table = "[Shetab].[dbo].[Information]";
                string birthday_condition = "Information.Birthday_IN = @Birthday_IN";
                string sql = $"SELECT [FName_IN], [LName_IN] FROM {users_Table} WHERE {birthday_condition}";
                ds = connection.ExecQuery(sql, "Information", new Dictionary<string, object>()
                {
                    { "@Birthday_IN", $"{year}/{month}/{day}" }
                });
            }
            if (ds.Tables["Information"].Rows.Count == 1)
                lbl_birthday_notice.Text = $"امروز تولد {ds.Tables["Information"].Columns[0] + " " + ds.Tables["Information"].Columns[1]}"; // name index needed
            else
                lbl_birthday_notice.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frm_AdminLogin adminLogin = new frm_AdminLogin();
            adminLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_UserLogin UserLogin = new frm_UserLogin();
            UserLogin.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_traffic trafficForm = new frm_traffic();
            trafficForm.Show();
        }

        private void Enter_User_Load(object sender, EventArgs e)
        {

        }
    }
}

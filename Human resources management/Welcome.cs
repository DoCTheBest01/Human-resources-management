using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

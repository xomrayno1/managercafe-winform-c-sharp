using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffe
{
    public partial class MainAdmin : Form
    {
        public MainAdmin()
        {
            InitializeComponent();
           
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            if(Login.Account.Role == "ROLE_ADMIN")
            {
                this.adminToolStripMenuItem.Visible = true;
            }
            else
            {
                this.adminToolStripMenuItem.Visible = false;
                this.báoCáoToolStripMenuItem.Visible = false;
            }
            
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private void HoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrderCf order = new OrderCf();
            order.Show();
        }

        private void ĐăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
            Login login = new Login();
            this.Hide();
            Login.Account = null;
            login.Show();
            
        }

        private void ThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void BáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report rp = new Report();
            rp.Show();
        }
    }
}

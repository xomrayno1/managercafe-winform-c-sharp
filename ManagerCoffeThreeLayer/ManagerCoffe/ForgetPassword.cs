using BUS;
using DTO;
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
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
                Login login = new Login();
            login.Show();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
        public bool ValidateB()
        {
            if(string.IsNullOrEmpty(txtTk.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                return false;
            }
            return true;
        }
        private void BtnForgetPassword_Click(object sender, EventArgs e)
        {
            if (!ValidateB())
            {
                lbShow.Text = "Vui Lòng Điền Đầy Đủ";
                return;
            }
            Users user = UsersBus.GetUsersByUserNameAndEmail(txtTk.Text.Trim(), txtEmail.Text.Trim());
            if (user == null){
                lbShow.Text = "Sai Thông Tin";
                return;
            }
            lbShow.Text = "Thành Công";
            lbNameTK.Text = user.Username;
            lbMK.Text = user.Password;
            lbEmail.Text = user.Email;


        }

        private void LbNameTK_Click(object sender, EventArgs e)
        {

        }
    }
}

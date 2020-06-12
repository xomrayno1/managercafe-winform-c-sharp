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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            Users user =  Login.Account;
            lbName.Text = user.Name;
            lbUsername.Text = user.Username;
            LbEmail.Text = user.Email;
            lbRole.Text = user.Role;

        }

        private void LbUsername_Click(object sender, EventArgs e)
        {

        }
        public bool ValidateTextBox()
        {
            if(string.IsNullOrEmpty(txtPassword.Text)|| string.IsNullOrEmpty(txtPassword.Text))
            {
                return false;
            }
            return true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!ValidateTextBox())
            {
               
                lbThongBao.Text = "Vui Lòng Điền Đầy Đủ";
                return;
            }
            if (txtPassword2.Text.Trim() != txtPassword.Text.Trim())
            {
               
                lbThongBao.Text = "Mật Khẩu Nhập Lại Sai ";
                return;
            }

            try
            {
                Users user = Login.Account;
                user.Password = txtPassword2.Text;
                UsersBus.UpdateUsers(user);
                
                lbThongBao.Text = "Thành Công";
            }
            catch (Exception)
            {
               
                lbThongBao.Text = "Thất Bại";
            }
            finally
            {
                txtPassword2.Text = "";
                txtPassword.Text = "";
            }
           
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword2.UseSystemPasswordChar = false;
                return;
            }
            txtPassword2.UseSystemPasswordChar = true;
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}

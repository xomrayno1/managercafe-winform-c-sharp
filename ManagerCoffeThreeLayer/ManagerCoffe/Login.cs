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

    public partial class Login : Form
    {

        private static Users user; 

        internal static Users Account
        {
            set { user = value; }
            get { return user; }
        }
      
        public Login()
        {
            InitializeComponent();
            MaximizeBox = false;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Username = txtUsername.Text.Trim();
            users.Password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lbThongBao.Text = "Vui Lòng Nhập Đầy Đủ";
                return;
            }
            if (UsersBus.CheckUsers(users))
            {
                Account = UsersBus.GetUsersByUserName(users.Username);
                this.Hide();
                MainAdmin main = new MainAdmin();
                main.Show();
            }
            else
            {
                lbThongBao.Text = "Tài Khoản Hoặc Mật Khẩu Sai";
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LinkPasword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPassword forget = new ForgetPassword();
            this.Hide();
            forget.Show();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }

        private void OnOffPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                return;
            }
            txtPassword.UseSystemPasswordChar = true;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

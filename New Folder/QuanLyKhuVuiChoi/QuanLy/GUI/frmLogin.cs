using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLy.DAO;

namespace QuanLy.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát??", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private string usename, password;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            usename = txtUser.Text.Trim();
            password = txtPassWord.Text.Trim();
            if (Login(usename,password))
            {
                frmMain fMain = new frmMain();
                this.Hide();
                fMain.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo");
        }
        bool Login(string usename,string password)
        {
            return AccountDAO.Istance.Login(usename,password) ;
        }
        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            if (cbShowPass.CheckState == CheckState.Checked)
                txtPassWord.UseSystemPasswordChar = false;
            if (cbShowPass.CheckState == CheckState.Unchecked)
                txtPassWord.UseSystemPasswordChar = true;
        }
    }
}

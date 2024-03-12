using MCAKESHOP8;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCakeShop9
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MainClass.isValidUser(txtUser.Text, txtPass.Text))
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Hide();
                    fMain fmain = new fMain();
                    fmain.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đăng nhập: " + ex.Message, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.Focus();
                if (MainClass.isValidUser(txtUser.Text, txtPass.Text) == false)
                {
                    MessageBox.Show("Lỗi đăng nhập", "Cảnh báo đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Hide();
                    fMain fmain = new fMain();
                    fmain.Show();
                }
            }
        }

        private void txtPass_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.Focus();
                if (MainClass.isValidUser(txtUser.Text, txtPass.Text) == false)
                {
                    MessageBox.Show("Lỗi đăng nhập", "Cảnh báo đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Hide();
                    fMain fmain = new fMain();
                    fmain.Show();
                }
            }
        }
    }
}

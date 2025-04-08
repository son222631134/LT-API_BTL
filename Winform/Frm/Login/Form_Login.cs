using BTL_Prj.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Prj
{
    public partial class Form_Login : Form
    {
        public bool isFail = true;
        public string username;

        public DataTable dt;
        public Form_Login()
        {

            InitializeComponent();
        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            ProcessingData.OpenConnection();

            //Check the lastest login is not expried
            string username = Function.CheckLastLogin();
            if (username != "")
            {
                checkBox_KeepLogin.Checked = true;
                LoginSuccess(username);
            }

            //
            Prepare.setFormProperties(this);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            checkBox_KeepLogin.Text = "Keep login for " + Prepare.getTTL().ToString() + " seconds";
            txt_TaiKhoan.Focus();
            txt_MatKhau.UseSystemPasswordChar = true;

            txt_TaiKhoan.Text = "NV1";
            txt_MatKhau.Text = "123";

        }

        private void LoginSuccess(string username)
        {
            this.isFail = false;
            this.username = username;
            ProcessingData.ExecuteQuery("UPDATE Account " +
                "SET LastLogin = " + "\'" + DateTime.Now.ToString() + "\'" +
                " WHERE Username = " + "\'" + username + "\'"
                );
            this.Close();

        }
        private void validate(string username, string password)
        {
            if (username == "" || password == "")
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống!");
                return;
            }
            if (username.Contains(' ') || password.Contains(' '))
            {
                MessageBox.Show("Tài khoản và mật khẩu không được có dấu cách!");
                return;
            }
        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string username = txt_TaiKhoan.Text;
            string password = txt_MatKhau.Text;

            validate(username, password);

            this.isFail = !Function.CheckLogin(username, password);

            if (this.isFail == true)
            {
                MessageBox.Show("incorrect username or password");
                return;
            }

            //Wow, that user remember her/his account!
            LoginSuccess(username);
        }
        private void txt_TaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txt_MatKhau.Focus();
            }
        }
        private void txt_MatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_DangNhap_Click(sender, e);
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.isFail = true;
            this.Close();
            return;
            DialogResult result = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessingData.CloseConnection();
        }
    }
}

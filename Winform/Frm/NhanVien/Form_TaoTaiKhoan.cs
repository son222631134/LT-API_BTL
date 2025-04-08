using BTL_Prj.Class;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTL_Prj.Frm.NhanVien
{
    public partial class Form_TaoTaiKhoan : Form
    {
        DataTable dt;
        string MaNV;
        bool DaCoTaiKhoan = false;
        public Form_TaoTaiKhoan(string MaNV)
        {
            this.MaNV = MaNV;
            InitializeComponent();

            dt = ProcessingData.GetData("SELECT * FROM Account WHERE MaNV = \'" + MaNV + "\'");
            if (dt.Rows.Count > 0)
            {
                DaCoTaiKhoan = true;
            }
        }

        private void Form_TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            if (!DaCoTaiKhoan)
            {
                label_DaCoTaiKhoan.Hide();
                txt_taikhoan.Text = "NV" + MaNV;
            }
            else
            {
                txt_taikhoan.Text = dt.Rows[0]["Username"].ToString();
                txt_taikhoan.Enabled = false;
            }
            txt_matkhau.UseSystemPasswordChar = true;
            txt_nhaplaiMK.UseSystemPasswordChar = true;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TaoTK_Click(object sender, EventArgs e)
        {
            if (!DaCoTaiKhoan)
            {
                if (txt_taikhoan.Text == "" || txt_matkhau.Text == "" || txt_nhaplaiMK.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_matkhau.Text != txt_nhaplaiMK.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProcessingData.ExecuteQuery(
                    "INSERT INTO Account (Username, Password, MaNV, IsAdmin) VALUES " +
                    "(\'" + txt_taikhoan.Text + "\'" +
                    ",\'" + txt_matkhau.Text + "\'" +
                    ",\'" + MaNV + "\'" +
                    ",\'" + checkBox_isAdmin.Checked + "\')"
                );
                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                if ((txt_matkhau.Text == "" || txt_nhaplaiMK.Text == "") && !checkBox_isAdmin.Checked)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //ko doi mk, chi add admin
                if ((txt_matkhau.Text == "" || txt_nhaplaiMK.Text == "") && checkBox_isAdmin.Checked)
                {
                    ProcessingData.ExecuteQuery(
                        "UPDATE Account SET IsAdmin = \'" + checkBox_isAdmin.Checked + "\' WHERE MaNV = \'" + MaNV + "\'"
                    );
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                //doi mk
                if ((txt_matkhau.Text != "" || txt_nhaplaiMK.Text != "") && txt_matkhau.Text != txt_nhaplaiMK.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else
                {
                    ProcessingData.ExecuteQuery(
                        "UPDATE Account SET" +
                        " Password = \'" + txt_matkhau.Text + "\'" +
                        " , IsAdmin = \'" + checkBox_isAdmin.Checked + "\'" +
                        " WHERE MaNV = \'" + MaNV + "\'"
                    );
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using BTL_Prj.Class;
using BTL_Prj.Frm.Report.ReportKhachHang;

namespace BTL_Prj.Frm.DanhMucKhachHang
{
    public partial class frmKhachHang : Form
    {

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvKhachHang);

            LoadData();  
            SetDefaultState();  
        }

        private void LoadData()
        {
            string query = "SELECT * FROM KhachHang";
            dgvKhachHang.DataSource = ProcessingData.GetData(query);
            dgvKhachHang.Columns[0].HeaderText = "Mã KH";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableFields(true);  
            txtMaKhach.Enabled = true;  
            btnLuu.Enabled = true;  
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKhach.Text))
            {
                EnableFields(true);  
                txtMaKhach.Enabled = false; 
                btnLuu.Enabled = true;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKhach.Text))
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá khách hàng này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        ProcessingData.Delete("KhachHang", "MaKhach", txtMaKhach.Text);
                        MessageBox.Show("Dữ liệu đã được xóa!");
                        LoadData();  
                        SetDefaultState();  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Enabled)  
            {
                var columnValues = new Dictionary<string, object>
                {
                    { "MaKhach", txtMaKhach.Text },
                    { "TenKhach", txtTenKhach.Text },
                    { "DiaChi", txtDiaChi.Text },
                    { "DienThoai", txtDienThoai.Text }
                };

                try
                {
                    ProcessingData.Insert("KhachHang", columnValues);
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadData();
                    SetDefaultState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                }
            }
            else  
            {
                var columnValues = new Dictionary<string, object>
                {
                    { "TenKhach", txtTenKhach.Text },
                    { "DiaChi", txtDiaChi.Text },
                    { "DienThoai", txtDienThoai.Text }
                };

                try
                {
                    ProcessingData.Update("KhachHang", columnValues, "MaKhach", txtMaKhach.Text);
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    LoadData();
                    SetDefaultState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchValue = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                LoadData();  
                return;
            }

            string[] searchColumns = { "MaKhach", "TenKhach" };  
            dgvKhachHang.DataSource = ProcessingData.Search("KhachHang", searchColumns, searchValue);
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhach"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhach"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value.ToString();
                EnableFields(false);  
                btnLuu.Enabled = false;  
            }
        }
        private void ClearForm()
        {
            txtMaKhach.Clear();
            txtTenKhach.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
        }

        private void SetDefaultState()
        {
            ClearForm();  
            EnableFields(false);
            btnLuu.Enabled = false;  
        }

        private void EnableFields(bool isEnabled)
        {
            txtMaKhach.Enabled = isEnabled;
            txtTenKhach.Enabled = isEnabled;
            txtDiaChi.Enabled = isEnabled;
            txtDienThoai.Enabled = isEnabled;
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
                this.Close();
			return;
            DialogResult result = MessageBox.Show("Thoát?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetDefaultState();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            SetDefaultState();
            LoadData();
            txtTimKiem.Clear();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport_KhachHang report = new FormReport_KhachHang();
            report.ShowDialog();
        }
    }
}

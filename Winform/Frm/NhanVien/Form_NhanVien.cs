using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_Prj.Class;
using BTL_Prj.Frm.Report;

namespace BTL_Prj.Frm.NhanVien
{
    public partial class frmNhanVien : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvNhanVien);

            LoadData();
            LoadMaCV();
            SetFieldsState(false);
        }
        private void LoadData()
        {
            //dgvNhanVien.DataSource = ProcessingData.GetAllNhanVien();
            dgvNhanVien.DataSource = ProcessingData.NhanVien_GetAllNhanVien();
            dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            dgvNhanVien.Columns["TenNV"].HeaderText = "Tên NV";
            dgvNhanVien.Columns["MaCV"].HeaderText = "Mã CV";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
        }
        private void LoadMaCV()
        {
            cbMaCV.Items.Clear();
            DataTable dtMaCV = ProcessingData.NhanVien_GetMaCVList();
            foreach (DataRow row in dtMaCV.Rows)
            {
                cbMaCV.Items.Add(row["MaCV"].ToString());
            }
        }
        private void SetFieldsState(bool enabled)
        {
            txtMaNV.Enabled = enabled;
            txtTenNV.Enabled = enabled;
            cbMaCV.Enabled = enabled;
            chkGioiTinh.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            dtNgaySinh.Enabled = enabled;
            mtbSoDienThoai.Enabled = enabled;
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                mtbSoDienThoai.Text = row.Cells["DienThoai"].Value.ToString();
                cbMaCV.Text = row.Cells["MaCV"].Value.ToString();
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtNgaySinh.Value = ngaySinh;
                    dtNgaySinh.CustomFormat = "dd/MM/yyyy";
                }
                else
                {
                    dtNgaySinh.CustomFormat = " ";
                }
                chkGioiTinh.Checked = row.Cells["GioiTinh"].Value?.ToString() == "Nam";
                SetFieldsState(false);
            }
        }
        private void ClearTextBoxes()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            mtbSoDienThoai.Clear();
            dtNgaySinh.CustomFormat = " ";
            dtNgaySinh.Text = DateTime.Now.ToShortDateString();
            cbMaCV.SelectedIndex = -1;
            chkGioiTinh.Checked = false;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            ClearTextBoxes();
            SetFieldsState(true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên bạn muốn sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isEditing = true;
            isAdding = false;
            SetFieldsState(true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên bạn muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                ProcessingData.ExecuteQuery("DELETE FROM Account WHERE MaNV = \'" + txtMaNV.Text + "\'");
                ProcessingData.NhanVien_DeleteNhanVien(txtMaNV.Text);
                MessageBox.Show("Xóa nhân viên thành công!");
                ClearTextBoxes();
                LoadData();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                if (ValidateFields())
                {
                    ProcessingData.NhanVien_AddNhanVien(
                        txtMaNV.Text,
                        txtTenNV.Text,
                        txtDiaChi.Text,
                        ConvertPhoneNumber(mtbSoDienThoai.Text),
                        chkGioiTinh.Checked ? "Nam" : "Nữ",
                        dtNgaySinh.Value,
                        cbMaCV.SelectedItem.ToString()
                    );
                    MessageBox.Show("Thêm nhân viên thành công!");
                    isAdding = false;
                    LoadData();
                }
            }
            else if (isEditing)
            {
                if (ValidateFields())
                {
                    ProcessingData.NhanVien_UpdateNhanVien(
                        txtMaNV.Text,
                        txtTenNV.Text,
                        txtDiaChi.Text,
                        ConvertPhoneNumber(mtbSoDienThoai.Text),
                        chkGioiTinh.Checked ? "Nam" : "Nữ",
                        dtNgaySinh.Value,
                        cbMaCV.SelectedItem.ToString()
                    );
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    isEditing = false;
                    LoadData();
                }
            }
            SetFieldsState(true);
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }
            if (cbMaCV.SelectedItem == null)
            {
                MessageBox.Show("Bạn phải chọn mã công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaCV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(mtbSoDienThoai.Text) || !mtbSoDienThoai.MaskFull)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbSoDienThoai.Focus();
                return false;
            }
            if (dtNgaySinh.Text == null)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgaySinh.Focus();
                return false;
            }
            return true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchValue = txtTimKiem.Text.Trim();
            dgvNhanVien.DataSource = ProcessingData.NhanVien_SearchNhanVien(searchValue);
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên nhân viên để tìm kiếm.", "Thông báo");
                return;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            txtMaNV.Focus();
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            isEditing = false;
            ClearTextBoxes();
            SetFieldsState(false);
        }
        public static string ConvertPhoneNumber(string phoneNumber)
        {
            string result = "";
            foreach (char c in phoneNumber)
            {
                if (char.IsDigit(c))
                {
                    result += c;
                }
            }
            return result;
        }
        private void button8_Click(object sender, EventArgs e)
        {
                Dispose();
			return;
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Dispose();
            }   
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport_NhanVien report = new FormReport_NhanVien();
            report.ShowDialog();
        }

        private void btn_TaoTK_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn cần chọn nhân viên để tạo tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form_TaoTaiKhoan frm = new Form_TaoTaiKhoan(txtMaNV.Text);
            frm.ShowDialog();
        }
    }
}

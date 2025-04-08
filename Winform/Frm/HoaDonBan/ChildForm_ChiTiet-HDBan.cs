using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using BTL_Prj.Class;
using BTL_Prj.Frm.Report.ReportChiTietHoaDonBan;

namespace BTL_Prj.Frm.HoaDonBan
{
    public partial class ChildfrmChiTietHoaDonBan : Form
    {
        private int soHDB;

        public ChildfrmChiTietHoaDonBan(int soHDB)
        {
            InitializeComponent();
            this.soHDB = soHDB;
        }
        private void ChildfrmChiTietHoaDonBan_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvChiTietHoaDonBan);

            LoadDataGridView();
            LoadMaHang();
            cboMaHang.Enabled = false;
            txtTenHang.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            SetFieldsState(false);
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            txtSoLuong.Leave += txtSoLuong_Leave;
            txtGiamGia.Leave += txtGiamGia_Leave;
            dgvChiTietHoaDonBan.CellDoubleClick += dgvChiTietHoaDonBan_CellDoubleClick;
            dgvChiTietHoaDonBan.CellClick += dgvChiTietHoaDonBan_CellClick;

            txt_MaHoaDon.Text = soHDB.ToString();
            CapNhatTongTien();
        }

        private void SetFieldsState(bool enabled)
        {
            btnClearCT.Enabled = enabled;
            btnHuy.Enabled = enabled;
            txtSoLuong.Enabled = enabled;
            txtGiamGia.Enabled = enabled;
        }
        private void LoadDataGridView()
        {
            try
            {
                string query = "SELECT * FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB";
                var parameters = new Dictionary<string, object> { { "@SoHDB", soHDB } };
                DataTable dt = ProcessingData.GetData(query, parameters);
                dgvChiTietHoaDonBan.DataSource = dt;

                dgvChiTietHoaDonBan.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0";

                dgvChiTietHoaDonBan.Columns["SoHDB"].HeaderText = "Số HDB";
                dgvChiTietHoaDonBan.Columns["MaHang"].HeaderText = "Mã hàng";
                dgvChiTietHoaDonBan.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvChiTietHoaDonBan.Columns["GiamGia"].HeaderText = "Giảm giá";
                dgvChiTietHoaDonBan.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ThemThongTinHDVaoCDSL()
        {
            try
            {
                //Kiem tra co du so luong ko
                var check = new Dictionary<string, object>
                {
                    {"@MaHang", int.Parse(cboMaHang.Text) }

                };
                DataTable dt = ProcessingData.GetData("SELECT SoLuong From DMHangHoa WHERE MaHang = @MaHang", check);
                if (int.Parse(dt.Rows[0]["SoLuong"].ToString()) < int.Parse(txtSoLuong.Text))
                {
                    MessageBox.Show("Số lượng mặt hàng nhập nhiều hơn số lượng đang có");
                    return;
                }
                int prev_SoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());

                // Truy vấn để kiểm tra sự tồn tại của hàng hóa trong hóa đơn
                string checkQuery = "SELECT * FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB AND MaHang = @MaHang";
                var checkParams = new Dictionary<string, object>
                {
                    { "@SoHDB", soHDB },
                    { "@MaHang", int.Parse(cboMaHang.Text) }
                };

                // Lấy dữ liệu từ cơ sở dữ liệu
                dt = ProcessingData.GetData(checkQuery, checkParams);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã hàng đã tồn tại trong hóa đơn. Vui lòng chọn mã hàng khác.", "Thông báo");
                    return;
                }

                // Thực hiện thêm thông tin vào cơ sở dữ liệu
                string query = "INSERT INTO ChiTietHoaDonBan (SoHDB, MaHang, SoLuong, GiamGia, ThanhTien) VALUES (@SoHDB, @MaHang, @SoLuong, @GiamGia, @ThanhTien)";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDB", soHDB },
                    { "@MaHang", int.Parse(cboMaHang.Text) },
                    { "@SoLuong", int.Parse(txtSoLuong.Text) },
                    { "@GiamGia", decimal.Parse(txtGiamGia.Text) },
                    { "@ThanhTien", decimal.Parse(txtThanhTien.Text) }
                };
                ProcessingData.ExecuteQuery(query, parameters);
                //tru SLHH
                parameters = new Dictionary<string, object>
                {
                    { "@SoLuong", prev_SoLuong -  int.Parse(txtSoLuong.Text) },
                    { "@MaHang", int.Parse(cboMaHang.Text) }
                };
                ProcessingData.ExecuteQuery("UPDATE DMHangHoa SET SoLuong = @SoLuong Where MaHang = @MaHang",parameters);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm: " + e.Message);
            }
        }
        private void ResetValues()
        {
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtTenHang.Text = "";
            txtGiamGia.Text = "0";
            txtDonGiaBan.Text = "";
            txtThanhTien.Text = "0";
        }
        private void LoadMaHang()
        {
            try
            {
                string query = "SELECT MaHang FROM DMHangHoa";
                DataTable dt = ProcessingData.GetData(query);
                foreach (DataRow row in dt.Rows)
                {
                    cboMaHang.Items.Add(row["MaHang"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã hàng: " + ex.Message);
            }
        }
        private void DeleteMatHang(string maHang)
        {
            try
            {
                string query = "DELETE FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB AND MaHang = @MaHang";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDB", soHDB },
                    { "@MaHang", int.Parse(maHang) }
                };
                ProcessingData.ExecuteQuery(query, parameters);
                MessageBox.Show("Xóa mặt hàng thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa mặt hàng: " + ex.Message);
            }
        }
        private void GetTenHang(string maHang)
        {
            try
            {
                string query = "SELECT TenHang FROM DMHangHoa WHERE MaHang = @MaHang";
                var parameters = new Dictionary<string, object> { { "@MaHang", maHang } };
                DataTable dt = ProcessingData.GetData(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtTenHang.Text = dt.Rows[0]["TenHang"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên hàng: " + ex.Message);
            }
        }
        private void GetHangHoa(string maHang)
        {
            try
            {
                string query = "SELECT TenHang, DonGiaBan FROM DMHangHoa WHERE MaHang = @MaHang";
                var parameters = new Dictionary<string, object> { { "@MaHang", maHang } };
                DataTable dt = ProcessingData.GetData(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    txtTenHang.Text = dt.Rows[0]["TenHang"].ToString();
                    txtDonGiaBan.Text = dt.Rows[0]["DonGiaBan"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy hàng: " + ex.Message);
            }
        }
        private void GetDonGiaBan(string maHang)
        {
            try
            {
                string query = "SELECT DonGiaBan FROM DMHangHoa WHERE MaHang = @MaHang";
                var parameters = new Dictionary<string, object> { { "@MaHang", maHang } };
                DataTable dt = ProcessingData.GetData(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtDonGiaBan.Text = dt.Rows[0]["DonGiaBan"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn giá bán: " + ex.Message);
            }
        }
        private void ChinhSuaThongTinHang()
        {
            try
            {
                string query = "UPDATE ChiTietHoaDonBan SET SoLuong = @SoLuong, GiamGia = @GiamGia, ThanhTien = @ThanhTien WHERE SoHDB = @SoHDB AND MaHang = @MaHang";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDB", soHDB },
                    { "@MaHang", int.Parse(cboMaHang.Text) },
                    { "@SoLuong", int.Parse(txtSoLuong.Text) },
                    { "@GiamGia", decimal.Parse(txtGiamGia.Text) },
                    { "@ThanhTien", decimal.Parse(txtThanhTien.Text) }
                };
                ProcessingData.ExecuteQuery(query, parameters);
                MessageBox.Show("Chỉnh sửa thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chỉnh sửa mặt hàng: " + ex.Message);
            }
        }

        private void CalculateThanhTien()
        {
            if (!string.IsNullOrEmpty(txtSoLuong.Text) && !string.IsNullOrEmpty(txtDonGiaBan.Text))
            {
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGiaBan.Text, out decimal donGia))
                {
                    decimal thanhTien = soLuong * donGia;

                    if (!string.IsNullOrEmpty(txtGiamGia.Text) && decimal.TryParse(txtGiamGia.Text, out decimal giamGia))
                    {
                        thanhTien -= thanhTien * (giamGia / 100);
                    }

                    txtThanhTien.Text = thanhTien.ToString();
                }
                else
                {
                    txtThanhTien.Text = "0";
                }
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }
        private void CapNhatTongTien()
        {
            frmHoaDonBan.CapNhatTongTien(soHDB);

            DataTable dt = ProcessingData.GetData("select TongTien from HoaDonBan where SoHDB = @SoHDB", new Dictionary<string, object> { { "@SoHDB", soHDB } });
            decimal tongTien = decimal.Parse(dt.Rows[0]["TongTien"].ToString());
            txtTongTien.Text = tongTien.ToString();
        }
        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cboMaHang.Enabled = true;
            btnThem.Enabled = false;
            btnChinhSua.Enabled = true;
            
            ResetValues();
            SetFieldsState(true);
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang trong chế độ thêm, vui lòng hoàn tất thêm hoặc hủy thao tác trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cboMaHang.Text) || string.IsNullOrEmpty(txtSoLuong.Text) ||
            string.IsNullOrEmpty(txtDonGiaBan.Text) || string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvChiTietHoaDonBan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SetFieldsState(true);
                btnChinhSua.Enabled = false;
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
            this.Close();
            return;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            cboMaHang.Enabled = false;
            if (btnThem.Enabled == false)
            {            
                ThemThongTinHDVaoCDSL();
                ResetValues();
                SetFieldsState(false);
                LoadDataGridView();
                btnThem.Enabled = true;
            }
            if (btnChinhSua.Enabled == false)
            {
                ChinhSuaThongTinHang();
                ResetValues();
                SetFieldsState(false);
                LoadDataGridView();
                btnChinhSua.Enabled = true;
            }
            CapNhatTongTien();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            cboMaHang.Enabled = false;
            SetFieldsState(false);
            btnThem.Enabled = true;
            btnChinhSua.Enabled = true;
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHang.SelectedItem != null)
            {
                string selectedMaHang = cboMaHang.SelectedItem.ToString();
                GetHangHoa(selectedMaHang);
                CalculateThanhTien();
            }
        }
        private void dgvChiTietHoaDonBan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTietHoaDonBan.RowCount - 1) return;

            {
                string maHang = dgvChiTietHoaDonBan.Rows[e.RowIndex].Cells["MaHang"].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteMatHang(maHang);
                    LoadDataGridView();
                    ResetValues();
                    SetFieldsState(false);
                    btnThem.Enabled = true;
                    btnChinhSua.Enabled = true;
                }
            }
        }
        private void dgvChiTietHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTietHoaDonBan.RowCount - 1) return;
            
            {
                DataGridViewRow row = dgvChiTietHoaDonBan.Rows[e.RowIndex];

                cboMaHang.Text = row.Cells["MaHang"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
                txtGiamGia.Text = row.Cells["GiamGia"].Value.ToString();

                cboMaHang.Enabled = false;
                SetFieldsState(false);
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;

                GetTenHang(cboMaHang.Text);
                GetDonGiaBan(cboMaHang.Text);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport_ChiTietHDB report = new FormReport_ChiTietHDB(soHDB);
            report.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMaHang.Text) ||
                string.IsNullOrEmpty(txtTenHang.Text) ||
                string.IsNullOrEmpty(txtThanhTien.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text) ||
                string.IsNullOrEmpty(txtGiamGia.Text) ||
                string.IsNullOrEmpty(txtDonGiaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maHang = dgvChiTietHoaDonBan.CurrentRow.Cells["MaHang"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteMatHang(maHang);
                LoadDataGridView();
                ResetValues();
                CapNhatTongTien();
                SetFieldsState(false);
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
            }
        }
    }
}

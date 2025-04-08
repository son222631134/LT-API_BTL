using BTL_Prj.Class;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace BTL_Prj.Frm.HoaDonNhap
{
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }
        private void FrmThongTinHDNhap_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvHoaDonNhap);

            btnChiTiet.Enabled = false;
            btnInHD.Enabled = false;
            btnXoa.Enabled = false;
            SetFieldsState(false);
            LoadDataToGridView();
            LoadMaNhanVien();
            LoadMaNhaCungCap();
            dgvHoaDonNhap.CellClick += dtgrvHDN_CellClick;
            tabControl1.TabPages.Remove(tabPage_ChiTietHoaDon);
            
        }
        private void SetFieldsState(bool enabled)
        {
            btnLuu.Enabled = enabled;
            btnHuy.Enabled = enabled;
            txtMaHDN.Enabled = enabled;
            dtpNgayNhap.Enabled = enabled;
            cboMaNV.Enabled = enabled;
            txtTenNV.Enabled = enabled;
            cboMaNCC.Enabled = enabled;
            txtTenNCC.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtDienThoai.Enabled = enabled;
        }
        private void ResetValues()
        {
            txtMaHDN.Text = "";
            dtpNgayNhap.Text = DateTime.Now.ToShortDateString();
            cboMaNV.Text = "";
            txtTenNV.Text = "";
            cboMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTongTien.Text = "0";
        }
        private void ThemHoaDonVaoCDSL()
        {
            if (string.IsNullOrEmpty(txtMaHDN.Text) ||
                string.IsNullOrEmpty(cboMaNV.Text) ||
                string.IsNullOrEmpty(cboMaNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var columnValues = new Dictionary<string, object>
                {
                    {"SoHDN", int.Parse(txtMaHDN.Text)},
                    {"MaNV", int.Parse(cboMaNV.Text)},
                    {"MaNCC", int.Parse(cboMaNCC.Text)},
                    {"NgayNhap", dtpNgayNhap.Value}
                };
                ProcessingData.Insert("HoaDonNhap", columnValues);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm: " + e.Message);
            }
            finally
            {
                LoadDataToGridView();
            }
        }
        private void LoadDataToGridView()
        {
            DataTable dt = ProcessingData.GetData("SELECT * FROM HoaDonNhap");
            dgvHoaDonNhap.DataSource = dt;

            dgvHoaDonNhap.Columns["TongTien"].DefaultCellStyle.Format = "#,##0";

            dgvHoaDonNhap.Columns["SoHDN"].HeaderText = "Số hóa đơn";
            dgvHoaDonNhap.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvHoaDonNhap.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
            dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvHoaDonNhap.Columns["TongTien"].HeaderText = "Tổng tiền";

        }
        private void LoadMaNhanVien()
        {
            try
            {
                DataTable dt = ProcessingData.GetData("SELECT MaNV FROM NhanVien");
                foreach (DataRow row in dt.Rows)
                {
                    cboMaNV.Items.Add(row["MaNV"].ToString());
                    cboMaNVLoc.Items.Add(row["MaNV"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã nhân viên: " + ex.Message);
            }
        }
        private void GetTenNhanVien(string maNV)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNV", maNV }
                };
                DataTable dt = ProcessingData.GetData("SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV", parameters);
                if (dt.Rows.Count > 0)
                {
                    txtTenNV.Text = dt.Rows[0]["TenNV"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên nhân viên: " + ex.Message);
            }
        }
        private void LoadMaNhaCungCap()
        {
            try
            {
                DataTable dt = ProcessingData.GetData("SELECT MaNCC FROM NhaCungCap");
                foreach (DataRow row in dt.Rows)
                {
                    cboMaNCC.Items.Add(row["MaNCC"].ToString());
                    cboMaNCCLoc.Items.Add(row["MaNCC"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã nhà cung cấp: " + ex.Message);
            }
        }
        private void GetThongTinNCC(string maNCC)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@MaNCC", maNCC }
                };
                DataTable dt = ProcessingData.GetData("SELECT TenNCC, DiaChi, DienThoai FROM NhaCungCap WHERE MaNCC = @MaNCC", parameters);
                if (dt.Rows.Count > 0)
                {
                    txtTenNCC.Text = dt.Rows[0]["TenNCC"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }
        private void SwitchToChiTiet(string soHDN)
        {
            // Hiển thị tab Chi tiết hóa đơn nhập
            if (tabControl1.TabPages.Contains(tabPage_ChiTietHoaDon))
            {
                tabControl1.TabPages.Remove(tabPage_ChiTietHoaDon);
            }
            tabPage_ChiTietHoaDon = new TabPage();
            tabPage_ChiTietHoaDon.Text = "Chi Tiết";
            tabControl1.TabPages.Add(tabPage_ChiTietHoaDon);
            ChildfrmChiTietHDNhap chiTietForm = new ChildfrmChiTietHDNhap(soHDN);
            chiTietForm.FormClosed += (s, args) => CapNhatTongTien(int.Parse(soHDN));
            chiTietForm.FormClosed += (s, args) => LoadDataToGridView();
            tabControl1.SelectedTab = tabPage_ChiTietHoaDon;
            chiTietForm.TopLevel = false;
            chiTietForm.Dock = DockStyle.Fill;
            tabPage_ChiTietHoaDon.Controls.Clear();
            tabPage_ChiTietHoaDon.Controls.Add(chiTietForm);
            tabPage_ChiTietHoaDon.Tag = chiTietForm;
            chiTietForm.BringToFront();
            chiTietForm.Show();
            chiTietForm.FormBorderStyle = FormBorderStyle.None;
        }
        private void InHoaDonRaExcel()
        {
            if (dgvHoaDonNhap.CurrentRow == null || string.IsNullOrEmpty(txtMaHDN.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in.");
                return;
            }

            int soHDN = Convert.ToInt32(dgvHoaDonNhap.CurrentRow.Cells["SoHDN"].Value);
            string maNV = dgvHoaDonNhap.CurrentRow.Cells["MaNV"].Value.ToString();
            string maNCC = dgvHoaDonNhap.CurrentRow.Cells["MaNCC"].Value.ToString();
            DateTime ngayNhap = Convert.ToDateTime(dgvHoaDonNhap.CurrentRow.Cells["NgayNhap"].Value);
            decimal tongTien = Convert.ToDecimal(dgvHoaDonNhap.CurrentRow.Cells["TongTien"].Value);

            // Khởi tạo ExcelPackage
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("HoaDon");

                // Thông tin hóa đơn
                workSheet.Cells[1, 1].Value = "Số hóa đơn:";
                workSheet.Cells[1, 2].Value = soHDN;
                workSheet.Cells[2, 1].Value = "Mã nhân viên:";
                workSheet.Cells[2, 2].Value = maNV;
                workSheet.Cells[3, 1].Value = "Mã nhà cung cấp:";
                workSheet.Cells[3, 2].Value = maNCC;
                workSheet.Cells[4, 1].Value = "Ngày nhập:";
                workSheet.Cells[4, 2].Value = ngayNhap.ToShortDateString();
                workSheet.Cells[5, 1].Value = "Tổng tiền:";
                workSheet.Cells[5, 2].Value = tongTien;

                // Tiêu đề bảng chi tiết hóa đơn
                workSheet.Cells[7, 1].Value = "Mã sản phẩm";
                workSheet.Cells[7, 2].Value = "Tên sản phẩm";
                workSheet.Cells[7, 3].Value = "Đơn giá bán";
                workSheet.Cells[7, 4].Value = "Số lượng";
                workSheet.Cells[7, 5].Value = "Giảm giá";
                workSheet.Cells[7, 6].Value = "Thành tiền";

                // Lấy dữ liệu chi tiết hóa đơn
                try
                {
                    string query = "SELECT cthdn.MaHang, hh.TenHang, hh.DonGiaBan, cthdn.SoLuong, cthdn.GiamGia, cthdn.ThanhTien " +
                                   "FROM ChiTietHoaDonNhap cthdn JOIN DMHangHoa hh ON cthdn.MaHang = hh.MaHang " +
                                   "WHERE SoHDN = @SoHDN";
                    var parameters = new Dictionary<string, object>
            {
                { "@SoHDN", soHDN }
            };
                    DataTable dtChiTiet = ProcessingData.GetData(query, parameters);

                    // Ghi dữ liệu vào Excel
                    int rowStart = 8; // Bắt đầu ghi từ hàng thứ 8
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        workSheet.Cells[rowStart, 1].Value = row["MaHang"].ToString();
                        workSheet.Cells[rowStart, 2].Value = row["TenHang"].ToString();
                        workSheet.Cells[rowStart, 3].Value = Convert.ToDecimal(row["DonGiaBan"]);
                        workSheet.Cells[rowStart, 4].Value = Convert.ToInt32(row["SoLuong"]);
                        workSheet.Cells[rowStart, 5].Value = Convert.ToDecimal(row["GiamGia"]);
                        workSheet.Cells[rowStart, 6].Value = Convert.ToDecimal(row["ThanhTien"]);
                        rowStart++;
                    }

                    // Lưu file Excel
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Lưu hóa đơn ra file Excel"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        excel.SaveAs(file);
                        MessageBox.Show("In hóa đơn ra Excel thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message);
                }
            }
        }
        private void TBHDN_TextChanged(object sender, EventArgs e)
        {

        }
        private void CBBMNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedItem != null)
            {
                string selectedMaNV = cboMaNV.SelectedItem.ToString();
                GetTenNhanVien(selectedMaNV);
            }
        }
        private void CBBNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.SelectedItem != null)
            {
                string selectedMaKH = cboMaNCC.SelectedItem.ToString();
                GetThongTinNCC(selectedMaKH);
            }
        }
        private void DatetimeNC_ValueChanged(object sender, EventArgs e)
        {

        }
        private void ClearBT_Click(object sender, EventArgs e)
        {
            if (btnSua.Enabled == false)
            {
                MessageBox.Show("Vui lòng hoàn thành chỉnh sửa hoặc hủy để xem chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHoaDonNhap.CurrentRow == null || string.IsNullOrEmpty(txtMaHDN.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in.");
            }
            else
            {
                InHoaDonRaExcel();
            }
        }
        private void Chitiethoadon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHDN.Text) ||
                string.IsNullOrEmpty(cboMaNV.Text) ||
                string.IsNullOrEmpty(txtTenNV.Text) ||
                string.IsNullOrEmpty(cboMaNCC.Text) ||
                string.IsNullOrEmpty(txtTenNCC.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnSua.Enabled == false)
            {
                MessageBox.Show("Vui lòng hoàn thành chỉnh sửa hoặc hủy để xem chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHoaDonNhap.CurrentRow != null)
            {
                int soHDN = Convert.ToInt32(dgvHoaDonNhap.CurrentRow.Cells["SoHDN"].Value);
                SwitchToChiTiet(soHDN.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.");
            }
        }

        private void THEM_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            SetFieldsState(true);
            ResetValues();
        }
        private void SUA_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang trong chế độ thêm, vui lòng hoàn tất thêm hoặc hủy thao tác trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaHDN.Text) ||
                string.IsNullOrEmpty(cboMaNV.Text) ||
                string.IsNullOrEmpty(txtTenNV.Text) ||
                string.IsNullOrEmpty(cboMaNCC.Text) ||
                string.IsNullOrEmpty(txtTenNCC.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (dgvHoaDonNhap.CurrentRow == null) return;

            btnSua.Enabled = false;
            SetFieldsState(true);
            txtMaHDN.Enabled = false;
        }
        private void XOA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHDN.Text) ||
                string.IsNullOrEmpty(cboMaNV.Text) ||
                string.IsNullOrEmpty(txtTenNV.Text) ||
                string.IsNullOrEmpty(cboMaNCC.Text) ||
                string.IsNullOrEmpty(txtTenNCC.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int soHDN = Convert.ToInt32(dgvHoaDonNhap.CurrentRow.Cells["SoHDN"].Value);
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ProcessingData.Delete("HoaDonNhap", "SoHDN", soHDN);
                LoadDataToGridView();
                ResetValues();
                SetFieldsState(false);
            }
        }
        private void THoat_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đóng?", "Xác nhận đóng", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void dtgrvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetFieldsState(false);
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (e.RowIndex < 0 || e.RowIndex >= dgvHoaDonNhap.RowCount - 1) return;

            btnChiTiet.Enabled = true;
            btnInHD.Enabled = true;

            DataGridViewRow row = dgvHoaDonNhap.Rows[e.RowIndex];
            txtMaHDN.Text = row.Cells["SoHDN"].Value.ToString();
            cboMaNV.Text = row.Cells["MaNV"].Value.ToString();
            cboMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
            txtTongTien.Text = row.Cells["TongTien"].Value.ToString();

            GetTenNhanVien(cboMaNV.Text);
            GetThongTinNCC(cboMaNCC.Text);
        }
        private void CapNhatHoaDon()
        {
            if (dgvHoaDonNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soHDN = Convert.ToInt32(dgvHoaDonNhap.CurrentRow.Cells["SoHDN"].Value);

            // Kiểm tra xem các trường cần thiết đã được nhập đầy đủ chưa
            if (string.IsNullOrEmpty(txtMaHDN.Text) ||
                string.IsNullOrEmpty(cboMaNV.Text) ||
                string.IsNullOrEmpty(cboMaNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi cập nhật hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var columnValues = new Dictionary<string, object>
                {
                    {"MaNV", int.Parse(cboMaNV.Text)},
                    {"MaNCC", int.Parse(cboMaNCC.Text)},
                    {"NgayNhap", dtpNgayNhap.Value}
                };

                // Cập nhật hóa đơn trong cơ sở dữ liệu
                ProcessingData.Update("HoaDonNhap", columnValues, "SoHDN", soHDN);
                MessageBox.Show("Cập nhật hóa đơn thành công.");

                // Cập nhật tổng tiền nếu cần
                CapNhatTongTien(soHDN);
                LoadDataToGridView(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
        }
        public static void CapNhatTongTien(int soHDN)
        {
            try
            {
                // Tính tổng tiền từ chi tiết hóa đơn
                string query = "SELECT SUM(ThanhTien) AS TongTien FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDN", soHDN }
                };

                DataTable dt = ProcessingData.GetData(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    decimal tongTien = dt.Rows[0]["TongTien"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TongTien"]) : 0;

                    // Cập nhật tổng tiền vào hóa đơn
                    var updateValues = new Dictionary<string, object>
                    {
                        { "TongTien", tongTien }
                    };

                    // Gọi phương thức Update tổng quát
                    ProcessingData.Update("HoaDonNhap", updateValues, "SoHDN", soHDN);
                    //MessageBox.Show(tongTien.ToString());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message);
            }
        }
        private void LocHoaDon()
        {
            string query = "SELECT * FROM HoaDonNhap WHERE 1=1";
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(cboMaNVLoc.Text))
            {
                query += " AND MaNV = @MaNV";
                parameters.Add("@MaNV", cboMaNVLoc.Text);
            }

            if (!string.IsNullOrEmpty(cboMaNCCLoc.Text))
            {
                query += " AND MaNCC = @MaNCC";
                parameters.Add("@MaNCC", cboMaNCCLoc.Text);
            }

            try
            {
                DataTable dt = ProcessingData.GetData(query, parameters);
                dgvHoaDonNhap.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
//<<<<<<< RepairImgDir
            //TBHDN.Enabled = false;
            //if (e.RowIndex < 0 || e.RowIndex >= dgvHoaDonNhap.RowCount - 1) return;
            //// Hiển thị dữ liệu từ hàng đã chọn lên các TextBox và ComboBox
            ////if (e.RowIndex >= 0)
//=======
            if (btnThem.Enabled == false)
//>>>>>>> master
            {
                string lastMaHDN = txtMaHDN.Text;
                ThemHoaDonVaoCDSL();
                ResetValues();
                SetFieldsState(false);
                LoadDataToGridView();
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnChiTiet.Enabled = false;
                btnInHD.Enabled = false;
                SwitchToChiTiet(lastMaHDN);
            }
            if (btnSua.Enabled == false)
            {
                CapNhatHoaDon();
                ResetValues();
                SetFieldsState(false);
                LoadDataToGridView();
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnChiTiet.Enabled = false;
                btnInHD.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnChiTiet.Enabled = false;
            btnInHD.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            SetFieldsState(false);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void btnHuyLoc_Click(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_ThongTinChung)
            {
                LoadDataToGridView();
            }
        }
    }
}

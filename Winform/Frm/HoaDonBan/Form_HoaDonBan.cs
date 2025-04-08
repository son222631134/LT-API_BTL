using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using OfficeOpenXml;
using System.IO;
using System.Reflection;
using BTL_Prj.Class;

namespace BTL_Prj.Frm.HoaDonBan
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvHDBanHang);

            btnChiTiet.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnXoa.Enabled = false;
            DisablePointer();
            SetFieldsState(false);
            LoadDataGridView();
            LoadMaNhanVien();
            LoadMaKhachHang();
            dgvHDBanHang.CellClick += dgvHDBanHang_CellClick;
            //dgvHDBanHang.CellDoubleClick += dgvHDBanHang_CellDoubleClick;
            tabControl1.TabPages.Remove(tabPage_ChiTietHoaDon);
        }

        private void ThemHoaDonVaoCDSL()
        {
            if (string.IsNullOrEmpty(txtMaHDBan.Text) ||
                string.IsNullOrEmpty(cboMaNhanVien.Text) ||
                string.IsNullOrEmpty(cboMaKhach.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi thêm hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var columnValues = new Dictionary<string, object>
                {
                    {"SoHDB", int.Parse(txtMaHDBan.Text)},
                    {"MaNV", int.Parse(cboMaNhanVien.Text)},
                    {"MaKhach", int.Parse(cboMaKhach.Text)},
                    {"NgayBan", dtpNgayBan.Value}
                };
                ProcessingData.Insert("HoaDonBan", columnValues);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm: " + e.Message);
            }
            finally
            {
                LoadDataGridView();
            }
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTongTien.Text = "0";
        }
        private void LoadMaNhanVien()
        {
            try
            {
                DataTable dt = ProcessingData.GetData("SELECT MaNV FROM NhanVien");
                foreach (DataRow row in dt.Rows)
                {
                    cboMaNhanVien.Items.Add(row["MaNV"].ToString());
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
                    txtTenNhanVien.Text = dt.Rows[0]["TenNV"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên nhân viên: " + ex.Message);
            }
        }
        private void LoadMaKhachHang()
        {
            try
            {
                DataTable dt = ProcessingData.GetData("SELECT MaKhach FROM KhachHang");
                foreach (DataRow row in dt.Rows)
                {
                    cboMaKhach.Items.Add(row["MaKhach"].ToString());
                    cboMaKHLoc.Items.Add(row["MaKhach"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã khách hàng: " + ex.Message);
            }
        }
        private void GetThongTinKhachHang(string maKH)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@MaKH", maKH }
                };
                DataTable dt = ProcessingData.GetData("SELECT TenKhach, DiaChi, DienThoai FROM KhachHang WHERE MaKhach = @MaKH", parameters);
                if (dt.Rows.Count > 0)
                {
                    txtTenKhach.Text = dt.Rows[0]["TenKhach"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
        }
        private void InHoaDonRaExcel()
        {
            if (dgvHDBanHang.CurrentRow == null || string.IsNullOrEmpty(txtMaHDBan.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in.");
                return;
            }

            int soHDB = Convert.ToInt32(dgvHDBanHang.CurrentRow.Cells["SoHDB"].Value);
            string maNV = dgvHDBanHang.CurrentRow.Cells["MaNV"].Value.ToString();
            string maKhach = dgvHDBanHang.CurrentRow.Cells["MaKhach"].Value.ToString();
            DateTime ngayBan = Convert.ToDateTime(dgvHDBanHang.CurrentRow.Cells["NgayBan"].Value);
            decimal tongTien = Convert.ToDecimal(dgvHDBanHang.CurrentRow.Cells["TongTien"].Value);

            // Khởi tạo ExcelPackage
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("HoaDon");

                // Thông tin hóa đơn
                workSheet.Cells[1, 1].Value = "Số hóa đơn:";
                workSheet.Cells[1, 2].Value = soHDB;
                workSheet.Cells[2, 1].Value = "Mã nhân viên:";
                workSheet.Cells[2, 2].Value = maNV;
                workSheet.Cells[3, 1].Value = "Mã khách hàng:";
                workSheet.Cells[3, 2].Value = maKhach;
                workSheet.Cells[4, 1].Value = "Ngày bán:";
                workSheet.Cells[4, 2].Value = ngayBan.ToShortDateString();
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
                    string query = "SELECT cthdb.MaHang, hh.TenHang, hh.DonGiaBan, cthdb.SoLuong, cthdb.GiamGia, cthdb.ThanhTien " +
                                   "FROM ChiTietHoaDonBan cthdb JOIN DMHangHoa hh ON cthdb.MaHang = hh.MaHang " +
                                   "WHERE SoHDB = @SoHDB";
                    var parameters = new Dictionary<string, object>
            {
                { "@SoHDB", soHDB }
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
        private void CapNhatHoaDon()
        {
            if (dgvHDBanHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soHDB = Convert.ToInt32(dgvHDBanHang.CurrentRow.Cells["SoHDB"].Value);

            // Kiểm tra xem các trường cần thiết đã được nhập đầy đủ chưa
            if (string.IsNullOrEmpty(txtMaHDBan.Text) ||
                string.IsNullOrEmpty(cboMaNhanVien.Text) ||
                string.IsNullOrEmpty(cboMaKhach.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi cập nhật hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var columnValues = new Dictionary<string, object>
                {
                    {"MaNV", int.Parse(cboMaNhanVien.Text)},
                    {"MaKhach", int.Parse(cboMaKhach.Text)},
                    {"NgayBan", dtpNgayBan.Value}
                };

                // Cập nhật hóa đơn trong cơ sở dữ liệu
                ProcessingData.Update("HoaDonBan", columnValues, "SoHDB", soHDB);
                MessageBox.Show("Cập nhật hóa đơn thành công.");

                // Cập nhật tổng tiền nếu cần
                CapNhatTongTien(soHDB);
                LoadDataGridView(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
        }
        public static void CapNhatTongTien(int soHDB)
        {
            try
            {
                // Tính tổng tiền từ chi tiết hóa đơn
                string query = "SELECT SUM(ThanhTien) AS TongTien FROM ChiTietHoaDonBan WHERE SoHDB = @SoHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDB", soHDB }
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
                    ProcessingData.Update("HoaDonBan", updateValues, "SoHDB", soHDB);
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
            string query = "SELECT * FROM HoaDonBan WHERE 1=1";
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(cboMaNVLoc.Text))
            {
                query += " AND MaNV = @MaNV";
                parameters.Add("@MaNV", cboMaNVLoc.Text);
            }

            if (!string.IsNullOrEmpty(cboMaKHLoc.Text))
            {
                query += " AND MaKhach = @MaKhach";
                parameters.Add("@MaKhach", cboMaKHLoc.Text);
            }

            try
            {
                DataTable dt = ProcessingData.GetData(query, parameters);
                dgvHDBanHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc: " + ex.Message);
            }
        }
        private void SetFieldsState(bool enabled)
        {
            btnClear.Enabled = enabled;
            btnHuy.Enabled = enabled;
            txtMaHDBan.Enabled = enabled;
            dtpNgayBan.Enabled = enabled;
            cboMaNhanVien.Enabled = enabled;
            txtTenNhanVien.Enabled = enabled;
            cboMaKhach.Enabled = enabled;
            txtTenKhach.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
            txtDienThoai.Enabled = enabled;
        }
        private void LoadDataGridView()
        {
            DataTable dt = ProcessingData.GetData("SELECT * FROM HoaDonBan");
            dgvHDBanHang.DataSource = dt;
            dgvHDBanHang.Columns["TongTien"].DefaultCellStyle.Format = "#,##0";

            dgvHDBanHang.Columns["SoHDB"].HeaderText = "Số HĐB";
            dgvHDBanHang.Columns["MaNV"].HeaderText = "Mã NV";
            dgvHDBanHang.Columns["MaKhach"].HeaderText = "Mã KH";
            dgvHDBanHang.Columns["NgayBan"].HeaderText = "Ngày bán";
            dgvHDBanHang.Columns["TongTien"].HeaderText = "Tổng tiền";

        }
        private void DisablePointer()
        {
            dgvHDBanHang.ClearSelection();

            txtMaHDBan.TabStop = false;
            cboMaNhanVien.TabStop = false;
            cboMaKhach.TabStop = false;
            dtpNgayBan.TabStop = false;

            this.ActiveControl = null;
        }
        private void SwitchToChiTiet(int soHDB)
        {
            if (tabControl1.TabPages.Contains(tabPage_ChiTietHoaDon))
            {
                tabControl1.TabPages.Remove(tabPage_ChiTietHoaDon);
            }
            tabPage_ChiTietHoaDon = new TabPage();
            tabPage_ChiTietHoaDon.Text = "Chi Tiết";
            tabControl1.TabPages.Add(tabPage_ChiTietHoaDon);

            //frmChiTietHoaDonBan chiTietForm = new frmChiTietHoaDonBan(soHDB);
            ChildfrmChiTietHoaDonBan chiTietForm = new ChildfrmChiTietHoaDonBan(soHDB);
            chiTietForm.FormClosed += (s, args) => CapNhatTongTien(soHDB);
            chiTietForm.FormClosed += (s, args) => LoadDataGridView();
            //chiTietForm.ShowDialog();
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
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
            SetFieldsState(true);
            ResetValues();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang trong chế độ thêm, vui lòng hoàn tất thêm hoặc hủy thao tác trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaHDBan.Text) ||
                string.IsNullOrEmpty(cboMaNhanVien.Text) ||
                string.IsNullOrEmpty(txtTenNhanVien.Text) ||
                string.IsNullOrEmpty(cboMaKhach.Text) ||
                string.IsNullOrEmpty(txtTenKhach.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (dgvHDBanHang.CurrentRow == null) return;

            btnCapNhat.Enabled = false;
            SetFieldsState(true);
            txtMaHDBan.Enabled = false;
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHDBan.Text) ||
                string.IsNullOrEmpty(cboMaNhanVien.Text) ||
                string.IsNullOrEmpty(txtTenNhanVien.Text) ||
                string.IsNullOrEmpty(cboMaKhach.Text) ||
                string.IsNullOrEmpty(txtTenKhach.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (btnCapNhat.Enabled == false)
            {
                MessageBox.Show("Vui lòng hoàn thành chỉnh sửa hoặc hủy để xem chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHDBanHang.CurrentRow != null)
            {
                int soHDB = Convert.ToInt32(dgvHDBanHang.CurrentRow.Cells["SoHDB"].Value);
                SwitchToChiTiet(soHDB);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.");
            }
        }
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Enabled == false)
            {
                MessageBox.Show("Vui lòng hoàn thành chỉnh sửa hoặc hủy để xem chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvHDBanHang.CurrentRow == null || string.IsNullOrEmpty(txtMaHDBan.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để in.");
            }
            else
            {
                InHoaDonRaExcel();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
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
            if (btnThem.Enabled == false)
            {
                int lastMaHDBan = int.Parse(txtMaHDBan.Text);
                ThemHoaDonVaoCDSL();
                ResetValues();
                SetFieldsState(false);
                LoadDataGridView();
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnChiTiet.Enabled = false;
                btnInHoaDon.Enabled = false;
                SwitchToChiTiet(lastMaHDBan);
            }
            if (btnCapNhat.Enabled == false)
            {
                CapNhatHoaDon();
                ResetValues();
                SetFieldsState(false);
                LoadDataGridView();
                btnThem.Enabled = true;
                btnCapNhat.Enabled = true;
                btnChiTiet.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            btnChiTiet.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnClear.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            SetFieldsState(false);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LocHoaDon();
        }
        private void btnHuyLoc_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.SelectedItem != null)
            {
                string selectedMaNV = cboMaNhanVien.SelectedItem.ToString();
                GetTenNhanVien(selectedMaNV);
            }
        }
        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKhach.SelectedItem != null)
            {
                string selectedMaKH = cboMaKhach.SelectedItem.ToString();
                GetThongTinKhachHang(selectedMaKH);
            }
        }

        //private void dgvHDBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.RowIndex >= dgvHDBanHang.RowCount - 1) return;

        //    int soHDB = Convert.ToInt32(dgvHDBanHang.Rows[e.RowIndex].Cells["SoHDB"].Value);
        //    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        ProcessingData.Delete("HoaDonBan", "SoHDB", soHDB);
        //        LoadDataGridView();
        //    }
        //}
        private void dgvHDBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetFieldsState(false);
            btnThem.Enabled = true;
            btnCapNhat.Enabled = true;
            if (e.RowIndex < 0 || e.RowIndex >= dgvHDBanHang.RowCount -1) return;

            btnChiTiet.Enabled = true;
            btnInHoaDon.Enabled = true;
            btnXoa.Enabled = true;

            DataGridViewRow row = dgvHDBanHang.Rows[e.RowIndex];
            txtMaHDBan.Text = row.Cells["SoHDB"].Value.ToString();
            cboMaNhanVien.Text = row.Cells["MaNV"].Value.ToString();
            cboMaKhach.Text = row.Cells["MaKhach"].Value.ToString();
            dtpNgayBan.Value = Convert.ToDateTime(row.Cells["NgayBan"].Value);
            txtTongTien.Text = row.Cells["TongTien"].Value.ToString();

            GetTenNhanVien(cboMaNhanVien.Text);
            GetThongTinKhachHang(cboMaKhach.Text);
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHDBan.Text) ||
                string.IsNullOrEmpty(cboMaNhanVien.Text) ||
                string.IsNullOrEmpty(txtTenNhanVien.Text) ||
                string.IsNullOrEmpty(cboMaKhach.Text) ||
                string.IsNullOrEmpty(txtTenKhach.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int soHDB = Convert.ToInt32(dgvHDBanHang.CurrentRow.Cells["SoHDB"].Value);
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ProcessingData.Delete("HoaDonBan", "SoHDB", soHDB);
                LoadDataGridView();
                ResetValues();
                SetFieldsState(false);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_ThongTinChung)
            {
                LoadDataGridView();
            }
        }
    }
}
    
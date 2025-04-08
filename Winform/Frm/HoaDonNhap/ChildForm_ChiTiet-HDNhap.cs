using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using BTL_Prj.Class;
using BTL_Prj.Frm.Report.ReportChiTietHoaDonNhap;
using BTL_Prj.Frm.HoaDonBan;

namespace BTL_Prj.Frm.HoaDonNhap
{
    public partial class ChildfrmChiTietHDNhap : Form
    {
        private string selectedSoHDN; // Biến lưu số hóa đơn được chọn từ Form
        public ChildfrmChiTietHDNhap()
        {
            InitializeComponent();
        }
        public ChildfrmChiTietHDNhap(string soHDN)
        {
            InitializeComponent();
            this.selectedSoHDN = soHDN;
        }
        private void SetFieldsState(bool enabled)
        {
            btnLuu.Enabled = enabled;
            btnHuy.Enabled = enabled;
            TBSOLUONG.Enabled = enabled;
            TBGIAMGIA.Enabled = enabled;
        }
        private void ChildfrmChiTietHDNhap_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            Prepare.setDgvProperties(dgvChiTietHoaDonNhap);

            LoadDataToGridView();
            LoadMaHang();
            CBBMAHANG.Enabled = false;
            txtTenHang.Enabled = false;
            TBDONGIA.Enabled = false;
            txtThanhTien.Enabled = false;
            SetFieldsState(false);
            CBBMAHANG.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            TBSOLUONG.Leave += txtSoLuong_Leave;
            TBGIAMGIA.Leave += txtGiamGia_Leave;
            //dgvChiTietHoaDonNhap.CellDoubleClick += dgvChiTietHoaDonBan_CellDoubleClick;
            dgvChiTietHoaDonNhap.CellClick += dtgrvFORM2_CellClick;

            SoHDNTB.Text = selectedSoHDN.ToString();
            CapNhatTongTien();
        }
        private void LoadDataToGridView()
        {
            try
            {
                string query = "SELECT SoHDN,MaHang,SoLuong,GiamGia,ThanhTien FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN";
                var parameters = new Dictionary<string, object> { { "@SoHDN", selectedSoHDN } };
                DataTable dt = ProcessingData.GetData(query, parameters);
                dgvChiTietHoaDonNhap.DataSource = dt;
                dgvChiTietHoaDonNhap.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0";

                dgvChiTietHoaDonNhap.Columns["SOHDN"].HeaderText = "Số HĐN";
                dgvChiTietHoaDonNhap.Columns["MaHang"].HeaderText = "Mã Hàng";
                dgvChiTietHoaDonNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvChiTietHoaDonNhap.Columns["GiamGia"].HeaderText = "Giảm Giá";
                dgvChiTietHoaDonNhap.Columns["ThanhTien"].HeaderText = "Thành Tiền";
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
                var check = new Dictionary<string, object>
                {
                    {"@MaHang", int.Parse(CBBMAHANG.Text) }

                };
                DataTable dt = ProcessingData.GetData("SELECT SoLuong From DMHangHoa WHERE MaHang = @MaHang", check);
                
                int prev_SoLuong = int.Parse(dt.Rows[0]["SoLuong"].ToString());


                // Truy vấn để kiểm tra sự tồn tại của hàng hóa trong hóa đơn
                string checkQuery = "SELECT * FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN AND MaHang = @MaHang";
                var checkParams = new Dictionary<string, object>
                {
                    { "@SoHDN", selectedSoHDN },
                    { "@MaHang", int.Parse(CBBMAHANG.Text) }
                };

                // Lấy dữ liệu từ cơ sở dữ liệu
                 dt = ProcessingData.GetData(checkQuery, checkParams);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã hàng đã tồn tại trong hóa đơn. Vui lòng chọn mã hàng khác.", "Thông báo");
                    return;
                }

                // Thực hiện thêm thông tin vào cơ sở dữ liệu
                string query = "INSERT INTO ChiTietHoaDonNhap (SoHDN, MaHang, SoLuong, GiamGia, ThanhTien) VALUES (@SoHDN, @MaHang, @SoLuong, @GiamGia, @ThanhTien)";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDN", selectedSoHDN },
                    { "@MaHang", int.Parse(CBBMAHANG.Text) },
                    { "@SoLuong", int.Parse(TBSOLUONG.Text) },
                    { "@GiamGia", decimal.Parse(TBGIAMGIA.Text) },
                    { "@ThanhTien", decimal.Parse(txtThanhTien.Text) }
                };
                ProcessingData.ExecuteQuery("UPDATE DMHangHoa SET SoLuong = @SoLuong WHERE MaHang = @MaHang", new Dictionary<string, object> { { "@SoLuong", prev_SoLuong + int.Parse(TBSOLUONG.Text) }, { "@MaHang", int.Parse(CBBMAHANG.Text) } });
                ProcessingData.ExecuteQuery(query, parameters);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi thêm: " + e.Message);
            }
        }
        //private void LoadComboBoxData()
        //{
        //    // Load mã hàng vào ComboBox CBBMAHANG
        //    DataTable dtMaHang = ProcessingData.GetComboBoxData("DMHangHoa", "MaHang", "MaHang"); // Lấy dữ liệu từ bảng DMHangHoa
        //    CBBMAHANG.DataSource = dtMaHang;
        //    CBBMAHANG.DisplayMember = "MaHang"; // Hiển thị mã hàng trong ComboBox
        //    CBBMAHANG.ValueMember = "MaHang"; // Giá trị tương ứng với mã hàng
        //    CBBMAHANG.SelectedIndex = -1; // Không chọn giá trị mặc định
        //}
        private void ClearFields()
        {
            // Xóa các trường đầu vào
            CBBMAHANG.Text = "";
            TBSOLUONG.Text = "";
            txtTenHang.Text = "";
            TBGIAMGIA.Text = "0";
            TBDONGIA.Text = "";
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
                    CBBMAHANG.Items.Add(row["MaHang"].ToString());
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
                string query = "DELETE FROM ChiTietHoaDonNhap WHERE SoHDN = @SoHDN AND MaHang = @MaHang";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDN", selectedSoHDN },
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
                    TBDONGIA.Text = dt.Rows[0]["DonGiaBan"].ToString();
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
                    TBDONGIA.Text = dt.Rows[0]["DonGiaBan"].ToString();
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
                string query = "UPDATE ChiTietHoaDonNhap SET SoLuong = @SoLuong, GiamGia = @GiamGia, ThanhTien = @ThanhTien WHERE SoHDN = @SoHDN AND MaHang = @MaHang";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDN", selectedSoHDN },
                    { "@MaHang", int.Parse(CBBMAHANG.Text) },
                    { "@SoLuong", int.Parse(TBSOLUONG.Text) },
                    { "@GiamGia", decimal.Parse(TBGIAMGIA.Text) },
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
            if (!string.IsNullOrEmpty(TBSOLUONG.Text) && !string.IsNullOrEmpty(TBDONGIA.Text))
            {
                if (int.TryParse(TBSOLUONG.Text, out int soLuong) && decimal.TryParse(TBDONGIA.Text, out decimal donGia))
                {
                    decimal thanhTien = soLuong * donGia;

                    if (!string.IsNullOrEmpty(TBGIAMGIA.Text) && decimal.TryParse(TBGIAMGIA.Text, out decimal giamGia))
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
            frmHoaDonNhap.CapNhatTongTien(int.Parse(selectedSoHDN));

            DataTable dt = ProcessingData.GetData("select TongTien from HoaDonNhap where SoHDN = @SoHDN", new Dictionary<string, object> { { "@SoHDN", selectedSoHDN } });
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
        private void BTADDCTHDN_Click(object sender, EventArgs e)
        {
            CBBMAHANG.Enabled = true;
            BTADDCTHDN.Enabled = false;
            BTSUA.Enabled = true;

            ClearFields();
            SetFieldsState(true);
        }
        private void BTSUA_Click(object sender, EventArgs e)
        {
            if (BTADDCTHDN.Enabled == false)
            {
                MessageBox.Show("Đang trong chế độ thêm, vui lòng hoàn tất thêm hoặc hủy thao tác trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(CBBMAHANG.Text) || string.IsNullOrEmpty(TBSOLUONG.Text) ||
            string.IsNullOrEmpty(TBDONGIA.Text) || string.IsNullOrEmpty(TBGIAMGIA.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvChiTietHoaDonNhap.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SetFieldsState(true);
                BTSUA.Enabled = false;
            }
        }
        private void BTDELETE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CBBMAHANG.Text) ||
                string.IsNullOrEmpty(txtTenHang.Text) ||
                string.IsNullOrEmpty(txtThanhTien.Text) ||
                string.IsNullOrEmpty(TBSOLUONG.Text) ||
                string.IsNullOrEmpty(TBGIAMGIA.Text) ||
                string.IsNullOrEmpty(TBDONGIA.Text))
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maHang = dgvChiTietHoaDonNhap.CurrentRow.Cells["MaHang"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteMatHang(maHang);
                LoadDataToGridView();
                ClearFields();
                CapNhatTongTien();
                SetFieldsState(false);
                BTADDCTHDN.Enabled = true;
                BTSUA.Enabled = true;
            }
        }
        private void ExitForm2_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
            this.Close();
			return;
        }
        private void dtgrvFORM2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTietHoaDonNhap.RowCount - 1) return;

            {
                DataGridViewRow row = dgvChiTietHoaDonNhap.Rows[e.RowIndex];

                CBBMAHANG.Text = row.Cells["MaHang"].Value.ToString();
                TBSOLUONG.Text = row.Cells["SoLuong"].Value.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
                TBGIAMGIA.Text = row.Cells["GiamGia"].Value.ToString();

                CBBMAHANG.Enabled = false;
                SetFieldsState(false);
                BTADDCTHDN.Enabled = true;
                BTSUA.Enabled = true;

                GetTenHang(CBBMAHANG.Text);
                GetDonGiaBan(CBBMAHANG.Text);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport_ChiTietHDN report = new FormReport_ChiTietHDN(selectedSoHDN);
            report.ShowDialog();
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBBMAHANG.SelectedItem != null)
            {
                string selectedMaHang = CBBMAHANG.SelectedItem.ToString();
                GetHangHoa(selectedMaHang);
                CalculateThanhTien();
            }
        }
        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CBBMAHANG.Enabled = false;
            if (BTADDCTHDN.Enabled == false)
            {
                ThemThongTinHDVaoCDSL();
                ClearFields();
                SetFieldsState(false);
                LoadDataToGridView();
                BTADDCTHDN.Enabled = true;
            }
            if (BTSUA.Enabled == false)
            {
                ChinhSuaThongTinHang();
                ClearFields();
                SetFieldsState(false);
                LoadDataToGridView();
                BTSUA.Enabled = true;
            }
            CapNhatTongTien();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            ClearFields();
            CBBMAHANG.Enabled = false;
            SetFieldsState(false);
            BTADDCTHDN.Enabled = true;
            BTSUA.Enabled = true;
        }
    }
}

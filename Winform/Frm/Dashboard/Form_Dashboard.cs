using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BTL_Prj.Class;

namespace BTL_Prj.Frm.Dashboard
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            Prepare.setDgvProperties(dgvLastestOrder);

            LoadMonthlyRevenueChart();
            LoadMonthlyExpense();
            DisplayProfitOrLoss();  
            LoadLastestOrderTable();
            LoadChartTonKho();
            LoadDataKho();
            LoadDataKhach();
            LoadDataNV();
        }

        void LoadLastestOrderTable()
        {
            string query = @"
        SELECT * 
        FROM HoaDonBan
        WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, GETDATE())";
            dgvLastestOrder.DataSource = ProcessingData.GetData(query);
        }

        void LoadChartTonKho()
        {
            chart_tonkho.Series.Clear();
            Series series = chart_tonkho.Series.Add("Số lượng hàng tồn kho");
            series.ChartType = SeriesChartType.Bar;
            chart_tonkho.ChartAreas[0].AxisX.Interval = 1;

            string query = @"SELECT TenHang, SoLuong FROM DMHangHoa where SoLuong > 0";
            chart_tonkho.DataSource = ProcessingData.GetData(query);
            series.XValueMember = "TenHang";
            series.YValueMembers = "SoLuong";
        }

        void LoadMonthlyRevenueChart()
        {
            chartDoanhthuthang.Series.Clear();
            Series series = chartDoanhthuthang.Series.Add("Doanh thu 2024");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Blue;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = Color.Red;
            series.IsValueShownAsLabel = true;

            string query = "SELECT \r\n    MONTH(NgayBan) AS Month,\r\n    SUM(TongTien) AS TotalRevenue\r\nFROM \r\n    HoaDonBan\r\nWHERE \r\n    YEAR(NgayBan) = YEAR(GETDATE())\r\nGROUP BY \r\n    YEAR(NgayBan), MONTH(NgayBan)\r\nORDER BY \r\n\tMonth;";
            chartDoanhthuthang.DataSource = ProcessingData.GetData(query);
            series.XValueMember = "Month";
            series.YValueMembers = "TotalRevenue";
        }

        void LoadMonthlyExpense()
        {
            chartChiTheoThang.Series.Clear();
            Series series = chartChiTheoThang.Series.Add("Chi phí 2024");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Color = Color.Aquamarine;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = Color.Red;
            series.IsValueShownAsLabel = true;

            string query = "SELECT \r\n    YEAR(NgayNhap) AS Year,\r\n    MONTH(NgayNhap) AS Month,\r\n    SUM(TongTien) AS TotalExpenses\r\nFROM \r\n    HoaDonNhap\r\nWHERE \r\n    YEAR(NgayNhap) = YEAR(GETDATE())\r\nGROUP BY \r\n    YEAR(NgayNhap), MONTH(NgayNhap)\r\nORDER BY \r\n    Year, Month;";
            chartChiTheoThang.DataSource = ProcessingData.GetData(query);
            series.XValueMember = "Month";
            series.YValueMembers = "TotalExpenses";
        }

        void LoadDataKho()
        {
            
            string query = "SELECT SUM(ISNULL(SoLuong, 0)) AS tong FROM DMHangHoa;";
            DataTable dataTable = ProcessingData.GetData(query);

            if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["tong"] != DBNull.Value)
            {
                int soLuongTonKho = Convert.ToInt32(dataTable.Rows[0]["tong"]);
                labelDataTonKho.Text = $"{soLuongTonKho} Mặt hàng";
            }
            else
            {
                labelDataTonKho.Text = "0 Mặt hàng";
            }


        }

        void LoadDataKhach()
        {
            string query = @"
        SELECT COUNT(DISTINCT MaKhach) AS SoKhach
        FROM HoaDonBan
        WHERE MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE());";

            DataTable dataTable = ProcessingData.GetData(query);

            if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["SoKhach"] != DBNull.Value)
            {
                int soKhach = Convert.ToInt32(dataTable.Rows[0]["SoKhach"]);
                labelDataSoKhach.Text = $"{soKhach} Khách hàng";
            }
            else
            {
                labelDataSoKhach.Text = "0 Khách hàng";
            }
        }

        void LoadDataNV()
        {
            string queryNhanVienUuTu = @"
                            SELECT TOP 1 NhanVien.MaNV, NhanVien.TenNV, COUNT(HoaDonBan.SoHDB) AS SoHoaDon
                            FROM HoaDonBan
                            JOIN NhanVien ON HoaDonBan.MaNV = NhanVien.MaNV
                            GROUP BY NhanVien.MaNV, NhanVien.TenNV
                            ORDER BY SoHoaDon DESC;";
            DataTable nhanVienTable = ProcessingData.GetData(queryNhanVienUuTu);
            if (nhanVienTable.Rows.Count > 0)
            {
                string tenNV = nhanVienTable.Rows[0]["TenNV"].ToString();
                string soHoaDon = nhanVienTable.Rows[0]["SoHoaDon"].ToString();
                labelNhanVienMVP.Text = $"{tenNV} ({soHoaDon} hóa đơn)";
            }
            else
            {
                labelNhanVienMVP.Text = "Không có dữ liệu";
            }
        }


        private void DisplayProfitOrLoss()
        {
            decimal chiTieu = 0;
            decimal doanhThu = 0;
           
            string query1 = "SELECT SUM(TongTien) AS TongChi FROM HoaDonNhap";
            string query2 = "SELECT SUM(TongTien) AS TongThu FROM HoaDonBan";

            {
                SqlCommand command = new SqlCommand(query1, ProcessingData.SqlConnection);
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    chiTieu = reader.GetDecimal(reader.GetOrdinal("TongChi"));
                }

                reader.Close();
            }

            
            {
                SqlCommand command = new SqlCommand(query2, ProcessingData.SqlConnection);
                
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    doanhThu = reader.GetDecimal(reader.GetOrdinal("TongThu"));
                }
                reader.Close();
            }

            decimal ketQua = doanhThu - chiTieu;
            
           labelDataDoanhThu.Text = ketQua.ToString("#,##0");
        }
        private void FrmDashboard_SizeChanged(object sender, EventArgs e)
        {
          //  panel_ChiTieu.Width = panel_DoanhThu.Width = this.Width / 2;
           // chart_chitieu.Size = chart_doanhthu.Size = new Size(panel_ChiTieu.Width * 2 / 3, panel_ChiTieu.Height * 2 / 3);
           // chart_chitieu.Location = chart_doanhthu.Location = new Point(panel_ChiTieu.Width / 2 - chart_chitieu.Width / 2,
                                                                      //      panel_ChiTieu.Height / 2 - chart_chitieu.Height / 2);
            //label_chitieu.Width = label_doanhthu.Width = this.Width / 2;
        }

        private void chart_doanhthu_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}

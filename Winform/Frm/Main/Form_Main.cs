using BTL_Prj.Class;
using BTL_Prj.Frm.DanhMucHangHoa;
using BTL_Prj.Frm.DanhMucKhachHang;
using BTL_Prj.Frm.Dashboard;
using BTL_Prj.Frm.HoaDonBan;
using BTL_Prj.Frm.HoaDonNhap;
using BTL_Prj.Frm.NhanVien;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static OfficeOpenXml.ExcelErrorValue;

namespace BTL_Prj.Frm.Main
{
    public partial class frmMain : Form
    {
        string username;
        string name;
        bool UserIsAdmin;
        bool UserKeepLogin;
        public bool isReload = false;
        public frmMain()
        {
            Form_Login frmLogin = new Form_Login();
            frmLogin.ShowDialog();
            if (frmLogin.isFail)
            {
                ProcessingData.CloseConnection();
                this.Close();
            }
            DataTable dt = ProcessingData.GetData(
                "SELECT * FROM Account" +
                " WHERE Username = \'" + frmLogin.username + "\'"
                );
            username = frmLogin.username;
            UserIsAdmin = bool.Parse(dt.Rows[0]["IsAdmin"].ToString());
            name = username.ToLower()=="admin" ? "Admin" : ProcessingData.GetData("SELECT * FROM NhanVien WHERE MaNV = \'" + dt.Rows[0]["MaNV"] + "\'").Rows[0]["TenNV"].ToString();
            UserKeepLogin = frmLogin.checkBox_KeepLogin.Checked;

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Backend
            ProcessingData.OpenConnection();

            //Frontend
            txt_warning.Hide();
            Prepare.setFormProperties(this);
            this.FormBorderStyle = FormBorderStyle.Sizable;

            lb_username.Text = "Hello, " + name;
            lb_username.TextAlign = ContentAlignment.MiddleCenter;

            if (!UserIsAdmin)
            {
                btn_menu_NhanVien.Enabled = false;
                btn_menu_NhanVien.Hide();
            }

            openChildForm(new FrmDashboard());
            ActivateButton(btn_Dashboard);

        }

        // xử lí mở form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panel_childForm.Controls.Add(childForm);
            panel_childForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //childForm.BringToFront();
            //childForm.Show();
            childForm.FormBorderStyle = FormBorderStyle.None;
        }

        private Button currentButton;
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4169E1");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panel_LeftBar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(0, 0, 64);
                    previousBtn.ForeColor = Color.Gainsboro;
                }
            }
        }
        public void btn_Dashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new FrmDashboard());

        }
        private void btn_menu_HangHoa_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmDanhMucHangHoa());
        }
        private void btn_menu_HDBan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmHoaDonBan());
        }
        private void btn_menu_HDNhap_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmHoaDonNhap());
        }
        private void btn_menu_KhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            openChildForm(new frmKhachHang());
        }
        private void btn_menu_NhanVien_Click(object sender, EventArgs e)
        {
            if (!UserIsAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào mục này!");
                return;
            }
            ActivateButton(sender);
            openChildForm(new frmNhanVien());
        }
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isReload = true;
                Close();
            }
        }
        private void btn_menu_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
                isReload = false;
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Function.Logout(username, UserKeepLogin && !isReload);
            ProcessingData.CloseConnection();
        }

    }
}

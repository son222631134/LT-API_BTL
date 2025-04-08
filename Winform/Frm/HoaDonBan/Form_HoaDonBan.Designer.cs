namespace BTL_Prj.Frm.HoaDonBan
{
    partial class frmHoaDonBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_title = new System.Windows.Forms.Label();
            this.panel_title = new System.Windows.Forms.Panel();
            this.tabPage_ChiTietHoaDon = new System.Windows.Forms.TabPage();
            this.tabPage_ThongTinChung = new System.Windows.Forms.TabPage();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnInHoaDon = new System.Windows.Forms.Button();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.panel_Input = new System.Windows.Forms.Panel();
            this.panel_TimKIem = new System.Windows.Forms.Panel();
            this.cboMaNVLoc = new System.Windows.Forms.ComboBox();
            this.cboMaKHLoc = new System.Windows.Forms.ComboBox();
            this.btnHuyLoc = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayBan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMaKhach = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTenKhach = new System.Windows.Forms.TextBox();
            this.txtMaHDBan = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvHDBanHang = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel_title.SuspendLayout();
            this.tabPage_ThongTinChung.SuspendLayout();
            this.panel_button.SuspendLayout();
            this.panel_Input.SuspendLayout();
            this.panel_TimKIem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBanHang)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_title.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(954, 80);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "HÓA ĐƠN BÁN HÀNG";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_title
            // 
            this.panel_title.Controls.Add(this.label_title);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(954, 80);
            this.panel_title.TabIndex = 10;
            // 
            // tabPage_ChiTietHoaDon
            // 
            this.tabPage_ChiTietHoaDon.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_ChiTietHoaDon.Location = new System.Drawing.Point(4, 4);
            this.tabPage_ChiTietHoaDon.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage_ChiTietHoaDon.Name = "tabPage_ChiTietHoaDon";
            this.tabPage_ChiTietHoaDon.Size = new System.Drawing.Size(946, 589);
            this.tabPage_ChiTietHoaDon.TabIndex = 2;
            this.tabPage_ChiTietHoaDon.Text = "Chi Tiết Hóa Đơn";
            // 
            // tabPage_ThongTinChung
            // 
            this.tabPage_ThongTinChung.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_ThongTinChung.Controls.Add(this.panel_button);
            this.tabPage_ThongTinChung.Controls.Add(this.panel_Input);
            this.tabPage_ThongTinChung.Controls.Add(this.txtTongTien);
            this.tabPage_ThongTinChung.Controls.Add(this.label16);
            this.tabPage_ThongTinChung.Controls.Add(this.dgvHDBanHang);
            this.tabPage_ThongTinChung.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.tabPage_ThongTinChung.Location = new System.Drawing.Point(4, 4);
            this.tabPage_ThongTinChung.Name = "tabPage_ThongTinChung";
            this.tabPage_ThongTinChung.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ThongTinChung.Size = new System.Drawing.Size(946, 589);
            this.tabPage_ThongTinChung.TabIndex = 0;
            this.tabPage_ThongTinChung.Text = "Thông Tin Chung";
            // 
            // panel_button
            // 
            this.panel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_button.Controls.Add(this.btnXoa);
            this.panel_button.Controls.Add(this.btnThem);
            this.panel_button.Controls.Add(this.btnDong);
            this.panel_button.Controls.Add(this.btnCapNhat);
            this.panel_button.Controls.Add(this.btnInHoaDon);
            this.panel_button.Controls.Add(this.btnChiTiet);
            this.panel_button.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.panel_button.Location = new System.Drawing.Point(3, 526);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(940, 60);
            this.panel_button.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThem.Location = new System.Drawing.Point(19, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(126, 40);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm hóa đơn";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDong.Location = new System.Drawing.Point(786, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(126, 40);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnCapNhat.Location = new System.Drawing.Point(173, 10);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(126, 40);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật hóa đơn";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnInHoaDon
            // 
            this.btnInHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnInHoaDon.Location = new System.Drawing.Point(632, 10);
            this.btnInHoaDon.Name = "btnInHoaDon";
            this.btnInHoaDon.Size = new System.Drawing.Size(126, 40);
            this.btnInHoaDon.TabIndex = 8;
            this.btnInHoaDon.Text = "In hóa đơn";
            this.btnInHoaDon.UseVisualStyleBackColor = true;
            this.btnInHoaDon.Click += new System.EventHandler(this.btnInHoaDon_Click);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnChiTiet.Location = new System.Drawing.Point(476, 10);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(126, 40);
            this.btnChiTiet.TabIndex = 8;
            this.btnChiTiet.Text = "Chi tiết hóa đơn";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // panel_Input
            // 
            this.panel_Input.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_Input.Controls.Add(this.panel_TimKIem);
            this.panel_Input.Controls.Add(this.btnHuy);
            this.panel_Input.Controls.Add(this.label2);
            this.panel_Input.Controls.Add(this.btnClear);
            this.panel_Input.Controls.Add(this.label6);
            this.panel_Input.Controls.Add(this.dtpNgayBan);
            this.panel_Input.Controls.Add(this.label3);
            this.panel_Input.Controls.Add(this.cboMaKhach);
            this.panel_Input.Controls.Add(this.label7);
            this.panel_Input.Controls.Add(this.cboMaNhanVien);
            this.panel_Input.Controls.Add(this.label4);
            this.panel_Input.Controls.Add(this.txtTenNhanVien);
            this.panel_Input.Controls.Add(this.label8);
            this.panel_Input.Controls.Add(this.txtDienThoai);
            this.panel_Input.Controls.Add(this.label5);
            this.panel_Input.Controls.Add(this.txtDiaChi);
            this.panel_Input.Controls.Add(this.label9);
            this.panel_Input.Controls.Add(this.txtTenKhach);
            this.panel_Input.Controls.Add(this.txtMaHDBan);
            this.panel_Input.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.panel_Input.Location = new System.Drawing.Point(3, 3);
            this.panel_Input.Name = "panel_Input";
            this.panel_Input.Size = new System.Drawing.Size(940, 195);
            this.panel_Input.TabIndex = 8;
            // 
            // panel_TimKIem
            // 
            this.panel_TimKIem.Controls.Add(this.cboMaNVLoc);
            this.panel_TimKIem.Controls.Add(this.cboMaKHLoc);
            this.panel_TimKIem.Controls.Add(this.btnHuyLoc);
            this.panel_TimKIem.Controls.Add(this.label18);
            this.panel_TimKIem.Controls.Add(this.label10);
            this.panel_TimKIem.Controls.Add(this.btnLoc);
            this.panel_TimKIem.Controls.Add(this.label11);
            this.panel_TimKIem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_TimKIem.Location = new System.Drawing.Point(0, 158);
            this.panel_TimKIem.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TimKIem.Name = "panel_TimKIem";
            this.panel_TimKIem.Size = new System.Drawing.Size(940, 37);
            this.panel_TimKIem.TabIndex = 10;
            // 
            // cboMaNVLoc
            // 
            this.cboMaNVLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaNVLoc.FormattingEnabled = true;
            this.cboMaNVLoc.Location = new System.Drawing.Point(205, 6);
            this.cboMaNVLoc.Name = "cboMaNVLoc";
            this.cboMaNVLoc.Size = new System.Drawing.Size(163, 27);
            this.cboMaNVLoc.TabIndex = 4;
            // 
            // cboMaKHLoc
            // 
            this.cboMaKHLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaKHLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaKHLoc.FormattingEnabled = true;
            this.cboMaKHLoc.Location = new System.Drawing.Point(515, 6);
            this.cboMaKHLoc.Name = "cboMaKHLoc";
            this.cboMaKHLoc.Size = new System.Drawing.Size(180, 27);
            this.cboMaKHLoc.TabIndex = 4;
            // 
            // btnHuyLoc
            // 
            this.btnHuyLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHuyLoc.Location = new System.Drawing.Point(850, 5);
            this.btnHuyLoc.Name = "btnHuyLoc";
            this.btnHuyLoc.Size = new System.Drawing.Size(74, 28);
            this.btnHuyLoc.TabIndex = 8;
            this.btnHuyLoc.Text = "Hủy lọc";
            this.btnHuyLoc.UseVisualStyleBackColor = true;
            this.btnHuyLoc.Click += new System.EventHandler(this.btnHuyLoc_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label18.Location = new System.Drawing.Point(101, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 19);
            this.label18.TabIndex = 3;
            this.label18.Text = "Mã Nhân Viên";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10.Location = new System.Drawing.Point(400, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "Mã Khách Hàng";
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnLoc.Location = new System.Drawing.Point(755, 5);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(77, 28);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(31, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "Lọc:";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHuy.Location = new System.Drawing.Point(787, 97);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(18, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnClear.Location = new System.Drawing.Point(787, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 40);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Lưu";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.Location = new System.Drawing.Point(395, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã khách hàng";
            // 
            // dtpNgayBan
            // 
            this.dtpNgayBan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpNgayBan.Location = new System.Drawing.Point(123, 45);
            this.dtpNgayBan.Name = "dtpNgayBan";
            this.dtpNgayBan.Size = new System.Drawing.Size(245, 26);
            this.dtpNgayBan.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(18, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày bán";
            // 
            // cboMaKhach
            // 
            this.cboMaKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaKhach.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaKhach.FormattingEnabled = true;
            this.cboMaKhach.Location = new System.Drawing.Point(505, 11);
            this.cboMaKhach.Name = "cboMaKhach";
            this.cboMaKhach.Size = new System.Drawing.Size(248, 27);
            this.cboMaKhach.TabIndex = 3;
            this.cboMaKhach.SelectedIndexChanged += new System.EventHandler(this.cboMaKhach_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7.Location = new System.Drawing.Point(395, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên khách hàng";
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(123, 87);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(245, 27);
            this.cboMaNhanVien.TabIndex = 2;
            this.cboMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboMaNhanVien_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4.Location = new System.Drawing.Point(18, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã nhân viên";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTenNhanVien.Location = new System.Drawing.Point(123, 124);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(245, 26);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label8.Location = new System.Drawing.Point(395, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Địa chỉ";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDienThoai.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtDienThoai.Location = new System.Drawing.Point(505, 127);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(248, 26);
            this.txtDienThoai.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(18, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên nhân viên";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtDiaChi.Location = new System.Drawing.Point(505, 87);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(248, 26);
            this.txtDiaChi.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label9.Location = new System.Drawing.Point(395, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Điện thoại";
            // 
            // txtTenKhach
            // 
            this.txtTenKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKhach.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTenKhach.Location = new System.Drawing.Point(505, 48);
            this.txtTenKhach.Name = "txtTenKhach";
            this.txtTenKhach.Size = new System.Drawing.Size(248, 26);
            this.txtTenKhach.TabIndex = 1;
            // 
            // txtMaHDBan
            // 
            this.txtMaHDBan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaHDBan.Location = new System.Drawing.Point(123, 11);
            this.txtMaHDBan.Name = "txtMaHDBan";
            this.txtMaHDBan.Size = new System.Drawing.Size(245, 26);
            this.txtMaHDBan.TabIndex = 1;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(735, 487);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(173, 26);
            this.txtTongTien.TabIndex = 5;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label16.Location = new System.Drawing.Point(660, 491);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 19);
            this.label16.TabIndex = 4;
            this.label16.Text = "Tổng tiền";
            // 
            // dgvHDBanHang
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dgvHDBanHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHDBanHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHDBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDBanHang.Location = new System.Drawing.Point(4, 204);
            this.dgvHDBanHang.Name = "dgvHDBanHang";
            this.dgvHDBanHang.Size = new System.Drawing.Size(937, 275);
            this.dgvHDBanHang.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_ThongTinChung);
            this.tabControl1.Controls.Add(this.tabPage_ChiTietHoaDon);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(954, 615);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnXoa.Location = new System.Drawing.Point(331, 10);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 38;
            this.btnXoa.Text = "Xoá hóa đơn";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 700);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHoaDonBan";
            this.Text = "DANH MỤC HÓA ĐƠN BÁN";
            this.Load += new System.EventHandler(this.frmHoaDonBan_Load);
            this.panel_title.ResumeLayout(false);
            this.tabPage_ThongTinChung.ResumeLayout(false);
            this.tabPage_ThongTinChung.PerformLayout();
            this.panel_button.ResumeLayout(false);
            this.panel_button.PerformLayout();
            this.panel_Input.ResumeLayout(false);
            this.panel_Input.PerformLayout();
            this.panel_TimKIem.ResumeLayout(false);
            this.panel_TimKIem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDBanHang)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.TabPage tabPage_ChiTietHoaDon;
        private System.Windows.Forms.TabPage tabPage_ThongTinChung;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnInHoaDon;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Panel panel_Input;
        private System.Windows.Forms.Panel panel_TimKIem;
        private System.Windows.Forms.ComboBox cboMaNVLoc;
        private System.Windows.Forms.ComboBox cboMaKHLoc;
        private System.Windows.Forms.Button btnHuyLoc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMaKhach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.TextBox txtMaHDBan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvHDBanHang;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnXoa;
    }
}


namespace BTL_Prj.Frm.HoaDonNhap

{
    partial class frmHoaDonNhap
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
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.dgvHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtMaHDN = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnInHD = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel_button = new System.Windows.Forms.Panel();
            this.panel_input = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_ThongTinChung = new System.Windows.Forms.TabPage();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuyLoc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.cboMaNCCLoc = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMaNVLoc = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage_ChiTietHoaDon = new System.Windows.Forms.TabPage();
            this.label_title = new System.Windows.Forms.Label();
            this.panel_title = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).BeginInit();
            this.panel_button.SuspendLayout();
            this.panel_input.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_ThongTinChung.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_title.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(535, 25);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(254, 27);
            this.cboMaNCC.TabIndex = 40;
            this.cboMaNCC.SelectedIndexChanged += new System.EventHandler(this.CBBNCC_SelectedIndexChanged);
            // 
            // cboMaNV
            // 
            this.cboMaNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(141, 90);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(254, 27);
            this.cboMaNV.TabIndex = 39;
            this.cboMaNV.SelectedIndexChanged += new System.EventHandler(this.CBBMNV_SelectedIndexChanged);
            // 
            // dgvHoaDonNhap
            // 
            this.dgvHoaDonNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDonNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonNhap.Location = new System.Drawing.Point(3, 227);
            this.dgvHoaDonNhap.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            this.dgvHoaDonNhap.ReadOnly = true;
            this.dgvHoaDonNhap.Size = new System.Drawing.Size(940, 264);
            this.dgvHoaDonNhap.TabIndex = 36;
            this.dgvHoaDonNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvHDN_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4.Location = new System.Drawing.Point(22, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 34;
            this.label4.Text = "Ngày cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(416, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Mã nhà cung cấp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(22, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Mã nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "Số hoá đơn nhập";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpNgayNhap.Location = new System.Drawing.Point(141, 56);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(254, 26);
            this.dtpNgayNhap.TabIndex = 30;
            this.dtpNgayNhap.ValueChanged += new System.EventHandler(this.DatetimeNC_ValueChanged);
            // 
            // txtMaHDN
            // 
            this.txtMaHDN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaHDN.Location = new System.Drawing.Point(141, 22);
            this.txtMaHDN.Name = "txtMaHDN";
            this.txtMaHDN.Size = new System.Drawing.Size(254, 26);
            this.txtMaHDN.TabIndex = 23;
            this.txtMaHDN.TextChanged += new System.EventHandler(this.TBHDN_TextChanged);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnSua.Location = new System.Drawing.Point(174, 10);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(127, 40);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Cập nhật hóa đơn";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.SUA_Click);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.AutoSize = true;
            this.btnChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnChiTiet.Location = new System.Drawing.Point(481, 10);
            this.btnChiTiet.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(120, 40);
            this.btnChiTiet.TabIndex = 28;
            this.btnChiTiet.Text = "Chi tiết hoá đơn";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.Chitiethoadon_Click);
            // 
            // btnInHD
            // 
            this.btnInHD.AutoSize = true;
            this.btnInHD.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnInHD.Location = new System.Drawing.Point(641, 10);
            this.btnInHD.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(120, 40);
            this.btnInHD.TabIndex = 25;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = true;
            this.btnInHD.Click += new System.EventHandler(this.ClearBT_Click);
            // 
            // btnDong
            // 
            this.btnDong.AutoSize = true;
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDong.Location = new System.Drawing.Point(800, 10);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 40);
            this.btnDong.TabIndex = 29;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.THoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThem.Location = new System.Drawing.Point(20, 10);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 40);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm hoá đơn";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.THEM_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnXoa.Location = new System.Drawing.Point(329, 10);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 40);
            this.btnXoa.TabIndex = 37;
            this.btnXoa.Text = "Xoá hóa đơn";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.XOA_Click);
            // 
            // panel_button
            // 
            this.panel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_button.BackColor = System.Drawing.Color.Transparent;
            this.panel_button.Controls.Add(this.btnXoa);
            this.panel_button.Controls.Add(this.btnThem);
            this.panel_button.Controls.Add(this.btnDong);
            this.panel_button.Controls.Add(this.btnInHD);
            this.panel_button.Controls.Add(this.btnChiTiet);
            this.panel_button.Controls.Add(this.btnSua);
            this.panel_button.Location = new System.Drawing.Point(3, 531);
            this.panel_button.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(940, 60);
            this.panel_button.TabIndex = 41;
            // 
            // panel_input
            // 
            this.panel_input.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_input.BackColor = System.Drawing.Color.Transparent;
            this.panel_input.Controls.Add(this.btnHuy);
            this.panel_input.Controls.Add(this.btnLuu);
            this.panel_input.Controls.Add(this.txtDienThoai);
            this.panel_input.Controls.Add(this.txtDiaChi);
            this.panel_input.Controls.Add(this.txtTenNCC);
            this.panel_input.Controls.Add(this.txtTenNV);
            this.panel_input.Controls.Add(this.label1);
            this.panel_input.Controls.Add(this.txtMaHDN);
            this.panel_input.Controls.Add(this.cboMaNCC);
            this.panel_input.Controls.Add(this.dtpNgayNhap);
            this.panel_input.Controls.Add(this.label5);
            this.panel_input.Controls.Add(this.cboMaNV);
            this.panel_input.Controls.Add(this.label2);
            this.panel_input.Controls.Add(this.label8);
            this.panel_input.Controls.Add(this.label7);
            this.panel_input.Controls.Add(this.label6);
            this.panel_input.Controls.Add(this.label3);
            this.panel_input.Controls.Add(this.label4);
            this.panel_input.Location = new System.Drawing.Point(3, 3);
            this.panel_input.Name = "panel_input";
            this.panel_input.Size = new System.Drawing.Size(940, 174);
            this.panel_input.TabIndex = 42;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(800, 92);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.TabIndex = 43;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(800, 42);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 43;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.Location = new System.Drawing.Point(535, 124);
            this.txtDienThoai.Multiline = true;
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(254, 26);
            this.txtDienThoai.TabIndex = 42;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(535, 92);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(254, 26);
            this.txtDiaChi.TabIndex = 42;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.Location = new System.Drawing.Point(535, 60);
            this.txtTenNCC.Multiline = true;
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(254, 26);
            this.txtTenNCC.TabIndex = 42;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTenNV.Location = new System.Drawing.Point(141, 124);
            this.txtTenNV.Multiline = true;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(254, 26);
            this.txtTenNV.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(22, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 19);
            this.label5.TabIndex = 32;
            this.label5.Text = "Tên nhân viên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label8.Location = new System.Drawing.Point(416, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 33;
            this.label8.Text = "Điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7.Location = new System.Drawing.Point(416, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 33;
            this.label7.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6.Location = new System.Drawing.Point(416, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tên nhà cung cấp";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_ThongTinChung);
            this.tabControl1.Controls.Add(this.tabPage_ChiTietHoaDon);
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(954, 620);
            this.tabControl1.TabIndex = 43;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_ThongTinChung
            // 
            this.tabPage_ThongTinChung.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_ThongTinChung.Controls.Add(this.txtTongTien);
            this.tabPage_ThongTinChung.Controls.Add(this.label12);
            this.tabPage_ThongTinChung.Controls.Add(this.panel1);
            this.tabPage_ThongTinChung.Controls.Add(this.dgvHoaDonNhap);
            this.tabPage_ThongTinChung.Controls.Add(this.panel_input);
            this.tabPage_ThongTinChung.Controls.Add(this.panel_button);
            this.tabPage_ThongTinChung.Location = new System.Drawing.Point(4, 4);
            this.tabPage_ThongTinChung.Name = "tabPage_ThongTinChung";
            this.tabPage_ThongTinChung.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ThongTinChung.Size = new System.Drawing.Size(946, 594);
            this.tabPage_ThongTinChung.TabIndex = 0;
            this.tabPage_ThongTinChung.Text = "Thông tin chung";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(750, 499);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(173, 26);
            this.txtTongTien.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(676, 502);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 19);
            this.label12.TabIndex = 44;
            this.label12.Text = "Tổng tiền:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuyLoc);
            this.panel1.Controls.Add(this.btnLoc);
            this.panel1.Controls.Add(this.cboMaNCCLoc);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cboMaNVLoc);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(3, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 49);
            this.panel1.TabIndex = 43;
            // 
            // btnHuyLoc
            // 
            this.btnHuyLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHuyLoc.Location = new System.Drawing.Point(846, 12);
            this.btnHuyLoc.Name = "btnHuyLoc";
            this.btnHuyLoc.Size = new System.Drawing.Size(74, 28);
            this.btnHuyLoc.TabIndex = 35;
            this.btnHuyLoc.Text = "Hủy lọc";
            this.btnHuyLoc.UseVisualStyleBackColor = true;
            this.btnHuyLoc.Click += new System.EventHandler(this.btnHuyLoc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnLoc.Location = new System.Drawing.Point(751, 12);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(77, 28);
            this.btnLoc.TabIndex = 34;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // cboMaNCCLoc
            // 
            this.cboMaNCCLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNCCLoc.FormattingEnabled = true;
            this.cboMaNCCLoc.Location = new System.Drawing.Point(504, 14);
            this.cboMaNCCLoc.Name = "cboMaNCCLoc";
            this.cboMaNCCLoc.Size = new System.Drawing.Size(195, 27);
            this.cboMaNCCLoc.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(388, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 19);
            this.label11.TabIndex = 32;
            this.label11.Text = "Mã nhà cung cấp";
            // 
            // cboMaNVLoc
            // 
            this.cboMaNVLoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNVLoc.FormattingEnabled = true;
            this.cboMaNVLoc.Location = new System.Drawing.Point(200, 14);
            this.cboMaNVLoc.Name = "cboMaNVLoc";
            this.cboMaNVLoc.Size = new System.Drawing.Size(172, 27);
            this.cboMaNVLoc.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(104, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 19);
            this.label10.TabIndex = 32;
            this.label10.Text = "Mã nhân viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(20, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 19);
            this.label9.TabIndex = 32;
            this.label9.Text = "Lọc:";
            // 
            // tabPage_ChiTietHoaDon
            // 
            this.tabPage_ChiTietHoaDon.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_ChiTietHoaDon.Location = new System.Drawing.Point(4, 4);
            this.tabPage_ChiTietHoaDon.Name = "tabPage_ChiTietHoaDon";
            this.tabPage_ChiTietHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ChiTietHoaDon.Size = new System.Drawing.Size(946, 594);
            this.tabPage_ChiTietHoaDon.TabIndex = 1;
            this.tabPage_ChiTietHoaDon.Text = "Chi tiết hóa đơn";
            // 
            // label_title
            // 
            this.label_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(954, 80);
            this.label_title.TabIndex = 38;
            this.label_title.Text = "THÔNG TIN HOÁ ĐƠN NHẬP";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.Color.Transparent;
            this.panel_title.Controls.Add(this.label_title);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Margin = new System.Windows.Forms.Padding(0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(954, 80);
            this.panel_title.TabIndex = 44;
            // 
            // frmHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(954, 700);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHoaDonNhap";
            this.Text = "DANH MỤC HÓA ĐƠN NHẬP";
            this.Load += new System.EventHandler(this.FrmThongTinHDNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.panel_button.PerformLayout();
            this.panel_input.ResumeLayout(false);
            this.panel_input.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_ThongTinChung.ResumeLayout(false);
            this.tabPage_ThongTinChung.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_title.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.DataGridView dgvHoaDonNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtMaHDN;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Panel panel_input;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cboMaNCCLoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboMaNVLoc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnHuyLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage_ThongTinChung;
        public System.Windows.Forms.TabPage tabPage_ChiTietHoaDon;
    }
}


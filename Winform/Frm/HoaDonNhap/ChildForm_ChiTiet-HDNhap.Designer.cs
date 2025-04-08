namespace BTL_Prj.Frm.HoaDonNhap

{
    partial class ChildfrmChiTietHDNhap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvChiTietHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.BTSUA = new System.Windows.Forms.Button();
            this.BTDELETE = new System.Windows.Forms.Button();
            this.BTADDCTHDN = new System.Windows.Forms.Button();
            this.ExitForm2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBGIAMGIA = new System.Windows.Forms.TextBox();
            this.TBDONGIA = new System.Windows.Forms.TextBox();
            this.TBSOLUONG = new System.Windows.Forms.TextBox();
            this.SoHDNTB = new System.Windows.Forms.TextBox();
            this.CBBMAHANG = new System.Windows.Forms.ComboBox();
            this.panel_button = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel_input = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.labelTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDonNhap)).BeginInit();
            this.panel_button.SuspendLayout();
            this.panel_input.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTietHoaDonNhap
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.dgvChiTietHoaDonNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietHoaDonNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHoaDonNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDonNhap.Location = new System.Drawing.Point(6, 168);
            this.dgvChiTietHoaDonNhap.Margin = new System.Windows.Forms.Padding(0);
            this.dgvChiTietHoaDonNhap.Name = "dgvChiTietHoaDonNhap";
            this.dgvChiTietHoaDonNhap.ReadOnly = true;
            this.dgvChiTietHoaDonNhap.Size = new System.Drawing.Size(939, 357);
            this.dgvChiTietHoaDonNhap.TabIndex = 51;
            this.dgvChiTietHoaDonNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvFORM2_CellClick);
            // 
            // BTSUA
            // 
            this.BTSUA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BTSUA.Location = new System.Drawing.Point(413, 10);
            this.BTSUA.Name = "BTSUA";
            this.BTSUA.Size = new System.Drawing.Size(120, 40);
            this.BTSUA.TabIndex = 50;
            this.BTSUA.Text = "Chỉnh sửa";
            this.BTSUA.UseVisualStyleBackColor = true;
            this.BTSUA.Click += new System.EventHandler(this.BTSUA_Click);
            // 
            // BTDELETE
            // 
            this.BTDELETE.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BTDELETE.Location = new System.Drawing.Point(224, 10);
            this.BTDELETE.Name = "BTDELETE";
            this.BTDELETE.Size = new System.Drawing.Size(120, 40);
            this.BTDELETE.TabIndex = 49;
            this.BTDELETE.Text = "Xoá mặt hàng";
            this.BTDELETE.UseVisualStyleBackColor = true;
            this.BTDELETE.Click += new System.EventHandler(this.BTDELETE_Click);
            // 
            // BTADDCTHDN
            // 
            this.BTADDCTHDN.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.BTADDCTHDN.Location = new System.Drawing.Point(36, 10);
            this.BTADDCTHDN.Name = "BTADDCTHDN";
            this.BTADDCTHDN.Size = new System.Drawing.Size(120, 40);
            this.BTADDCTHDN.TabIndex = 48;
            this.BTADDCTHDN.Text = "Thêm mặt hàng";
            this.BTADDCTHDN.UseVisualStyleBackColor = true;
            this.BTADDCTHDN.Click += new System.EventHandler(this.BTADDCTHDN_Click);
            // 
            // ExitForm2
            // 
            this.ExitForm2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.ExitForm2.Location = new System.Drawing.Point(799, 10);
            this.ExitForm2.Name = "ExitForm2";
            this.ExitForm2.Size = new System.Drawing.Size(120, 40);
            this.ExitForm2.TabIndex = 46;
            this.ExitForm2.Text = "Đóng";
            this.ExitForm2.UseVisualStyleBackColor = true;
            this.ExitForm2.Click += new System.EventHandler(this.ExitForm2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5.Location = new System.Drawing.Point(270, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 44;
            this.label5.Text = "Giảm giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4.Location = new System.Drawing.Point(511, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 43;
            this.label4.Text = "Đơn giá ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(51, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(51, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "Mã hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label1.Location = new System.Drawing.Point(270, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Mã hóa đơn";
            // 
            // TBGIAMGIA
            // 
            this.TBGIAMGIA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TBGIAMGIA.Location = new System.Drawing.Point(359, 115);
            this.TBGIAMGIA.Name = "TBGIAMGIA";
            this.TBGIAMGIA.Size = new System.Drawing.Size(122, 26);
            this.TBGIAMGIA.TabIndex = 38;
            // 
            // TBDONGIA
            // 
            this.TBDONGIA.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TBDONGIA.Location = new System.Drawing.Point(589, 70);
            this.TBDONGIA.Name = "TBDONGIA";
            this.TBDONGIA.Size = new System.Drawing.Size(122, 26);
            this.TBDONGIA.TabIndex = 37;
            // 
            // TBSOLUONG
            // 
            this.TBSOLUONG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.TBSOLUONG.Location = new System.Drawing.Point(129, 115);
            this.TBSOLUONG.Name = "TBSOLUONG";
            this.TBSOLUONG.Size = new System.Drawing.Size(121, 26);
            this.TBSOLUONG.TabIndex = 36;
            // 
            // SoHDNTB
            // 
            this.SoHDNTB.Enabled = false;
            this.SoHDNTB.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.SoHDNTB.Location = new System.Drawing.Point(359, 27);
            this.SoHDNTB.Name = "SoHDNTB";
            this.SoHDNTB.Size = new System.Drawing.Size(122, 26);
            this.SoHDNTB.TabIndex = 34;
            // 
            // CBBMAHANG
            // 
            this.CBBMAHANG.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.CBBMAHANG.FormattingEnabled = true;
            this.CBBMAHANG.Location = new System.Drawing.Point(129, 70);
            this.CBBMAHANG.Name = "CBBMAHANG";
            this.CBBMAHANG.Size = new System.Drawing.Size(122, 27);
            this.CBBMAHANG.TabIndex = 53;
            // 
            // panel_button
            // 
            this.panel_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_button.Controls.Add(this.btnReport);
            this.panel_button.Controls.Add(this.BTADDCTHDN);
            this.panel_button.Controls.Add(this.ExitForm2);
            this.panel_button.Controls.Add(this.BTSUA);
            this.panel_button.Controls.Add(this.BTDELETE);
            this.panel_button.Location = new System.Drawing.Point(0, 560);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(954, 60);
            this.panel_button.TabIndex = 54;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(601, 10);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(130, 40);
            this.btnReport.TabIndex = 51;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // panel_input
            // 
            this.panel_input.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_input.Controls.Add(this.btnHuy);
            this.panel_input.Controls.Add(this.btnLuu);
            this.panel_input.Controls.Add(this.label15);
            this.panel_input.Controls.Add(this.txtThanhTien);
            this.panel_input.Controls.Add(this.label12);
            this.panel_input.Controls.Add(this.txtTenHang);
            this.panel_input.Controls.Add(this.SoHDNTB);
            this.panel_input.Controls.Add(this.TBSOLUONG);
            this.panel_input.Controls.Add(this.TBDONGIA);
            this.panel_input.Controls.Add(this.CBBMAHANG);
            this.panel_input.Controls.Add(this.TBGIAMGIA);
            this.panel_input.Controls.Add(this.label1);
            this.panel_input.Controls.Add(this.label5);
            this.panel_input.Controls.Add(this.label2);
            this.panel_input.Controls.Add(this.label4);
            this.panel_input.Controls.Add(this.label3);
            this.panel_input.Location = new System.Drawing.Point(0, 0);
            this.panel_input.Margin = new System.Windows.Forms.Padding(0);
            this.panel_input.Name = "panel_input";
            this.panel_input.Size = new System.Drawing.Size(954, 161);
            this.panel_input.TabIndex = 56;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHuy.Location = new System.Drawing.Point(785, 88);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.TabIndex = 59;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnLuu.Location = new System.Drawing.Point(785, 30);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 40);
            this.btnLuu.TabIndex = 58;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label15.Location = new System.Drawing.Point(511, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 19);
            this.label15.TabIndex = 56;
            this.label15.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtThanhTien.Location = new System.Drawing.Point(589, 115);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(122, 26);
            this.txtThanhTien.TabIndex = 57;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label12.Location = new System.Drawing.Point(270, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 19);
            this.label12.TabIndex = 54;
            this.label12.Text = "Tên hàng";
            // 
            // txtTenHang
            // 
            this.txtTenHang.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTenHang.Location = new System.Drawing.Point(359, 70);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(122, 26);
            this.txtTenHang.TabIndex = 55;
            this.txtTenHang.TextChanged += new System.EventHandler(this.txtTenHang_TextChanged);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtTongTien.Location = new System.Drawing.Point(772, 528);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(173, 26);
            this.txtTongTien.TabIndex = 58;
            // 
            // labelTongTien
            // 
            this.labelTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.labelTongTien.Location = new System.Drawing.Point(697, 532);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(65, 19);
            this.labelTongTien.TabIndex = 57;
            this.labelTongTien.Text = "Tổng tiền";
            // 
            // ChildfrmChiTietHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 620);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.labelTongTien);
            this.Controls.Add(this.panel_input);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.dgvChiTietHoaDonNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChildfrmChiTietHDNhap";
            this.Text = "THÔNG TIN CHI TIẾT HÓA ĐƠN NHẬP";
            this.Load += new System.EventHandler(this.ChildfrmChiTietHDNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDonNhap)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.panel_input.ResumeLayout(false);
            this.panel_input.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvChiTietHoaDonNhap;
        private System.Windows.Forms.Button BTSUA;
        private System.Windows.Forms.Button BTDELETE;
        private System.Windows.Forms.Button BTADDCTHDN;
        private System.Windows.Forms.Button ExitForm2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBGIAMGIA;
        private System.Windows.Forms.TextBox TBDONGIA;
        private System.Windows.Forms.TextBox TBSOLUONG;
        private System.Windows.Forms.TextBox SoHDNTB;
        private System.Windows.Forms.ComboBox CBBMAHANG;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Panel panel_input;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label labelTongTien;
    }
}
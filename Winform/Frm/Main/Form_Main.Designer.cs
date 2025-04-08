namespace BTL_Prj.Frm.Main
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel_user = new System.Windows.Forms.Panel();
            this.lb_username = new System.Windows.Forms.Label();
            this.ptb_user = new System.Windows.Forms.PictureBox();
            this.btn_menu_HangHoa = new System.Windows.Forms.Button();
            this.btn_menu_Thoat = new System.Windows.Forms.Button();
            this.btn_menu_NhanVien = new System.Windows.Forms.Button();
            this.btn_menu_KhachHang = new System.Windows.Forms.Button();
            this.btn_menu_HDNhap = new System.Windows.Forms.Button();
            this.btn_menu_HDBan = new System.Windows.Forms.Button();
            this.panel_childForm = new System.Windows.Forms.Panel();
            this.txt_warning = new System.Windows.Forms.TextBox();
            this.panel_LeftBar = new System.Windows.Forms.Panel();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.panel_user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_user)).BeginInit();
            this.panel_childForm.SuspendLayout();
            this.panel_LeftBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_user
            // 
            this.panel_user.BackColor = System.Drawing.Color.Navy;
            this.panel_user.Controls.Add(this.lb_username);
            this.panel_user.Controls.Add(this.ptb_user);
            this.panel_user.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_user.Location = new System.Drawing.Point(0, 0);
            this.panel_user.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel_user.Name = "panel_user";
            this.panel_user.Size = new System.Drawing.Size(186, 175);
            this.panel_user.TabIndex = 0;
            // 
            // lb_username
            // 
            this.lb_username.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb_username.ForeColor = System.Drawing.Color.White;
            this.lb_username.Location = new System.Drawing.Point(0, 122);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(186, 20);
            this.lb_username.TabIndex = 2;
            this.lb_username.Text = "Hello, User";
            this.lb_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_user
            // 
            this.ptb_user.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptb_user.Image = global::BTL_Prj.Properties.Resources._640px_LogoUTC;
            this.ptb_user.Location = new System.Drawing.Point(61, 32);
            this.ptb_user.Name = "ptb_user";
            this.ptb_user.Size = new System.Drawing.Size(64, 64);
            this.ptb_user.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_user.TabIndex = 2;
            this.ptb_user.TabStop = false;
            // 
            // btn_menu_HangHoa
            // 
            this.btn_menu_HangHoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_menu_HangHoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_HangHoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_HangHoa.FlatAppearance.BorderSize = 0;
            this.btn_menu_HangHoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_HangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_HangHoa.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_HangHoa.Location = new System.Drawing.Point(0, 235);
            this.btn_menu_HangHoa.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_HangHoa.Name = "btn_menu_HangHoa";
            this.btn_menu_HangHoa.Size = new System.Drawing.Size(186, 45);
            this.btn_menu_HangHoa.TabIndex = 2;
            this.btn_menu_HangHoa.Text = "Hàng Hóa";
            this.btn_menu_HangHoa.UseVisualStyleBackColor = false;
            this.btn_menu_HangHoa.Click += new System.EventHandler(this.btn_menu_HangHoa_Click);
            // 
            // btn_menu_Thoat
            // 
            this.btn_menu_Thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_menu_Thoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_Thoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_Thoat.FlatAppearance.BorderSize = 0;
            this.btn_menu_Thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_Thoat.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_Thoat.Location = new System.Drawing.Point(0, 646);
            this.btn_menu_Thoat.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_Thoat.Name = "btn_menu_Thoat";
            this.btn_menu_Thoat.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btn_menu_Thoat.Size = new System.Drawing.Size(186, 46);
            this.btn_menu_Thoat.TabIndex = 2;
            this.btn_menu_Thoat.Text = "Thoát";
            this.btn_menu_Thoat.UseVisualStyleBackColor = false;
            this.btn_menu_Thoat.Click += new System.EventHandler(this.btn_menu_Thoat_Click);
            // 
            // btn_menu_NhanVien
            // 
            this.btn_menu_NhanVien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_menu_NhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_NhanVien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_NhanVien.FlatAppearance.BorderSize = 0;
            this.btn_menu_NhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_NhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_NhanVien.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_NhanVien.Location = new System.Drawing.Point(0, 439);
            this.btn_menu_NhanVien.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_NhanVien.Name = "btn_menu_NhanVien";
            this.btn_menu_NhanVien.Size = new System.Drawing.Size(186, 45);
            this.btn_menu_NhanVien.TabIndex = 2;
            this.btn_menu_NhanVien.Text = "Nhân Viên";
            this.btn_menu_NhanVien.UseVisualStyleBackColor = false;
            this.btn_menu_NhanVien.Click += new System.EventHandler(this.btn_menu_NhanVien_Click);
            // 
            // btn_menu_KhachHang
            // 
            this.btn_menu_KhachHang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_menu_KhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_KhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_KhachHang.FlatAppearance.BorderSize = 0;
            this.btn_menu_KhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_KhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_KhachHang.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_KhachHang.Location = new System.Drawing.Point(0, 388);
            this.btn_menu_KhachHang.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_KhachHang.Name = "btn_menu_KhachHang";
            this.btn_menu_KhachHang.Size = new System.Drawing.Size(186, 45);
            this.btn_menu_KhachHang.TabIndex = 2;
            this.btn_menu_KhachHang.Text = "Khách Hàng";
            this.btn_menu_KhachHang.UseVisualStyleBackColor = false;
            this.btn_menu_KhachHang.Click += new System.EventHandler(this.btn_menu_KhachHang_Click);
            // 
            // btn_menu_HDNhap
            // 
            this.btn_menu_HDNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_menu_HDNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_HDNhap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_HDNhap.FlatAppearance.BorderSize = 0;
            this.btn_menu_HDNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_HDNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_HDNhap.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_HDNhap.Location = new System.Drawing.Point(0, 337);
            this.btn_menu_HDNhap.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_HDNhap.Name = "btn_menu_HDNhap";
            this.btn_menu_HDNhap.Size = new System.Drawing.Size(186, 45);
            this.btn_menu_HDNhap.TabIndex = 2;
            this.btn_menu_HDNhap.Text = "Hóa Đơn Nhập";
            this.btn_menu_HDNhap.UseVisualStyleBackColor = false;
            this.btn_menu_HDNhap.Click += new System.EventHandler(this.btn_menu_HDNhap_Click);
            // 
            // btn_menu_HDBan
            // 
            this.btn_menu_HDBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_menu_HDBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_menu_HDBan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_menu_HDBan.FlatAppearance.BorderSize = 0;
            this.btn_menu_HDBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_menu_HDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_menu_HDBan.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_menu_HDBan.Location = new System.Drawing.Point(0, 286);
            this.btn_menu_HDBan.Margin = new System.Windows.Forms.Padding(0);
            this.btn_menu_HDBan.Name = "btn_menu_HDBan";
            this.btn_menu_HDBan.Size = new System.Drawing.Size(186, 45);
            this.btn_menu_HDBan.TabIndex = 2;
            this.btn_menu_HDBan.Text = "Hóa Đơn Bán";
            this.btn_menu_HDBan.UseVisualStyleBackColor = false;
            this.btn_menu_HDBan.Click += new System.EventHandler(this.btn_menu_HDBan_Click);
            // 
            // panel_childForm
            // 
            this.panel_childForm.AutoSize = true;
            this.panel_childForm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_childForm.Controls.Add(this.txt_warning);
            this.panel_childForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_childForm.Location = new System.Drawing.Point(186, 0);
            this.panel_childForm.Margin = new System.Windows.Forms.Padding(0);
            this.panel_childForm.MinimumSize = new System.Drawing.Size(950, 700);
            this.panel_childForm.Name = "panel_childForm";
            this.panel_childForm.Size = new System.Drawing.Size(950, 701);
            this.panel_childForm.TabIndex = 3;
            // 
            // txt_warning
            // 
            this.txt_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_warning.ForeColor = System.Drawing.Color.Transparent;
            this.txt_warning.Location = new System.Drawing.Point(224, 235);
            this.txt_warning.Multiline = true;
            this.txt_warning.Name = "txt_warning";
            this.txt_warning.Size = new System.Drawing.Size(428, 199);
            this.txt_warning.TabIndex = 0;
            this.txt_warning.Text = "ĐỪNG ĐỤNG VÀO PANEL NHÉ SỢ LẮM RỒI";
            // 
            // panel_LeftBar
            // 
            this.panel_LeftBar.AutoSize = true;
            this.panel_LeftBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel_LeftBar.Controls.Add(this.btn_Logout);
            this.panel_LeftBar.Controls.Add(this.btn_menu_Thoat);
            this.panel_LeftBar.Controls.Add(this.panel_user);
            this.panel_LeftBar.Controls.Add(this.btn_Dashboard);
            this.panel_LeftBar.Controls.Add(this.btn_menu_NhanVien);
            this.panel_LeftBar.Controls.Add(this.btn_menu_HangHoa);
            this.panel_LeftBar.Controls.Add(this.btn_menu_KhachHang);
            this.panel_LeftBar.Controls.Add(this.btn_menu_HDBan);
            this.panel_LeftBar.Controls.Add(this.btn_menu_HDNhap);
            this.panel_LeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_LeftBar.Location = new System.Drawing.Point(0, 0);
            this.panel_LeftBar.Margin = new System.Windows.Forms.Padding(0);
            this.panel_LeftBar.MinimumSize = new System.Drawing.Size(186, 700);
            this.panel_LeftBar.Name = "panel_LeftBar";
            this.panel_LeftBar.Size = new System.Drawing.Size(186, 701);
            this.panel_LeftBar.TabIndex = 0;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_Logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Logout.FlatAppearance.BorderSize = 0;
            this.btn_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Logout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Logout.Location = new System.Drawing.Point(0, 600);
            this.btn_Logout.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btn_Logout.Size = new System.Drawing.Size(186, 46);
            this.btn_Logout.TabIndex = 3;
            this.btn_Logout.Text = "Đăng Xuất";
            this.btn_Logout.UseVisualStyleBackColor = false;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_Dashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Dashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Dashboard.Location = new System.Drawing.Point(0, 184);
            this.btn_Dashboard.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Size = new System.Drawing.Size(186, 45);
            this.btn_Dashboard.TabIndex = 2;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.UseVisualStyleBackColor = false;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1134, 701);
            this.Controls.Add(this.panel_childForm);
            this.Controls.Add(this.panel_LeftBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1150, 740);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỂM QUẢN LÝ BÁN HÀNG";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel_user.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_user)).EndInit();
            this.panel_childForm.ResumeLayout(false);
            this.panel_childForm.PerformLayout();
            this.panel_LeftBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel_user;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.PictureBox ptb_user;
        private System.Windows.Forms.Button btn_menu_HangHoa;
        private System.Windows.Forms.Button btn_menu_NhanVien;
        private System.Windows.Forms.Button btn_menu_KhachHang;
        private System.Windows.Forms.Button btn_menu_HDNhap;
        private System.Windows.Forms.Button btn_menu_HDBan;
        private System.Windows.Forms.Button btn_menu_Thoat;
        private System.Windows.Forms.Panel panel_childForm;
        private System.Windows.Forms.Panel panel_LeftBar;
        private System.Windows.Forms.Button btn_Dashboard;
        private System.Windows.Forms.TextBox txt_warning;
        private System.Windows.Forms.Button btn_Logout;
    }
}
namespace BTL_Prj.Frm.NhanVien
{
    partial class Form_TaoTaiKhoan
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
            this.label_TaiKhoan = new System.Windows.Forms.Label();
            this.label_matkhau = new System.Windows.Forms.Label();
            this.txt_taikhoan = new System.Windows.Forms.TextBox();
            this.txt_matkhau = new System.Windows.Forms.TextBox();
            this.checkBox_isAdmin = new System.Windows.Forms.CheckBox();
            this.btn_TaoTK = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.label_nhaplaiMK = new System.Windows.Forms.Label();
            this.txt_nhaplaiMK = new System.Windows.Forms.TextBox();
            this.label_DaCoTaiKhoan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_TaiKhoan
            // 
            this.label_TaiKhoan.AutoSize = true;
            this.label_TaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label_TaiKhoan.Location = new System.Drawing.Point(64, 47);
            this.label_TaiKhoan.Name = "label_TaiKhoan";
            this.label_TaiKhoan.Size = new System.Drawing.Size(69, 19);
            this.label_TaiKhoan.TabIndex = 0;
            this.label_TaiKhoan.Text = "Tài khoản";
            // 
            // label_matkhau
            // 
            this.label_matkhau.AutoSize = true;
            this.label_matkhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label_matkhau.Location = new System.Drawing.Point(64, 81);
            this.label_matkhau.Name = "label_matkhau";
            this.label_matkhau.Size = new System.Drawing.Size(67, 19);
            this.label_matkhau.TabIndex = 0;
            this.label_matkhau.Text = "Mật khẩu";
            // 
            // txt_taikhoan
            // 
            this.txt_taikhoan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_taikhoan.Location = new System.Drawing.Point(193, 44);
            this.txt_taikhoan.Name = "txt_taikhoan";
            this.txt_taikhoan.Size = new System.Drawing.Size(165, 26);
            this.txt_taikhoan.TabIndex = 1;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_matkhau.Location = new System.Drawing.Point(194, 78);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Size = new System.Drawing.Size(165, 26);
            this.txt_matkhau.TabIndex = 1;
            // 
            // checkBox_isAdmin
            // 
            this.checkBox_isAdmin.AutoSize = true;
            this.checkBox_isAdmin.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.checkBox_isAdmin.Location = new System.Drawing.Point(94, 143);
            this.checkBox_isAdmin.Name = "checkBox_isAdmin";
            this.checkBox_isAdmin.Size = new System.Drawing.Size(181, 23);
            this.checkBox_isAdmin.TabIndex = 2;
            this.checkBox_isAdmin.Text = "Thêm vai trò quản trị viên";
            this.checkBox_isAdmin.UseVisualStyleBackColor = true;
            // 
            // btn_TaoTK
            // 
            this.btn_TaoTK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_TaoTK.Location = new System.Drawing.Point(154, 190);
            this.btn_TaoTK.Name = "btn_TaoTK";
            this.btn_TaoTK.Size = new System.Drawing.Size(108, 32);
            this.btn_TaoTK.TabIndex = 3;
            this.btn_TaoTK.Text = "Tạo Tài khoản";
            this.btn_TaoTK.UseVisualStyleBackColor = true;
            this.btn_TaoTK.Click += new System.EventHandler(this.btn_TaoTK_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Huy.Location = new System.Drawing.Point(296, 190);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(108, 32);
            this.btn_Huy.TabIndex = 3;
            this.btn_Huy.Text = "Đóng";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // label_nhaplaiMK
            // 
            this.label_nhaplaiMK.AutoSize = true;
            this.label_nhaplaiMK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label_nhaplaiMK.Location = new System.Drawing.Point(64, 114);
            this.label_nhaplaiMK.Name = "label_nhaplaiMK";
            this.label_nhaplaiMK.Size = new System.Drawing.Size(119, 19);
            this.label_nhaplaiMK.TabIndex = 0;
            this.label_nhaplaiMK.Text = "Nhập lại mật khẩu";
            // 
            // txt_nhaplaiMK
            // 
            this.txt_nhaplaiMK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_nhaplaiMK.Location = new System.Drawing.Point(194, 111);
            this.txt_nhaplaiMK.Name = "txt_nhaplaiMK";
            this.txt_nhaplaiMK.Size = new System.Drawing.Size(165, 26);
            this.txt_nhaplaiMK.TabIndex = 1;
            // 
            // label_DaCoTaiKhoan
            // 
            this.label_DaCoTaiKhoan.AutoSize = true;
            this.label_DaCoTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.label_DaCoTaiKhoan.ForeColor = System.Drawing.Color.Red;
            this.label_DaCoTaiKhoan.Location = new System.Drawing.Point(26, 25);
            this.label_DaCoTaiKhoan.Name = "label_DaCoTaiKhoan";
            this.label_DaCoTaiKhoan.Size = new System.Drawing.Size(371, 16);
            this.label_DaCoTaiKhoan.TabIndex = 4;
            this.label_DaCoTaiKhoan.Text = "Nhân viên này đã có tài khoản nên không thể thay đổi tài khoản!";
            // 
            // Form_TaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 243);
            this.Controls.Add(this.label_DaCoTaiKhoan);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_TaoTK);
            this.Controls.Add(this.checkBox_isAdmin);
            this.Controls.Add(this.txt_nhaplaiMK);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.txt_taikhoan);
            this.Controls.Add(this.label_nhaplaiMK);
            this.Controls.Add(this.label_matkhau);
            this.Controls.Add(this.label_TaiKhoan);
            this.Name = "Form_TaoTaiKhoan";
            this.Text = "Form_TaoTaiKhoan";
            this.Load += new System.EventHandler(this.Form_TaoTaiKhoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TaiKhoan;
        private System.Windows.Forms.Label label_matkhau;
        private System.Windows.Forms.TextBox txt_taikhoan;
        private System.Windows.Forms.TextBox txt_matkhau;
        private System.Windows.Forms.CheckBox checkBox_isAdmin;
        private System.Windows.Forms.Button btn_TaoTK;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Label label_nhaplaiMK;
        private System.Windows.Forms.TextBox txt_nhaplaiMK;
        private System.Windows.Forms.Label label_DaCoTaiKhoan;
    }
}
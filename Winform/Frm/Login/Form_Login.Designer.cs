namespace BTL_Prj
{
    partial class Form_Login
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
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.label_MatKhau = new System.Windows.Forms.Label();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_KeepLogin = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_TaiKhoan
            // 
            this.label_TaiKhoan.AutoSize = true;
            this.label_TaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label_TaiKhoan.Location = new System.Drawing.Point(38, 8);
            this.label_TaiKhoan.Name = "label_TaiKhoan";
            this.label_TaiKhoan.Size = new System.Drawing.Size(69, 19);
            this.label_TaiKhoan.TabIndex = 0;
            this.label_TaiKhoan.Text = "Tài khoản";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_TaiKhoan.Location = new System.Drawing.Point(113, 5);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(147, 26);
            this.txt_TaiKhoan.TabIndex = 1;
            this.txt_TaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TaiKhoan_KeyPress);
            // 
            // label_MatKhau
            // 
            this.label_MatKhau.AutoSize = true;
            this.label_MatKhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label_MatKhau.Location = new System.Drawing.Point(38, 40);
            this.label_MatKhau.Name = "label_MatKhau";
            this.label_MatKhau.Size = new System.Drawing.Size(71, 19);
            this.label_MatKhau.TabIndex = 0;
            this.label_MatKhau.Text = "Mật Khẩu";
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txt_MatKhau.Location = new System.Drawing.Point(113, 37);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(147, 26);
            this.txt_MatKhau.TabIndex = 1;
            this.txt_MatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MatKhau_KeyPress);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_DangNhap.Location = new System.Drawing.Point(70, 151);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(112, 42);
            this.btn_DangNhap.TabIndex = 2;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btn_Thoat.Location = new System.Drawing.Point(202, 151);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(112, 42);
            this.btn_Thoat.TabIndex = 2;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_TaiKhoan);
            this.panel1.Controls.Add(this.label_TaiKhoan);
            this.panel1.Controls.Add(this.label_MatKhau);
            this.panel1.Controls.Add(this.txt_MatKhau);
            this.panel1.Location = new System.Drawing.Point(43, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 70);
            this.panel1.TabIndex = 3;
            // 
            // checkBox_KeepLogin
            // 
            this.checkBox_KeepLogin.AutoSize = true;
            this.checkBox_KeepLogin.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.checkBox_KeepLogin.Location = new System.Drawing.Point(85, 122);
            this.checkBox_KeepLogin.Name = "checkBox_KeepLogin";
            this.checkBox_KeepLogin.Size = new System.Drawing.Size(186, 20);
            this.checkBox_KeepLogin.TabIndex = 4;
            this.checkBox_KeepLogin.Text = "Keep me login in 15 minutes";
            this.checkBox_KeepLogin.UseVisualStyleBackColor = true;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.checkBox_KeepLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangNhap);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Login_FormClosed);
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TaiKhoan;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.Label label_MatKhau;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox checkBox_KeepLogin;
    }
}


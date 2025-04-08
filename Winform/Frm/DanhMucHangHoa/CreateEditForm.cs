using BTL_Prj.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_Prj.Frm.DanhMucHangHoa
{
    public partial class CreateEditForm : Form
    {
        private frmDanhMucHangHoa parentForm; 
        private DataGridViewRow dgvr;
        private string table;

        //SonTrau
        private string btn;
                                                                                                //SonTrau
        public CreateEditForm(DataGridViewRow dgvr, frmDanhMucHangHoa parentForm, string table, string btn)
        {
            InitializeComponent();
            this.dgvr = dgvr;
            this.parentForm = parentForm;
            this.table = table;
            this.btn = btn;
            DisplayInfor();
        }
        private void CreateEditForm_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
        }

        private void DisplayInfor()
        {
            //SonTrau
            if (btn == "Them")
            //if (dgvr == null)
            {
                titleLabel.Text = "Thêm mới";
                txtID.ReadOnly = false; 
                txtID.Text = string.Empty; 
                txtName.Text = string.Empty;
            }
            else
            {
                titleLabel.Text = "Sửa";

               
                txtID.Text = dgvr.Cells[0].Value != null ? dgvr.Cells[0].Value.ToString() : string.Empty;
                txtName.Text = dgvr.Cells[1].Value != null ? dgvr.Cells[1].Value.ToString() : string.Empty;

                txtID.ReadOnly = true; 
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Hãy điền đủ thông tin!");
                return;
            }

            string idColumn = "";
            string nameColumn = "";
            Console.WriteLine($"Table received: {this.table}");

            
            switch (this.table)
            {
                case "CongDung":
                    idColumn = "MaCongDung";
                    nameColumn = "TenCongDung";
                    break;
                case "MauSac":
                    idColumn = "MaMau";
                    nameColumn = "TenMau";
                    break;
                case "DonViTinh":
                    idColumn = "MaDonVi";
                    nameColumn = "TenDonVi";
                    break;
                case "DacDiem":
                    idColumn = "MaDacDiem";
                    nameColumn = "TenDacDiem";
                    break;
                case "NoiSanXuat":
                    idColumn = "MaNoiSX";
                    nameColumn = "TenNoiSX";
                    break;
                default:
                    MessageBox.Show("Bảng không hợp lệ!");
                    return;
            }

           
            if (btn == "Them") 
            //if (dgvr == null) 
            {
                string query = $"INSERT INTO {this.table}({idColumn}, {nameColumn}) VALUES (@Ma, @Ten)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Ma", txtID.Text),
                    new SqlParameter("@Ten", txtName.Text),
                };
                ProcessingData.RunSQLQuerry(query, parameters);
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                string query = $"UPDATE {this.table} SET {nameColumn} = @Ten WHERE {idColumn} = @Ma";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Ma", txtID.Text),
                    new SqlParameter("@Ten", txtName.Text),
                };
                ProcessingData.RunSQLQuerry(query, parameters);
                MessageBox.Show("Cập nhật thành công!");
            }

           
            CloseAndReset();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            CloseAndReset(); 
        }

        private void CloseAndReset()
        {
            
            parentForm?.LoadDataForTab(this.table);
            parentForm?.LoadData();
            parentForm?.LoadComboBoxData();
            this.Close();
        }
    }
}

using BTL_Prj.Class;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Prj.Frm.Report.ReportKhachHang
{
    public partial class FormReport_KhachHang : Form
    {
        public FormReport_KhachHang()
        {
            InitializeComponent();
        }

        private void FormReport_KhachHang_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_Prj.Frm.Report.ReportKhachHang.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = ProcessingData.GetAllKhachHang();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

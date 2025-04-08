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

namespace BTL_Prj.Frm.Report.ReportChiTietHoaDonNhap
{
    public partial class FormReport_ChiTietHDN : Form
    {
        private string sohdn;
        public FormReport_ChiTietHDN(string sohdn)
        {
            InitializeComponent();
            this.sohdn = sohdn;
        }

        private void FormReport_ChiTietHDN_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            try
            {
                string query = "Select * from ChiTietHoaDonNhap where SoHDN = @SoHDN";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDN", sohdn }
                };
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_Prj.Frm.Report.ReportChiTietHoaDonNhap.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = ProcessingData.GetData(query, parameters);
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

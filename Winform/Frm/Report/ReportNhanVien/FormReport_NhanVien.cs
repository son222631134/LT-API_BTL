using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_Prj.Class;
using Microsoft.Reporting.WinForms;

namespace BTL_Prj.Frm.Report
{
    public partial class FormReport_NhanVien : Form
    {
        public FormReport_NhanVien()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_Prj.Frm.Report.ReportNhanVien.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = ProcessingData.NhanVien_GetAllNhanVien();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

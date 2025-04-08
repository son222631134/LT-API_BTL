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

namespace BTL_Prj.Frm.Report.ReportHangHoa
{
    public partial class FormReport_HangHoa : Form
    {
        public FormReport_HangHoa()
        {
            InitializeComponent();
        }

        private void FormReport_HangHoa_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_Prj.Frm.Report.ReportHangHoa.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = ProcessingData.GetAllHangHoa();
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

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

namespace BTL_Prj.Frm.Report.ReportChiTietHoaDonBan
{
    public partial class FormReport_ChiTietHDB : Form
    {
        private int sohdb;
        public FormReport_ChiTietHDB(int sohdb)
        {
            InitializeComponent();
            this.sohdb = sohdb;
        }

        private void FormReport_ChiTietHDB_Load(object sender, EventArgs e)
        {
            Prepare.setFormProperties(this);
            try
            {
                string query = "Select * from ChiTietHoaDonBan where SoHDB = @SoHDB";
                var parameters = new Dictionary<string, object>
                {
                    { "@SoHDB", sohdb }
                };
                reportViewer1.LocalReport.ReportEmbeddedResource = "BTL_Prj.Frm.Report.ReportChiTietHoaDonBan.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = ProcessingData.GetData(query,parameters);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffe
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OrderCoffeDataSet2.DOANHTHUREPORT' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'OrderCoffeDataSet.ChiTietBanHangMonth' table. You can move, or remove it, as needed.
            cbMonthBH.SelectedIndex = 0;
            cbYearBH.SelectedIndex = 0;
            cbYearDT.SelectedIndex = 0;
            cbMonthDT.SelectedIndex = 0;
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] filter = cbMonthBH.SelectedItem.ToString().Split(' ');
            int month = int.Parse(filter[1]);
            int year = int.Parse(cbYearBH.SelectedItem.ToString());
            
                       Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[]
                      {
                           new Microsoft.Reporting.WinForms.ReportParameter("DateExport",DateTime.Now.ToString("dd/MM/yyyy")),
                           new Microsoft.Reporting.WinForms.ReportParameter("Loai","Xuất Báo Cáo Theo Tháng: "+month+"/"+year)
                      };
                      this.reportViewer1.LocalReport.SetParameters(rp);
             
            this.ChiTietBanHangMonthTableAdapter.Fill(this.OrderCoffeDataSet.ChiTietBanHangMonth,month,year);
                      
                      
            this.reportViewer1.RefreshReport();
         
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int year = int.Parse(cbYearBH.SelectedItem.ToString());

            Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                new Microsoft.Reporting.WinForms.ReportParameter("DateExport",DateTime.Now.ToString("dd/MM/yyyy")),
                new Microsoft.Reporting.WinForms.ReportParameter("Loai","Xuất Báo Cáo Theo Năm: "+year)
           };
            this.ChiTietBanHangMonthTableAdapter.Fill(this.OrderCoffeDataSet.ChiTietBanHangMonth, 0, year);
            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string[] filter = cbMonthDT.SelectedItem.ToString().Split(' ');
            int month = int.Parse(filter[1]);
            int year = int.Parse(cbYearDT.SelectedItem.ToString());

            Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                           new Microsoft.Reporting.WinForms.ReportParameter("DateExport",DateTime.Now.ToString("dd/MM/yyyy")),
                           new Microsoft.Reporting.WinForms.ReportParameter("Loai","Xuất Báo Cáo Theo Tháng: "+month+"/"+year)
           };
            this.reportViewer2.LocalReport.SetParameters(rp);
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.DOANHTHUREPORTTableAdapter.Fill(this.OrderCoffeDataSet2.DOANHTHUREPORT,year,month);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int year = int.Parse(cbYearDT.SelectedItem.ToString());

            Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                           new Microsoft.Reporting.WinForms.ReportParameter("DateExport",DateTime.Now.ToString("dd/MM/yyyy")),
                           new Microsoft.Reporting.WinForms.ReportParameter("Loai","Xuất Báo Cáo Theo Năm: "+year)
           };
            this.reportViewer2.LocalReport.SetParameters(rp);
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.DOANHTHUREPORTTableAdapter.Fill(this.OrderCoffeDataSet2.DOANHTHUREPORT, year, 0);
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

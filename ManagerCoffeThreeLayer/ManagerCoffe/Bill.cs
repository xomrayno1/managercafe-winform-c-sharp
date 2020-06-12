using BUS;
using DTO;
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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OrderCoffeDataSet1.HoaDon' table. You can move, or remove it, as needed.
            this.HoaDonTableAdapter.Fill(this.OrderCoffeDataSet1.HoaDon,OrdersBus.GetIdOrder());
            Orders od = OrdersBus.getOrderById(OrdersBus.GetIdOrder());
            Microsoft.Reporting.WinForms.ReportParameter[] rp = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("DateExport",DateTime.Now.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("PriceSales",od.TotalPrice.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("Sales",od.Sales.ToString()+" %"),
            };
            this.reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }

        private void ReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

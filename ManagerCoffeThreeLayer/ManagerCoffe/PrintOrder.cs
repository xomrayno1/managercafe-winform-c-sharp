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
    public partial class PrintOrder : Form
    {
        public PrintOrder()
        {
            InitializeComponent();
        }

        private void PrintOrder_Load(object sender, EventArgs e)
        {
            loadData();
            MaximizeBox = false;

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            try
            {
               
                List<OrderDetail> list = OrderDetailBus.GetAllOrderDetailByIdOrder(OrdersBus.GetIdOrder());
                listViewBill.Items.Clear();
                foreach (var item in list)
                {
                    Products product = ProductsBus.GetProductsById(item.IdProducts);
                    var row = new string[] { product.Name, string.Format("{0:#,##0}", product.Price), item.Quanity.ToString(), string.Format("{0:#,##0}", item.TotalPrice) };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = item;
                    listViewBill.Items.Add(lvi);
                }
                Orders orders = OrdersBus.getOrderById(OrdersBus.GetIdOrder());
                lbSales.Text = orders.Sales.ToString()+"  %";
                lbTotal.Text = string.Format("{0:#,##0}", orders.TotalPrice)+" VNĐ";
                lbdate.Text = orders.Date.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void ListViewBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

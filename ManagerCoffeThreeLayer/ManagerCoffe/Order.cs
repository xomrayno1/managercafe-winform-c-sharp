using BUS;
using DTO;
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

namespace ManagerCoffe
{
    public partial class OrderCf : Form
    {

        private static List<OrderDetail> listOrder ;
        private static int idupdate = 0;
        public OrderCf()
        {
            InitializeComponent();
        }
        private void OrderCf_Load(object sender, EventArgs e)
        {
            listOrder = null;
            // cbSanPham1.SelectedIndex = 0;         
            LoadDataListViewProducts();
            LoadCombo();
            ClearOrder();
            MaximizeBox = false;
            LoadListViewHistoryOrder();
            loadTotalPrice();
            cbSales.SelectedIndex = 0;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
           
            if(listOrder == null || listOrder.Count  == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Sản Phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int total = GetTotalPriceOrder();
                Orders orders = new Orders();
                orders.Date = DateTime.Now;
                orders.TotalPrice = total;
                orders.Sales = int.Parse(cbSales.SelectedItem.ToString());
                OrdersBus.CreateOrder(orders);
                int idOrder = OrdersBus.GetIdOrder();
                foreach (OrderDetail item in listOrder)
                {
                    OrderDetail detail = item;
                    detail.IdOrder = idOrder;
                    OrderDetailBus.AddOrderDetail(detail);
                }

                 MessageBox.Show("Đã Xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               //  PrintOrder print = new PrintOrder();
                   Bill print = new Bill();
                  print.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
               
                listOrder.Clear();
                LoadDataListViewOrder();
                lbtongtien.Text = "0";
                cbSales.Text = "0";
            }
        }
        public  int GetTotalPriceOrder()
        {
            int total = 0;
            int sales = (int.Parse(cbSales.SelectedItem.ToString()));
            foreach (OrderDetail item in listOrder)
            {
                total += item.TotalPrice;
            }
            int valuesSale = (total * sales) / 100;

            return total - valuesSale;
        }
        
        public void loadTotalPrice()
        {
            if (listOrder != null)
            {
                int total = 0;
                foreach (OrderDetail detail in listOrder)
                {
                    total += detail.TotalPrice;
                }
                lbtongtien.Text = string.Format("{0:#,##0}", total) ;
            }
        }
        public  void LoadListViewHistoryOrder()
        {

            lvHistoryOrder.Items.Clear();
            foreach (var item in OrdersBus.getAllOrdersToDay(DateTime.Today))
            {
                var row = new string[] {item.Id.ToString(),item.Date.ToString(), string.Format("{0:#,##0}", item.TotalPrice),item.Sales.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvHistoryOrder.Items.Add(lvi);
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSanPham1.Text.Trim() == "")
                {
                    MessageBox.Show("Chọn Sản Phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Products products = ProductsBus.GetProducts(cbSanPham1.SelectedItem.ToString());
                    Orders order = new Orders();
                    OrderDetail detail = new OrderDetail();
                    detail.IdProducts = products.Id;
                    detail.Quanity = int.Parse(txtSoLuong.Text);
                    detail.TotalPrice = products.Price * int.Parse(txtSoLuong.Text);

                    if (listOrder == null)
                    {
                        listOrder = new List<OrderDetail>();
                        listOrder.Add(detail);
                    }
                    else
                    {
                        bool check = true;
                        foreach (OrderDetail item in listOrder)
                        {
                            if (item.IdProducts == detail.IdProducts) // da co trong ldanh sach order
                            {
                                item.Quanity = item.Quanity + detail.Quanity;
                                item.TotalPrice = item.Quanity * products.Price;
                                check = false;
                            }
                        }
                        if (check)
                        {
                            listOrder.Add(detail);
                        }
                    }
                }
               }catch (Exception)
            {
                MessageBox.Show("Điền Đúng Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally{
                LoadDataListViewOrder();
                ClearOrder();
                loadTotalPrice();
            }
               
               



            
        }
        public void LoadDataListViewProducts()
        {
            lvProductsOrder.Items.Clear();
            foreach (var item in ProductsBus.GetAllProducts())
            {
                var row = new string[] { item.Name, string.Format("{0:#,##0}", item.Price), CategoryBus.GetCategoryById(item.IdCategory).Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvProductsOrder.Items.Add(lvi);
            }
        }
        public void LoadDataListViewOrder()
        {
            listviewOrder.Items.Clear();
            if(listOrder == null)
            {
                return;
            }
            foreach (var item in listOrder)
            {
                Products product = ProductsBus.GetProductsById(item.IdProducts);
                var row = new string[] { product.Name, product.Type, string.Format("{0:#,##0}", product.Price), item.Quanity.ToString(), string.Format("{0:#,##0}", item.TotalPrice) };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listviewOrder.Items.Add(lvi);
            }
        }
    

        private void LvProductsOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.btnEdit.Enabled = false;
            this.btnDelOr.Enabled = false;
            this.btnAddOrd.Enabled = true;
            try
            {
                var localproducts = (Products)lvProductsOrder.SelectedItems[0].Tag;
                //Products products = Connection.GetProducts(localproducts.Name);
                cbSanPham1.Text = localproducts.Name;
                txtSoLuong.Text = "1";
            }
            catch (Exception)
            {
                txtSoLuong.Text = "1";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            idupdate = 0;
            LoadDataListViewProducts();
            ClearOrder();
            cbCategorySearch.Text = "";

        }
        public void ClearOrder()
        {

            this.btnEdit.Enabled = false;
            this.btnDelOr.Enabled = false;
            this.btnAddOrd.Enabled = true;
            txtSoLuong.Text = "1";
            cbSanPham1.Text = "";
        }
        public void LoadCombo()
        {
            txtSoLuong.Text = "1";
            foreach (Products item in ProductsBus.GetAllProducts())
            {
                
                cbSanPham1.Items.Add(item.Name);
            }
            foreach(Category item in CategoryBus.GetAllCategory())
            {
                cbCategorySearch.Items.Add(item.Name);
            }
        }

        private void ListviewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            idupdate = 1;
            try
            {
                
                Products products = ProductsBus.GetProducts(listviewOrder.SelectedItems[0].Text);
                cbSanPham1.Text = products.Name;
                txtSoLuong.Text = listviewOrder.SelectedItems[0].SubItems[3].Text;
            }
            catch (Exception)
            {
                txtSoLuong.Text = "1";
                idupdate = 0;
            }
            this.btnEdit.Enabled = true;
            this.btnDelOr.Enabled = true;
            this.btnAddOrd.Enabled = false;

        }

  

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Products products = ProductsBus.GetProducts(cbSanPham1.SelectedItem.ToString());
                Orders order = new Orders();
                OrderDetail detail = new OrderDetail();
                detail.IdProducts = products.Id;
                detail.Quanity = int.Parse(txtSoLuong.Text);
                detail.TotalPrice = products.Price * int.Parse(txtSoLuong.Text);

                foreach (OrderDetail item in listOrder)
                {
                    if (item.IdProducts == detail.IdProducts) // da co trong ldanh sach order
                    {
                        item.Quanity = detail.Quanity;
                        item.TotalPrice = item.Quanity * products.Price;

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Điền Đúng Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                LoadDataListViewOrder();
                ClearOrder();
                loadTotalPrice();
            }
            



        }

        private void BtnDelOr_Click(object sender, EventArgs e)
        {

            Products products = ProductsBus.GetProducts(cbSanPham1.SelectedItem.ToString());
            OrderDetail detail = new OrderDetail();
            detail.IdProducts = products.Id;
            detail.Quanity = int.Parse(txtSoLuong.Text);
            detail.TotalPrice = products.Price * int.Parse(txtSoLuong.Text);

        
            for(int i = 0; i< listOrder.Count; i++)
            {
                if (listOrder[i].IdProducts == detail.IdProducts) // da co trong ldanh sach order
                {
                    listOrder.Remove(listOrder[i]);

                }
            }

            LoadDataListViewOrder();
            ClearOrder();
            loadTotalPrice();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

            lvProductsOrder.Items.Clear();
            foreach (var item in ProductsBus.GetAllProductsBySearch(txtTenProductSearch.Text))
            {
                var row = new string[] { item.Name,item.Price.ToString()
                   ,CategoryBus.GetCategoryById(item.IdCategory).Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvProductsOrder.Items.Add(lvi);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvProductsOrder.Items.Clear();
            Category category = CategoryBus.GetCategoryByName(cbCategorySearch.SelectedItem.ToString());
            foreach (var item in ProductsBus.GetAllProductsByCategory(category.Id))
            {
                var row = new string[] { item.Name,string.Format("{0:#,##0}",item.Price)
                   ,CategoryBus.GetCategoryById(item.IdCategory).Name };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvProductsOrder.Items.Add(lvi);
            }
        }

        private void ListViewHistoryOrder_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                var localOrders = (Orders)lvHistoryOrder.SelectedItems[0].Tag;
                List<OrderDetail> list = OrderDetailBus.GetAllOrderDetailByIdOrder(localOrders.Id);
                lvHistoryOrderDetail.Items.Clear();
                foreach (var item in list)
                {
                    Products product = ProductsBus.GetProductsById(item.IdProducts);
                    var row = new string[] { item.IdOrder.ToString(), product.Name, item.Quanity.ToString(), string.Format("{0:#,##0}", item.TotalPrice), item.Id.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = item;
                    lvHistoryOrderDetail.Items.Add(lvi);
                }
            }
            catch (Exception)
            {
                
            }

        }

        private void ListView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            LoadListViewHistoryOrder();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        { 
            if(listOrder == null)
            {
                return;
            }
            listOrder.Clear();
            LoadDataListViewOrder();
            lbtongtien.Text = "0";
            cbSales.Text = "0";
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GbOrder_Enter(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

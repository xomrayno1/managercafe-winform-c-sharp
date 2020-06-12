using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCoffe
{
    public partial class Admin : Form
    {
        private static int idUpdate = 0; //user
        private static int idUpdateProducts = 0;
        private static int idUpdateCategory = 0;
        public Admin()
        {
            InitializeComponent();
            CbRole.SelectedIndex = 1;
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameC.Text))
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ", "Thông Báo");
                return;
            }
            if (txtNameC.Text.Trim() == CategoryBus.GetCategoryByName(txtNameC.Text.Trim()).Name)
            {
                MessageBox.Show("Tên Đã Tồn Tại", "Thông Báo");
                return;
            }
            try
            {
                Category category = new Category();
                category.Name = txtNameC.Text;
                CategoryBus.AddCategory(category);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

                btnUpdateC.Enabled = false;
                btnAddC.Enabled = true;
                btnDeleteC.Enabled = false;
                loadListViewCategory();
                ClearTextBoxCategory();

            }

        }

        private void Button4_Click(object sender, EventArgs e) //huy category admin
        {
            btnUpdateC.Enabled = false;
            btnAddC.Enabled = true;
            btnDeleteC.Enabled = false;
            loadListViewCategory();
            ClearTextBoxCategory();
        }
        public void ClearTextBoxCategory()
        {
            txtNameC.Text = "";
            idUpdateCategory = 0;
        }
        private void Button3_Click(object sender, EventArgs e) //huy product admin
        {
            btnAddP.Enabled = true;
            btnUpdateP.Enabled = false;
            btnDeleteP.Enabled = false;
            cbSearchProductCategory.Text = "";
            ClearTextBox();
            loadListViewProducts();
        }
        public void ClearTextBox()
        {
            txtNameP.Text = "";
            txtPriceP.Text = "";
            txtTypeP.Text = "";
            txtDescriptP.Text = "";
            cbCategoryP.Text = "";
            idUpdateProducts = 0;
        }
        public void ClearTextBoxUser()
        {
            txtNameUser.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtGhiChu.Text = "";
            txtEmail.Text = "";
            idUpdate = 0;
            CbRole.SelectedIndex = 1;
        }
        public bool CheckValidateTextBoxEmptyProducts()
        {
            if (string.IsNullOrEmpty(txtNameP.Text)|| string.IsNullOrEmpty(txtPriceP.Text)
                || string.IsNullOrEmpty(txtTypeP.Text) || string.IsNullOrEmpty(txtDescriptP.Text)
                 ||   string.IsNullOrEmpty(cbCategoryP.Text)
                )
            {
                return false;
            }
            return true;
        }
        private void BtnAddP_Click(object sender, EventArgs e)
        {
            if (!CheckValidateTextBoxEmptyProducts())
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ","Thông Báo");
                return;
            }
            if(txtNameP.Text.Trim() == ProductsBus.GetProductsByName(txtNameP.Text.Trim()).Name)
            {
                MessageBox.Show("Tên Đã Tồn Tại", "Thông Báo");
                return;
            }
            
            try
            {
                Products products = new Products();
                products.Name = txtNameP.Text;
                products.Price = int.Parse(txtPriceP.Text);
                products.Type = txtTypeP.Text;
                products.Describe = txtDescriptP.Text;
                products.IdCategory = CategoryBus.GetCategoryByName(cbCategoryP.SelectedItem.ToString()).Id;
                ProductsBus.AddProducts(products);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            finally
            {
                loadListViewProducts();
                ClearTextBox();
               
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
          
            btnUpdateC.Enabled = false;
            btnDeleteC.Enabled = false;
            btnUpdateUser.Enabled = false;            
            btnXoaUser.Enabled = false;
        
            btnAddP.Enabled = true;
            btnUpdateP.Enabled = false;
            btnDeleteP.Enabled = false;
           
            loadDataInComboBoxProducts();
            LoadDataListViewUser();
            loadListViewProducts();
            loadListViewCategory();
            MaximizeBox = false;
          


        }
        public void loadDataInComboBoxProducts()
        {
            cbCategoryP.Items.Clear();
            foreach (Category item in CategoryBus.GetAllCategory())
            {
                
                cbCategoryP.Items.Add(item.Name);
            }
            cbSearchProductCategory.Items.Clear();
            foreach (Category item in CategoryBus.GetAllCategory())
            {
                cbSearchProductCategory.Items.Add(item.Name);
            }
        }
        public void LoadDataListViewUser()
        {
            listViewUser.Items.Clear();
            foreach (var item in UsersBus.getAllUsers())
            {
                var row = new string[] { item.Id.ToString(), item.Name, item.Username, item.Role };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewUser.Items.Add(lvi);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {

            if (!ValidateUsers())
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ", "Thông Báo");
                return;
            }
            if (!string.IsNullOrEmpty(UsersBus.GetUsersByUserName(txtUserName.Text.Trim()).Name))
            {
                MessageBox.Show("Tên Đã Tồn Tại", "Thông Báo");
                return;
            }
            if (!string.IsNullOrEmpty(UsersBus.GetUsersByEmail(txtEmail.Text.Trim()).Email))
            {
                MessageBox.Show("Email Đã Tồn Tại", "Thông Báo");
                return;
            }

            try
            {
                    
                Users users = new Users();
                users.Name = txtNameUser.Text.Trim();
                users.Username = txtUserName.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.Ghichu = txtGhiChu.Text.Trim();
                users.Role = CbRole.SelectedItem.ToString();
                users.Email = txtEmail.Text.Trim();

                UsersBus.AddUsers(users);
                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnUpdateUser.Enabled = false;
                btnXoaUser.Enabled = false;
                btnAddUser.Enabled = true;
                LoadDataListViewUser();
                TextBoxClear();
            

            }
        }
      
        private bool ValidateUsers()
        {
            if (string.IsNullOrEmpty(txtNameUser.Text) || string.IsNullOrEmpty(txtUserName.Text)
               || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtGhiChu.Text)
               || string.IsNullOrEmpty(CbRole.Text) || string.IsNullOrEmpty(txtEmail.Text)
               )
            {
                return false;
            }
            return true;
            
        }

        private void BtnCancelUser_Click(object sender, EventArgs e)
        {
            btnUpdateUser.Enabled = false;
            btnXoaUser.Enabled = false;
            btnAddUser.Enabled = true;
            
            TextBoxClear();
        }
       
        private void ListViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateUser.Enabled = true;
            btnXoaUser.Enabled = true;
            btnAddUser.Enabled = false;
            try
            {
                var localuser = (Users)listViewUser.SelectedItems[0].Tag;
                Users users = UsersBus.GetUsersByUserName(localuser.Username);
                txtNameUser.Text = users.Name;
                txtUserName.Text = users.Username;
                txtPassword.Text = users.Password;
                txtGhiChu.Text = users.Ghichu;
                CbRole.Text = users.Role;
                txtEmail.Text = users.Email; 
                idUpdate = users.Id;
            }
            catch (Exception)
            {
                idUpdate = 0;
            }
        }
        public void TextBoxClear()
        {
            txtNameUser.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtGhiChu.Clear();
            txtEmail.Clear();
            CbRole.Text = "";
            idUpdate = 0;
            CbRole.Text = "ROLE_EMPLOYEE";


        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!ValidateUsers())
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ", "Thông Báo");
                return;
            }
            if (!string.IsNullOrEmpty(UsersBus.GetUsersByUserName(txtUserName.Text.Trim()).Name))
            {

                if (UsersBus.GetUsersByUserName(txtUserName.Text.Trim()).Id != idUpdate)
                {
                    MessageBox.Show("Tên đã tồn tại trong hệ thống", "Thông Báo");
                    return;
                }
            }
            if (!string.IsNullOrEmpty(UsersBus.GetUsersByEmail(txtEmail.Text.Trim()).Email))
            {

                if (UsersBus.GetUsersByEmail(txtEmail.Text.Trim()).Id != idUpdate)
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống", "Thông Báo");
                    return;
                }
            }

            try
            {

                Users users = new Users();
                users.Name = txtNameUser.Text.Trim();
                users.Username = txtUserName.Text.Trim();
                users.Password = txtPassword.Text.Trim();
                users.Ghichu = txtGhiChu.Text.Trim();
                users.Role = CbRole.SelectedItem.ToString();
                users.Email = txtEmail.Text.Trim();
                users.Id = idUpdate;

                UsersBus.UpdateUsers(users);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnUpdateUser.Enabled = false;
                btnXoaUser.Enabled = false;
                btnAddUser.Enabled = true;
                LoadDataListViewUser();
                TextBoxClear();


            }
        }

        private void BtnXoaUser_Click(object sender, EventArgs e)
        {

         
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản "
                    + txtUserName.Text.Trim(), "Thông Báo", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    UsersBus.DeleteUsers(idUpdate);
                    // MessageBox.Show("Xóa Thành Công", "Thông Báo");
                }
             
            }
            catch (Exception)
            {
                MessageBox.Show(" XóaThất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            finally
            {
                btnAddUser.Enabled = true;
                btnUpdateUser.Enabled = false;
                btnXoaUser.Enabled = false;
                ClearTextBoxUser();
                LoadDataListViewUser();
               
            }
        }

        private void ListViewProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddP.Enabled = false;
            btnUpdateP.Enabled = true;
            btnDeleteP.Enabled = true;
            try
            {
                var localproduct = (Products)listViewProducts.SelectedItems[0].Tag;
                Products products = ProductsBus.GetProductsById(localproduct.Id);
                txtNameP.Text = products.Name;
                txtPriceP.Text = products.Price.ToString();
                txtTypeP.Text = products.Type;
                txtDescriptP.Text = products.Describe;
                cbCategoryP.Text =  CategoryBus.GetCategoryById(products.IdCategory).Name;
                idUpdateProducts = products.Id;
               
            }
            catch (Exception)
            {
                idUpdateProducts = 0;
            }
        }

        public void loadListViewProducts()
        {
            listViewProducts.Items.Clear();
            foreach (var item in ProductsBus.GetAllProducts())
            {
                var row = new string[] { item.Name,string.Format("{0:#,##0}",item.Price)
                    ,item.Describe,CategoryBus.GetCategoryById(item.IdCategory).Name,item.Type };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewProducts.Items.Add(lvi);
            }
        }
        public void loadListViewCategory()
        {
            listViewCategory.Items.Clear();
            foreach (var item in CategoryBus.GetAllCategory())
            {
                var row = new string[] { item.Id.ToString(),item.Name};
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewCategory.Items.Add(lvi);
            }
        }

        private void BtnSaveP_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdateP_Click(object sender, EventArgs e)
        {
            if (!CheckValidateTextBoxEmptyProducts())
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ", "Thông Báo");
                return;
            }
            //// nếu tên sản phẩm sửa  mà id của nó khác với idupdate
            /// thì có nghĩa Tên Đó Đã Tồn Tại Trong Sản Phẩm nhưng nó k phải là chính sản 
            /// phẩm mình muốn sữa
            if (!string.IsNullOrEmpty(ProductsBus.GetProductsByName(txtNameP.Text.Trim()).Name))
            {
                
                if (ProductsBus.GetProductsByName(txtNameP.Text.Trim()).Id != idUpdateProducts)
                {
                    MessageBox.Show("Tên sản phẩm đã tồn tại trong hệ thống", "Thông Báo");
                    return;
                }
            }
            try
            {
                Products products = new Products();
                products.Name = txtNameP.Text;
                products.Price = int.Parse(txtPriceP.Text);
                products.Type = txtTypeP.Text;
                products.Describe = txtDescriptP.Text;
                products.IdCategory = CategoryBus.GetCategoryByName(cbCategoryP.SelectedItem.ToString()).Id;
                products.Id = idUpdateProducts;
                ProductsBus.UpdateProducts(products);
                MessageBox.Show("Sửa Thành Công", "Thông Báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnAddP.Enabled = true;
                btnUpdateP.Enabled = false;
                btnDeleteP.Enabled = false;
                ClearTextBox();
                loadListViewProducts();
            }
        }

        private void BtnDeleteP_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Sản Phẩm "
                        + txtNameP.Text.Trim(), "Thông Báo", MessageBoxButtons.YesNo);
                if(DialogResult.Yes == result)
                {
                    ProductsBus.DeleteProducts(idUpdateProducts);
                }
             
               
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            finally{
                btnAddP.Enabled = true;
                btnUpdateP.Enabled = false;
                btnDeleteP.Enabled = false;
                ClearTextBox();
               // MessageBox.Show("Xóa Thành Công", "Thông Báo");
                loadListViewProducts();
            }
        }



        private void TxtSearchP_TextChanged(object sender, EventArgs e)
        {

            listViewProducts.Items.Clear();
            foreach (var item in ProductsBus.GetAllProductsBySearch(txtSearchP.Text))
            {
                var row = new string[] { item.Name,item.Price.ToString()
                    ,item.Describe,CategoryBus.GetCategoryById(item.IdCategory).Name,item.Type };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewProducts.Items.Add(lvi);
            }
        }

        private void BtnUpdateC_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNameC.Text))
            {
                MessageBox.Show("Vui Lòng Điền Đầy Đủ", "Thông Báo");
                return;
            }
            if (!string.IsNullOrEmpty(CategoryBus.GetCategoryByName(txtNameC.Text.Trim()).Name))
            {

                if (CategoryBus.GetCategoryByName(txtNameC.Text.Trim()).Id != idUpdateCategory)
                {
                    MessageBox.Show("Tên Danh Mục đã tồn tại trong hệ thống", "Thông Báo");
                    return;
                }
            }
            try
            {
                Category category = new Category();
                category.Name = txtNameC.Text;
                category.Id = idUpdateCategory;
                CategoryBus.UpdateCategory(category);
            }
            catch (Exception)
            {
                MessageBox.Show("Vui Lòng Điền Theo Định Dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnUpdateC.Enabled = false;
                btnAddC.Enabled = true;
                btnDeleteC.Enabled = false;
                loadListViewCategory();
                ClearTextBoxCategory();

            }
        }

        private void ListViewCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddC.Enabled = false;
            btnUpdateC.Enabled = true;
            btnDeleteC.Enabled = true;
            try
            {
                var localcategory = (Category)listViewCategory.SelectedItems[0].Tag;
                Category category = CategoryBus.GetCategoryById(localcategory.Id);
                txtNameC.Text = category.Name;             
                idUpdateCategory = category.Id;
            }
            catch (Exception)
            {
                idUpdateCategory = 0;
            }
        }

        private void TxtSearchC_TextChanged(object sender, EventArgs e)
        {
            listViewCategory.Items.Clear();
            foreach (var item in CategoryBus.GetAllCategorysBySearch(txtSearchC.Text))
            {
                var row = new string[] { item.Id.ToString(),item.Name};
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewCategory.Items.Add(lvi);
            }
        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void CbSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewProducts.Items.Clear();
            Category category = CategoryBus.GetCategoryByName(cbSearchProductCategory.SelectedItem.ToString());
            foreach (var item in ProductsBus.GetAllProductsByCategory(category.Id))
            {
                var row = new string[] { item.Name, string.Format("{0:#,##0.00}",item.Price)
                    ,item.Describe,CategoryBus.GetCategoryById(item.IdCategory).Name,item.Type };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                listViewProducts.Items.Add(lvi);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            

             
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa Sản Phẩm "
                        + txtNameP.Text.Trim(), "Thông Báo", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    if (ProductsBus.GetAllProductsByCategory(idUpdateCategory).Count > 0)
                    {

                        MessageBox.Show("Danh mục này đã có sản phẩm , Vui lòng xóa các sản phẩm của danh mục này để thực hiển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    CategoryBus.DeleteCategory(idUpdateCategory);                 
                }          
               
            }
            catch (Exception)
            {

            }
            finally
            {
                btnUpdateC.Enabled = false;
                btnAddC.Enabled = true;
                btnDeleteC.Enabled = false;
                loadListViewCategory();
                ClearTextBoxCategory();
            }
        }
        
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var localOrders = (Orders)lvHistoryAdmin.SelectedItems[0].Tag;
                List<OrderDetail> list = OrderDetailBus.GetAllOrderDetailByIdOrder(localOrders.Id);
                lvHistoryDetail.Items.Clear();
                foreach (var item in list)
                {
                    Products product = ProductsBus.GetProductsById(item.IdProducts);
                    var row = new string[] { item.Id.ToString(), product.Name, item.Quanity.ToString(), string.Format("{0:#,##0.00}", item.TotalPrice) };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = item;
                    lvHistoryDetail.Items.Add(lvi);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cbMonth.Text = "";
                cbYear.Text = "";
            lvHistoryAdmin.Items.Clear();
            lvHistoryDetail.Items.Clear();
            if (dtkStart.Value.Date.CompareTo(dtkEnd.Value.Date) ==1)
            {
                lbTotalOrder.Text = "0";
                lbTotalPrice.Text = "0" + " VND";
                return ;
            }
            List<Orders> list = OrdersBus.getAllOrdersByDateToDate(dtkStart.Value.Date, dtkEnd.Value.Date);
            if(list.Count  == 0)
            {
                lbTotalOrder.Text = "0";
                lbTotalPrice.Text = "0" + " VND";
                return;
            }
                foreach (var item in list)
                {
                    var row = new string[] { item.Id.ToString(), item.Date.ToString(), string.Format("{0:#,##0.00}", item.TotalPrice),item.Sales.ToString() };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = item;
                lvHistoryAdmin.Items.Add(lvi);
                }

            lbTotalOrder.Text = OrdersBus.GetTotalOrder(dtkStart.Value.Date, dtkEnd.Value.Date).ToString();
            lbTotalPrice.Text = string.Format("{0:#,##0.00}", OrdersBus.GetTotalPriceOrder(dtkStart.Value.Date, dtkEnd.Value.Date))+" VND";
          

        }

        private void TabDoanhThu_Click(object sender, EventArgs e)
        {

        }

        private void LbTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            loadDataInComboBoxProducts();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                return;
            }
            txtPassword.UseSystemPasswordChar = true;
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbYear.Text = "";
            lvHistoryAdmin.Items.Clear();
            lvHistoryDetail.Items.Clear();
            string[] filter = cbMonth.SelectedItem.ToString().Split(' ');
            int month = int.Parse(filter[1]);
            List<Orders> list = OrdersBus.getAllOrdersByMonth(month);
            if (list.Count == 0)
            {
                lbTotalOrder.Text = "0";
                lbTotalPrice.Text = "0" + " VND";
                return;
            }
            foreach (var item in list)
            {
                var row = new string[] { item.Id.ToString(), item.Date.ToString(), string.Format("{0:#,##0}", item.TotalPrice), item.Sales.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvHistoryAdmin.Items.Add(lvi);
            }

            lbTotalOrder.Text = OrdersBus.GetTotalOrderMonth(month).ToString();
            lbTotalPrice.Text = string.Format("{0:#,##0.00}", OrdersBus.GetTotalPriceOrderMonth(month)) + " VND";
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonth.Text = "";
            lvHistoryAdmin.Items.Clear();
            lvHistoryDetail.Items.Clear();
            
            int year = int.Parse(cbYear.SelectedItem.ToString());
            List<Orders> list = OrdersBus.getAllOrdersByYear(year);
            if (list.Count == 0)
            {
                lbTotalOrder.Text = "0";
                lbTotalPrice.Text = "0" + " VND";
                return;
            }
            foreach (var item in list)
            {
                var row = new string[] { item.Id.ToString(), item.Date.ToString(), string.Format("{0:#,##0}", item.TotalPrice), item.Sales.ToString() };
                var lvi = new ListViewItem(row);
                lvi.Tag = item;
                lvHistoryAdmin.Items.Add(lvi);
            }

            lbTotalOrder.Text = OrdersBus.GetTotalOrderYear(year).ToString();
            lbTotalPrice.Text = string.Format("{0:#,##0}", OrdersBus.GetTotalPriceOrderYear(year)) + " VND";
        }

        private void TabProduct_Click(object sender, EventArgs e)
        {

        }

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            
           
        }

        private void ChiTietBanHangMonthBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
           
        }

        private void ReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
           
        }
    }
}

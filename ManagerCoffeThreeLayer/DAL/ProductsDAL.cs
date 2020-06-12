using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class ProductsDAL
    {
        public static string stringConnection = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=OrderCoffe;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connect = new SqlConnection(stringConnection);
            return connect;
        }
        public static List<Products> GetAllProducts()
        {
            List<Products> list = new List<Products>();
            string query = "select * from products ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Products products = new Products();
                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();
                list.Add(products);
            }
            connection.Close();
            return list;
        }
        public static Products GetProducts(string name)
        {

            string query = "select * from products where name = @name ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);
            adapter.Fill(table);
            Products products = new Products();
            foreach (DataRow item in table.Rows)
            {

                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();

            }
            connection.Close();
            return products;
        }
        public static Products GetProductsById(int id)
        {

            string query = "select * from products where id = @id ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            adapter.Fill(table);
            Products products = new Products();
            foreach (DataRow item in table.Rows)
            {

                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();

            }
            connection.Close();
            return products;
        }
        public static Products GetProductsByName(string name)
        {

            string query = "select * from products where name = @name ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);
            adapter.Fill(table);
            Products products = new Products();
            foreach (DataRow item in table.Rows)
            {

                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();

            }
            connection.Close();
            return products;
        }
        public static List<Products> GetAllProductsBySearch(string search)
        {
            List<Products> list = new List<Products>();
            string query = "select * from products where name like @name ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + search + "%");
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Products products = new Products();
                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();
                list.Add(products);
            }
            connection.Close();
            return list;
        }
        public static List<Products> GetAllProductsByCategory(int id)
        {
            List<Products> list = new List<Products>();
            string query = "select * from products where idcategory = @id ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Products products = new Products();
                products.Id = int.Parse(item["id"].ToString());
                products.Name = item["name"].ToString();
                products.Price = int.Parse(item["price"].ToString());
                products.Describe = item["describe"].ToString();
                products.IdCategory = int.Parse(item["idcategory"].ToString());
                products.Type = item["type"].ToString();
                list.Add(products);
            }
            connection.Close();
            return list;
        }
        public static void AddProducts(Products products)
        {
            string query = "insert into products values(@name,@price,@describe,@idcategory,@type)";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", products.Name);
            sqlCommand.Parameters.AddWithValue("@price", products.Price);
            sqlCommand.Parameters.AddWithValue("@describe", products.Describe);
            sqlCommand.Parameters.AddWithValue("@idcategory", products.IdCategory);
            sqlCommand.Parameters.AddWithValue("@type", products.Type);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void UpdateProducts(Products products)
        {
            string query = "update  products set name = @name , price = @price" +
                   ",describe =@describe,idcategory=@idcategory,type=@type where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", products.Name);
            sqlCommand.Parameters.AddWithValue("@price", products.Price);
            sqlCommand.Parameters.AddWithValue("@describe", products.Describe);
            sqlCommand.Parameters.AddWithValue("@idcategory", products.IdCategory);
            sqlCommand.Parameters.AddWithValue("@type", products.Type);
            sqlCommand.Parameters.AddWithValue("@id", products.Id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void DeleteProducts(int id)
        {
            string query = "delete products where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

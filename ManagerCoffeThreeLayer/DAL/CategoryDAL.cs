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
    public class CategoryDAL
    {
        public static string stringConnection = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=OrderCoffe;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connect = new SqlConnection(stringConnection);
            return connect;
        }
        public static Category GetCategoryById(int id)
        {

            string query = "select * from category where id = @id ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            adapter.Fill(table);
            Category category = new Category();
            foreach (DataRow item in table.Rows)
            {
                category.Id = int.Parse(item["id"].ToString());
                category.Name = item["name"].ToString();
            }
            connection.Close();
            return category;
        }
        public static Category GetCategoryByName(string name)
        {

            string query = "select * from category where name = @name ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.SelectCommand.Parameters.AddWithValue("@name", name);
            adapter.Fill(table);
            Category category = new Category();
            foreach (DataRow item in table.Rows)
            {
                category.Id = int.Parse(item["id"].ToString());
                category.Name = item["name"].ToString();
            }
            connection.Close();
            return category;
        }
        public static List<Category> GetAllCategory()
        {

            string query = "select * from category ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();

            adapter.Fill(table);
            List<Category> list = new List<Category>();
            foreach (DataRow item in table.Rows)
            {
                Category category = new Category();
                category.Id = int.Parse(item["id"].ToString());
                category.Name = item["name"].ToString();
                list.Add(category);
            }
            connection.Close();
            return list;
        }

        public static void AddCategory(Category category)
        {
            string query = "insert into category values(@name)";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", category.Name);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void UpdateCategory(Category category)
        {
            string query = "update  category set name = @name  where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", category.Name);
            sqlCommand.Parameters.AddWithValue("@id", category.Id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static List<Category> GetAllCategorysBySearch(string search)
        {
            List<Category> list = new List<Category>();
            string query = "select * from category where name like @name ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + search + "%");
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Category category = new Category();
                category.Id = int.Parse(item["id"].ToString());
                category.Name = item["name"].ToString();
                list.Add(category);
            }
            connection.Close();
            return list;
        }

        public static void DeleteCategory(int id)
        {
            string query = "delete category where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

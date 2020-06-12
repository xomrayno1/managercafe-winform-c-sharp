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
    public class UsersDAL
    {
        public static string stringConnection = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=OrderCoffe;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connect = new SqlConnection(stringConnection);
            return connect;
        }

        public static bool CheckUsers(Users user)
        {
            string query = "select * from Users where username = @username and password = @password";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@username", user.Username);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            DataTable table = new DataTable();
            table.Load(sqlCommand.ExecuteReader());
            if (table.Rows.Count == 0)
            {
                return false;
            }
            connection.Close();
            return true;
        }
        public static Users GetUsersByUserName(string username)
        {
            string query = "select * from Users where username = @username ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@username", username);
            DataTable table = new DataTable();
            table.Load(sqlCommand.ExecuteReader());
            Users users = new Users();
            foreach (DataRow item in table.Rows)
            {
                users.Id = int.Parse(item["id"].ToString());
                users.Username = item["username"].ToString();
                users.Password = item["password"].ToString();
                users.Ghichu = item["ghichu"].ToString();
                users.Name = item["name"].ToString();
                users.Role = item["roles"].ToString();
                users.Email = item["email"].ToString();
            }
            connection.Close();
            return users;
        }
        public static Users GetUsersByEmail(string email)
        {
            string query = "select * from Users where email = @email ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@email", email);
            DataTable table = new DataTable();
            table.Load(sqlCommand.ExecuteReader());
            Users users = new Users();
            foreach (DataRow item in table.Rows)
            {
                users.Id = int.Parse(item["id"].ToString());
                users.Username = item["username"].ToString();
                users.Password = item["password"].ToString();
                users.Ghichu = item["ghichu"].ToString();
                users.Name = item["name"].ToString();
                users.Role = item["roles"].ToString();
                users.Email = item["email"].ToString();
            }
            connection.Close();
            return users;
        }
        public static Users GetUsersByUserNameAndEmail(string username, string email)
        {
            string query = "select * from Users where username=@username and email = @email ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@username", username);
            DataTable table = new DataTable();
            table.Load(sqlCommand.ExecuteReader());
            if (table.Rows.Count == 0)
            {
                return null;
            }
            Users users = new Users();
            foreach (DataRow item in table.Rows)
            {
                users.Id = int.Parse(item["id"].ToString());
                users.Username = item["username"].ToString();
                users.Password = item["password"].ToString();
                users.Ghichu = item["ghichu"].ToString();
                users.Name = item["name"].ToString();
                users.Role = item["roles"].ToString();
                users.Email = item["email"].ToString();
            }
            connection.Close();
            return users;
        }

        public static void AddUsers(Users user)
        {
            string query = "insert into Users(name,username,password,ghichu,roles,email) values(@name,@username,@password,@ghichu,@role,@email)";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@username", user.Username);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            sqlCommand.Parameters.AddWithValue("@ghichu", user.Ghichu);
            sqlCommand.Parameters.AddWithValue("@name", user.Name);
            sqlCommand.Parameters.AddWithValue("@role", user.Role);
            sqlCommand.Parameters.AddWithValue("@email", user.Email);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static List<Users> getAllUsers()
        {
            string query = "select * from Users  ";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            List<Users> list = new List<Users>();
            foreach (DataRow item in table.Rows)
            {
                Users users = new Users();
                users.Id = int.Parse(item["id"].ToString());
                users.Username = item["username"].ToString();
                users.Password = item["password"].ToString();
                users.Ghichu = item["ghichu"].ToString();
                users.Name = item["name"].ToString();
                users.Role = item["roles"].ToString();
                users.Email = item["email"].ToString();
                list.Add(users);
            }
            connection.Close();
            return list;
        }

        public static void DeleteUsers(int id)
        {
            string query = "delete Users where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

        }

        public static void UpdateUsers(Users user)
        {
            string query = "update  Users set name = @name , username = @username" +
                ",password =@password,ghichu=@ghichu,roles=@role,email = @email where id = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", user.Name);
            sqlCommand.Parameters.AddWithValue("@username", user.Username);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            sqlCommand.Parameters.AddWithValue("@ghichu", user.Ghichu);
            sqlCommand.Parameters.AddWithValue("@role", user.Role);
            sqlCommand.Parameters.AddWithValue("@id", user.Id);
            sqlCommand.Parameters.AddWithValue("@email", user.Email);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

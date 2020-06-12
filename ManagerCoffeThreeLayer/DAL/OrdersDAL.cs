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
   public  class OrdersDAL
    {
        public static string stringConnection = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=OrderCoffe;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connect = new SqlConnection(stringConnection);
            return connect;
        }
        public static void CreateOrder(Orders orders)
        {
            //                            
            string query = "insert into Orders(dateOrder,totalorder,sales)   values(@date,@totalorder,@sales);";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@date", orders.Date);
            sqlCommand.Parameters.AddWithValue("@totalorder", orders.TotalPrice);
            sqlCommand.Parameters.AddWithValue("@sales", orders.Sales);
            sqlCommand.ExecuteNonQuery();


            connection.Close();


        }
        public static int GetIdOrder()
        {
            string query = "select max(id) from orders";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            int id = (int)sqlCommand.ExecuteScalar();
            connection.Close();
            return id;
        }


        public static List<Orders> getAllOrdersToDay(DateTime date)
        {
            List<Orders> list = new List<Orders>();
            string query = "select * from Orders where CONVERT(date,dateOrder)  = @date";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@date", date);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Orders orders = new Orders();
                orders.Id = int.Parse(item["id"].ToString());
                orders.TotalPrice = int.Parse(item["totalOrder"].ToString());
                orders.Date = DateTime.Parse(item["dateOrder"].ToString());
                orders.Sales = int.Parse(item["sales"].ToString());
                list.Add(orders);
            }
            connection.Close();
            return list;

        }
        public static Orders getOrderById(int id)
        {

            string query = "select * from Orders where id   = @id";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Orders orders = new Orders();
            foreach (DataRow item in table.Rows)
            {

                orders.Id = int.Parse(item["id"].ToString());
                orders.TotalPrice = int.Parse(item["totalOrder"].ToString());
                orders.Date = DateTime.Parse(item["dateOrder"].ToString());
                orders.Sales = int.Parse(item["sales"].ToString());

            }
            connection.Close();
            return orders;

        }
        public static int GetTotalOrder(DateTime dateStart, DateTime dateEnd)
        {

            string query = "select count(*) from Orders where CONVERT(date,dateOrder) between  @datestart and  @dateend";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@datestart", dateStart);
            adapter.SelectCommand.Parameters.AddWithValue("@dateend", dateEnd);
            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;
        }

        public static int GetTotalPriceOrder(DateTime dateStart, DateTime dateEnd)
        {

            string query = "select sum(totalOrder) from Orders where CONVERT(date,dateOrder) between  @datestart and  @dateend";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@datestart", dateStart);
            adapter.SelectCommand.Parameters.AddWithValue("@dateend", dateEnd);
            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;

        }
        public static List<Orders> getAllOrdersByDateToDate(DateTime dateStart, DateTime dateEnd)
        {
            List<Orders> list = new List<Orders>();
            string query = "select * from Orders where CONVERT(date,dateOrder) between  @datestart and  @dateend";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@datestart", dateStart);
            adapter.SelectCommand.Parameters.AddWithValue("@dateend", dateEnd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Orders orders = new Orders();
                orders.Id = int.Parse(item["id"].ToString());
                orders.TotalPrice = int.Parse(item["totalOrder"].ToString());
                orders.Date = DateTime.Parse(item["dateOrder"].ToString());
                orders.Sales = int.Parse(item["sales"].ToString());
                list.Add(orders);
            }
            connection.Close();
            return list;

        }
        ///////////
        ///
        /// 
        ///  
        /// 1

        public static int GetTotalOrderMonth(int month)
        {

            string query = "select count(*) from Orders where MONTH(dateOrder)  = @month";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);

            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;
        }

        public static int GetTotalPriceOrderMonth(int month)
        {

            string query = "select sum(totalOrder) from Orders where MONTH(dateOrder)  = @month";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@month", month);

            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;

        }
        public static List<Orders> getAllOrdersByMonth(int Month)
        {
            List<Orders> list = new List<Orders>();
            string query = "select * from Orders where  MONTH(dateOrder)  = @month";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@month", Month);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Orders orders = new Orders();
                orders.Id = int.Parse(item["id"].ToString());
                orders.TotalPrice = int.Parse(item["totalOrder"].ToString());
                orders.Date = DateTime.Parse(item["dateOrder"].ToString());
                orders.Sales = int.Parse(item["sales"].ToString());
                list.Add(orders);
            }
            connection.Close();
            return list;

        }
        public static int GetTotalOrderYear(int Year)
        {

            string query = "select count(*) from Orders where Year(dateOrder)  = @Year";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Year", Year);

            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;
        }

        public static int GetTotalPriceOrderYear(int Year)
        {

            string query = "select sum(totalOrder) from Orders where Year(dateOrder)  = @Year";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Year", Year);

            int count = (int)adapter.SelectCommand.ExecuteScalar();

            connection.Close();
            return count;

        }
        public static List<Orders> getAllOrdersByYear(int Year)
        {
            List<Orders> list = new List<Orders>();
            string query = "select * from Orders where  Year(dateOrder)  = @Year";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Year", Year);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                Orders orders = new Orders();
                orders.Id = int.Parse(item["id"].ToString());
                orders.TotalPrice = int.Parse(item["totalOrder"].ToString());
                orders.Date = DateTime.Parse(item["dateOrder"].ToString());
                orders.Sales = int.Parse(item["sales"].ToString());
                list.Add(orders);
            }
            connection.Close();
            return list;

        }
    }
}

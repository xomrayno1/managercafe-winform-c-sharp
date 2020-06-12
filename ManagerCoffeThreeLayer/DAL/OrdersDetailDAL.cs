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
    public class OrdersDetailDAL
    {
        public static string stringConnection = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=OrderCoffe;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connect = new SqlConnection(stringConnection);
            return connect;
        }
        public static void AddOrderDetail(OrderDetail detail)
        {
            string query = "insert into OrdersDetail values(@quantity,@total,@idorder,@idproduct);";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@quantity", detail.Quanity);
            sqlCommand.Parameters.AddWithValue("@total", detail.TotalPrice);
            sqlCommand.Parameters.AddWithValue("@idorder", detail.IdOrder);
            sqlCommand.Parameters.AddWithValue("@idproduct", detail.IdProducts);
            sqlCommand.ExecuteNonQuery();


            connection.Close();
        }
        public static List<OrderDetail> GetAllOrderDetailByIdOrder(int idOrder)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            string query = "select * from Ordersdetail where idorder = @idOrder";
            SqlConnection connection = getConnection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@idOrder", idOrder);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                OrderDetail detail = new OrderDetail();
                detail.Id = int.Parse(item["id"].ToString());
                detail.TotalPrice = int.Parse(item["totalprice"].ToString());
                detail.Quanity = int.Parse(item["quantity"].ToString());
                detail.IdOrder = int.Parse(item["idorder"].ToString());
                detail.IdProducts = int.Parse(item["idproduct"].ToString());

                list.Add(detail);
            }
            connection.Close();
            return list;

        }



        public static DataTable getSPChiTietMonth(int month, int year)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connect = getConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("ChiTietBanHangMonth", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}

using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class OrderDetailBus
    {
        public static void AddOrderDetail(OrderDetail detail)
        {

            OrdersDetailDAL.AddOrderDetail(detail);
        }
        public static List<OrderDetail> GetAllOrderDetailByIdOrder(int idOrder)
        {

            return OrdersDetailDAL.GetAllOrderDetailByIdOrder(idOrder); 

        }



        public static DataTable getSPChiTietMonth(int month, int year)
        {

            return OrdersDetailDAL.getSPChiTietMonth(month, year);
        }
    }
}

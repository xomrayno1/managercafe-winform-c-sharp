using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public  class OrdersBus
    {
        public static void CreateOrder(Orders orders)
        {
            //                            
            OrdersDAL.CreateOrder(orders);


        }
        public static int GetIdOrder()
        {
           return  OrdersDAL.GetIdOrder();
        }


        public static List<Orders> getAllOrdersToDay(DateTime date)
        {
            return OrdersDAL.getAllOrdersToDay(date);

        }
        public static Orders getOrderById(int id)
        {

            return OrdersDAL.getOrderById(id);

        }
        public static int GetTotalOrder(DateTime dateStart, DateTime dateEnd)
        {

            return OrdersDAL.GetTotalOrder(dateStart, dateEnd);
        }

        public static int GetTotalPriceOrder(DateTime dateStart, DateTime dateEnd)
        {

            return OrdersDAL.GetTotalPriceOrder(dateStart, dateEnd);

        }
        public static List<Orders> getAllOrdersByDateToDate(DateTime dateStart, DateTime dateEnd)
        {
            return OrdersDAL.getAllOrdersByDateToDate(dateStart, dateEnd);

        }

        public static int GetTotalOrderMonth(int month)
        {

            return OrdersDAL.GetTotalOrderMonth(month);
        }

        public static int GetTotalPriceOrderMonth(int month)
        {


            return OrdersDAL.GetTotalPriceOrderMonth(month);

        }
        public static List<Orders> getAllOrdersByMonth(int Month)
        {

            return OrdersDAL.getAllOrdersByMonth(Month);

        }
        public static int GetTotalOrderYear(int Year)
        {

            return OrdersDAL.GetTotalOrderYear(Year);
        }

        public static int GetTotalPriceOrderYear(int Year)
        {
            return OrdersDAL.GetTotalPriceOrderYear(Year); 

        }
        public static List<Orders> getAllOrdersByYear(int Year)
        {
            
            return OrdersDAL.getAllOrdersByYear(Year);

        }
    }
}

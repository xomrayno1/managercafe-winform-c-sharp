using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class Orders
    {
        private int id;
        private DateTime date;
        private int totalPrice;
        private int sales;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Sales
        {
            set { sales = value; }
            get { return sales; }

        }

        public int TotalPrice
        {
            set { totalPrice = value; }
            get { return totalPrice; }
        }
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }


    }
}

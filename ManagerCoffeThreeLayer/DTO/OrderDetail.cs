using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDetail
    {
        private int idProducts;
        private int quanity;
        private int totalPrice;
        private int idOrder;
        private int id;

        public int IdProducts
        {
            set { idProducts = value; }
            get { return idProducts; }

        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int Quanity
        {
            set { quanity = value; }
            get { return quanity; }
        }
        public int TotalPrice
        {
            set { totalPrice = value; }
            get { return totalPrice; }
        }
        public int IdOrder
        {
            set { idOrder = value; }
            get { return idOrder; }
        }

    }
}

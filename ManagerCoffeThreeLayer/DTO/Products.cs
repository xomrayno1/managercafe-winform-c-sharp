using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Products
    {
        private int id;
        private string name;
        private int price;
        private string describe;
        private int idCategory;
        private string type;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Describe
        {
            set { describe = value; }
            get { return describe; }
        }
        public string Type
        {
            set { type = value; }
            get { return type; }
        }
        public int Price
        {
            set { price = value; }
            get { return price; }
        }
        public int IdCategory
        {
            set { idCategory = value; }
            get { return idCategory; }
        }

    }
}

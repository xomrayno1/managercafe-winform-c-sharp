using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ProductsBus
    {
        public static List<Products> GetAllProducts()
        {
            return ProductsDAL.GetAllProducts();
        }
        public static Products GetProducts(string name)
        {
            return ProductsDAL.GetProducts( name);
        }
        public static Products GetProductsById(int id)
        {

            return ProductsDAL.GetProductsById( id);
        }
        public static Products GetProductsByName(string name)
        {

            return ProductsDAL.GetProductsByName( name);
        }
        public static List<Products> GetAllProductsBySearch(string search)
        {
            return ProductsDAL.GetAllProductsBySearch(search);
        }
        public static List<Products> GetAllProductsByCategory(int id)
        {
            return ProductsDAL.GetAllProductsByCategory(id);
        }
        public static void AddProducts(Products products)
        {
            ProductsDAL.AddProducts(products);
        }
        public static void UpdateProducts(Products products)
        {
            ProductsDAL.UpdateProducts(products);
        }
        public static void DeleteProducts(int id)
        {
            ProductsDAL.DeleteProducts(id);
        }
    }
}

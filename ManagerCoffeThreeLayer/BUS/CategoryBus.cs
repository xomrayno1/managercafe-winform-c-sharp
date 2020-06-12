using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CategoryBus
    {
        public static Category GetCategoryById(int id)
        {

            return CategoryDAL.GetCategoryById(id);
        }
        public static Category GetCategoryByName(string name)
        {

            return CategoryDAL.GetCategoryByName(name);
        }
        public static List<Category> GetAllCategory()
        {

            return CategoryDAL.GetAllCategory();
        }

        public static void AddCategory(Category category)
        {
            CategoryDAL.AddCategory(category);
        }
        public static void UpdateCategory(Category category)
        {
            CategoryDAL.UpdateCategory(category); 
        }
        public static List<Category> GetAllCategorysBySearch(string search)
        {
            return CategoryDAL.GetAllCategorysBySearch( search);
        }

        public static void DeleteCategory(int id)
        {
            CategoryDAL.DeleteCategory(id);
        }
    }
}

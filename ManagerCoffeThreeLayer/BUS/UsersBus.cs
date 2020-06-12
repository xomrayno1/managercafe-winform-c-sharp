using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UsersBus
    {
        public static bool CheckUsers(Users user)
        {
            return UsersDAL.CheckUsers(user);
        }
        public static Users GetUsersByUserName(string username)
        {
           
            return UsersDAL.GetUsersByUserName(username);
        }
        public static Users GetUsersByEmail(string email)
        {
            return UsersDAL.GetUsersByEmail(email);
        }
        public static Users GetUsersByUserNameAndEmail(string username, string email)
        {
            return UsersDAL.GetUsersByUserNameAndEmail(username, email);
        }

        public static void AddUsers(Users user)
        {
            UsersDAL.AddUsers(user);
        }

        public static List<Users> getAllUsers()
        {

            return UsersDAL.getAllUsers(); 
        }

        public static void DeleteUsers(int id)
        {
            UsersDAL.DeleteUsers(id);

        }

        public static void UpdateUsers(Users user)
        {
             UsersDAL.UpdateUsers(user);
        }
    }
}

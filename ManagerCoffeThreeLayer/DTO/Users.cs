using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Users
    {
        
            private int id;
            private string username;
            private string password;
            private string ghichu;
            private string name;
            private string role;
            private string email;

            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            public string Username
            {
                get { return username; }
                set { username = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            public string Ghichu
            {
                get { return ghichu; }
                set { ghichu = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Role
            {
                get { return role; }
                set { role = value; }
            }


        }
    
}

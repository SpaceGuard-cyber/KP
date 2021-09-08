using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP
{
    class DataUser
    {
        public int id_users { get; set; }

        private string login, password, email;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public DataUser() 
        {
            
        }

        public DataUser(string login, string password, string email) 
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}

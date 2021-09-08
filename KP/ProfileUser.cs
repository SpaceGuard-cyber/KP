using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP
{
    class ProfileUser
    {
        public int id_users { get; set; }

        public string user_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        public string user_lastname
        {
            get { return user_lastname; }
            set { user_lastname = value; }
        }

        public string user_secondname
        {
            get { return user_secondname; }
            set { user_secondname = value; }
        }

        public DateTime dataofbirth
        {
            get { return dataofbirth; }
            set { dataofbirth = value; }
        }

        public string email
        {
            get { return email; }
            set { email = value; }
        }


        public ProfileUser() 
        {

        }

        public ProfileUser(string user_name, string user_lastname, string user_secondname, string email, DateTime dataofbirth) 
        {
            this.user_name = user_name;
            this.user_lastname = user_lastname;
            this.user_secondname = user_secondname;
            this.email = email;
            this.dataofbirth = dataofbirth;
        }
    }
}

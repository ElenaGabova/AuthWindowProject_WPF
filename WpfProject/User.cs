using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject
{
    class User
    {
        public int id{ get; set; }

        private string login, pass, email;

        public string Login { get => login; set => login = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Email { get => email; set => email = value; }
        
        public User() {}
        public User(string Login, string Pass, string Email) {
            this.Login = Login;
            this.Pass = Pass;
            this.Email = Email;
        }


    }
}

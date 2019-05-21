using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLy.Entity
{
    public class Login
    {
        private string User;
        private string Pass;

        public Login()
        {
            User = "";
            Pass = "";
        }
        public Login(string user, string pass)
        {
            this.User = user;
            this.Pass = pass;
        }
        public string user
        {
            set {
                this.User = value;
            }
            get {
                return this.User;
            }
        }
        public string pass
        {
            set
            {
                this.Pass = value;
            }
            get
            {
                return this.Pass;
            }
        }
    }
    
}

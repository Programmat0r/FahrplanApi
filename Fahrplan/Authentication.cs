using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
    class Authentication
    {
        
        public String TokenBearer { get; private set; }
        public String Username { get; private set; }
        public String Password { get; private set; }
        public enum AuthenticationType
        {
            Bearer,
            UsernamePassword
        }
        public Authentication(String tokenBearer)
        {
            if (tokenBearer is null || tokenBearer == "")
                throw new ArgumentNullException("TokenBearer can't be empty");
            this.TokenBearer = tokenBearer;
        }

        public Authentication(String username, String password)
        {
            if (username is null || password is null || username == "" || password == "")
                throw new ArgumentNullException("Username and Password can't be empty");
            
            this.Username = username;
            this.Password = password;
        }
       

    }
}

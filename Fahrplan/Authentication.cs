using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
   public class Authentication
    {
        
        public String TokenBearer { get; private set; }


        public Authentication(String tokenBearer)
        {
            if (tokenBearer is null || tokenBearer == "")
                throw new ArgumentNullException("TokenBearer can't be empty");
            this.TokenBearer = tokenBearer;
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
   public class Api
    {
        public static String GetEndpoint(bool testMode)
        {
            if (testMode)
                return "https://api.deutschebahn.com/freeplan/v1/";

            return "https://api.deutschebahn.com/fahrplan-plus/v1/";
        }
    }
}

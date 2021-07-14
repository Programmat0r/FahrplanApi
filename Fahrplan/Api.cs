using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
   public class Api
    {
        public static String GetEndpoint(bool testMode, bool secure = true)
        {

            String endpoint = "";

            if (secure)
            {
                endpoint = "https://";
            } else
            {
                endpoint = "http://";
            }

            if (testMode)
            {
                return endpoint + "api.deutschebahn.com/freeplan/v1/";
            } else
            {
                return endpoint + "api.deutschebahn.com/fahrplan-plus/v1/";
            }

        }
    }
}

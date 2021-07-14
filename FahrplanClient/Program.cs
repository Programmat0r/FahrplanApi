using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrplan;

namespace FahrplanClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String token = File.ReadAllText("Token.key");

            // LocationApi locationApi = new Fahrplan.LocationApi("Frankfurt", new Authentication(token));
            //var locations = locationApi.Get();
            ArrivalBoardApi arrivalBoardApi = new ArrivalBoardApi("8096021", new Authentication(token), DateTime.Now);
            var boards = arrivalBoardApi.Get();

        }
    }
}

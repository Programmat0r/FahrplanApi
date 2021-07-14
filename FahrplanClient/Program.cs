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
            //  DepartureBoardApi departureBoardApi = new DepartureBoardApi("8096021", new Authentication(token), DateTime.Now);
            //var boards = departureBoardApi.Get();
            JourneyDetailsApi journeyDetailsApi = new JourneyDetailsApi("156462%252F58512%252F820424%252F358058%252F80%253fstation_evaId%253D8000105", new Authentication(token));
            var journeyDetails = journeyDetailsApi.Get();
        }
    }
}

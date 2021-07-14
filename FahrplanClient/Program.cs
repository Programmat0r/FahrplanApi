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

            //Get all locations containing "Frankfurt"
            var locationApi = new LocationApi("Frankfurt", new Authentication(token));
            locationApi.TestMode = true;
            locationApi.SecureConnection = true;
            var locations = locationApi.Get();

            //Pass the id of a location to get the arrival board of the given location
            var arrivalBoardApi = new ArrivalBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
            arrivalBoardApi.TestMode = true;
            arrivalBoardApi.SecureConnection = true;
            var arrivals = arrivalBoardApi.Get();

            //Pass the id of a location to get the departure board of the given location
            var departureBoardApi = new DepartureBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
            departureBoardApi.TestMode = true;
            departureBoardApi.SecureConnection = true;
            var departures = departureBoardApi.Get();

            //Pass the DetailsId of an arrival board or departure board entry to get the details of the given journey
            var journeyDetailsApi = new JourneyDetailsApi(arrivals[0].DetailsId, new Authentication(token));
            journeyDetailsApi.TestMode = true;
            journeyDetailsApi.SecureConnection = true;
            var journeyDetails = journeyDetailsApi.Get();
        }
    }
}

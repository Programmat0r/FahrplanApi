using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrplan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fahrplan.Tests
{
    [TestClass()]
    public class JourneyDetailsApiTests
    {

        private String Token;
        public JourneyDetailsApiTests()
        {
            this.Token = File.ReadAllText("Token.key");
        }
    
      
        [TestMethod()]
        public void Journey_Details_Api_Test_No_Id()
        {
            Assert.ThrowsException<ArgumentException>(() => new JourneyDetailsApi(" ", null));

        }

        [TestMethod()]
        public void Journey_Details_Api_Test_No_Authentication()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new JourneyDetailsApi("156462%252F58512%252F820424%252F358058%252F80%253fstation_evaId%253D8000105", null));

        }

        [TestMethod()]
        public void Get_Test()
        {
            LocationApi locationApi = new Fahrplan.LocationApi("Frankfurt", new Authentication(this.Token));
            locationApi.TestMode = true;
            var locations = locationApi.Get();

            DepartureBoardApi departureBoardApi = new DepartureBoardApi(locations[0].Id, new Authentication(this.Token), new DateTime(2021, 1, 1, 10, 00, 00));
            departureBoardApi.TestMode = true;
            var boards = departureBoardApi.Get();

            var journeyDetailsApi = new JourneyDetailsApi(boards[0].DetailsId, new Authentication(this.Token));
            journeyDetailsApi.TestMode = true;
            journeyDetailsApi.SecureConnection = true;
            var journeyDetails = journeyDetailsApi.Get();
    

            Assert.IsNotNull(journeyDetails);
        }
    }
}
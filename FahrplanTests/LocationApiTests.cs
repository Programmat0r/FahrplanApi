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
    public class LocationApiTests
    {
        private String Token;
        public LocationApiTests()
        {
            this.Token = File.ReadAllText("Token.key");
        }
        [TestMethod()]
        public void Get_Test()
        {

            LocationApi locationApi = new Fahrplan.LocationApi("Frankfurt", new Authentication(this.Token));
            var locations = locationApi.Get();

            Assert.AreEqual(locations.Length, 10);
        }

        [TestMethod()]
        public void Location_Api_Test_No_Locationname()
        {

            Assert.ThrowsException<ArgumentException>(() => new LocationApi(" ", null));
        }

        [TestMethod()]
        public void Location_Api_Test_No_Authentication()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new LocationApi("Frankfurt", null));
        }
    }
}
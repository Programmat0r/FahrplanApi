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


    public class DepartureBoardApiTests
    {

        private String Token;
        public DepartureBoardApiTests()
        {
            this.Token = File.ReadAllText("Token.key");
        }

        [TestMethod()]
        public void Get_Test()
        {
            DepartureBoardApi departureBoardApi = new DepartureBoardApi("8096021", new Authentication(this.Token), new DateTime(2021, 1, 1, 10, 00, 00));
            departureBoardApi.TestMode = true;
            var boards = departureBoardApi.Get();
            
            Assert.AreEqual(boards.Length, 20);
        }

        [TestMethod()]
        public void Departure_Board_Api_Test_No_Id()
        {
            Assert.ThrowsException<ArgumentException>(() => new DepartureBoardApi(" ", null, DateTime.Now));

        }

        [TestMethod()]
        public void Departure_Board_Api_Test_No_Authentication()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new DepartureBoardApi("8096021", null, DateTime.Now));

        }

      
    }
}
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
    public class ArrivalBoardApiTests
    {

        private String Token;
        public ArrivalBoardApiTests()
        {
            this.Token = File.ReadAllText("Token.key");
        }

        [TestMethod()]
        public void Arrival_Board_Api_Test_No_Id()
        {
            Assert.ThrowsException<ArgumentException>(() => new ArrivalBoardApi(" ", null, DateTime.Now));

        }

        [TestMethod()]
        public void Arrival_Board_Api_Test_No_Authentication()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ArrivalBoardApi("8096021", null, DateTime.Now));

        }

        [TestMethod()]
        public void Get_Test()
        {
            ArrivalBoardApi arrivalBoardApi = new ArrivalBoardApi("8096021", new Authentication(this.Token), new DateTime(2021, 1, 1, 10, 00, 00));
            arrivalBoardApi.TestMode = true;
            var boards = arrivalBoardApi.Get();

            Assert.IsNotNull(boards);

        }
    }
}
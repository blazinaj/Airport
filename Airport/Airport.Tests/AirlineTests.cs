using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace Airport.Tests
{
    [TestClass]
    public class AirlineTests
    {
        SystemManager testManager = new SystemManager();

        [TestMethod]
        public void Create_Airline_Name_More_Than_Five_Letters_Fails()
        {
            string result = testManager.CreateAirline("FRONTIER");

            Assert.AreEqual("Error: Airline name: FRONTIER is longer than 5 letters!", result);
        }

        [TestMethod]
        public void Create_Airline_Success()
        {
            string result = testManager.CreateAirline("FRONT");

            Assert.AreEqual("Success: Airline FRONT Created!", result);
        }

        [TestMethod]
        public void Create_Airline_Name_Already_Exists_Fails()
        {
            string result = testManager.CreateAirline("FRONT");
            Assert.AreEqual("Success: Airline FRONT Created!", result);

            result = testManager.CreateAirline("FRONT");
            Assert.AreEqual("Error: Airline name: FRONT is already exists!", result);
        }
    }
}

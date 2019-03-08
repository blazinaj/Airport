using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Airport.Tests
{
    class AirlineTests
    {
        SystemManager testManager = new SystemManager();

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airline_Name_More_Than_Five_Letters_Fails()
        {
            string result = testManager.createAirline("FRONTIER");

            Assert.AreEqual("Error: Airline name: FRONTIER is longer than 5 letters!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airline_Success()
        {
            string result = testManager.createAirline("FRONT");

            Assert.AreEqual("Success: Airline FRONT Created!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Airline_Name_Already_Exists_Fails()
        {
            string result = testManager.createAirline("FRONT");

            Assert.AreEqual("Error: Airline name: FRONT is already exists!", result);
        }
    }
}

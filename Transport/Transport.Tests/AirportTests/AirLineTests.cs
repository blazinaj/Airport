using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.AirportTests
{
    [TestClass]
    public class AirLineTests
    {
        SystemFactory testFactory = new AirportFactory();

        [TestInitialize]
        public void Init()
        {
            testFactory.CreatePort("DEN");
            testFactory.CreatePort("LON");
        }

        [TestMethod]
        public void Create_AirLine_Success()
        {
            (Line newLine, string result) = testFactory.CreateLine("FRONT");

            Assert.AreEqual("Success: AirLine FRONT Successfully Created!", result);
        }

        [TestMethod]
        public void Create_AirLine_Name_Greater_Than_Five_Letters_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("FRONTIER");

            Assert.AreEqual("Error: Cannot create AirLine FRONTIER, maximum name length is 5 letters!", result);
        }

        [TestMethod]
        public void Create_AirLine_Name_Less_Than_1_Letter_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("");

            Assert.AreEqual("Error: Cannot create AirLine , minumum name length is 1 letters!", result);
        }

        [TestMethod]
        public void Create_AirLine_Name_Contains_Spaces_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("FR ON");

            Assert.AreEqual("Error: Cannot create AirLine FR ON, name cannot contain spaces!", result);
        }
    }
}

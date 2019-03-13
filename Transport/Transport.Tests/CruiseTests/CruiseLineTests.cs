using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.TrainTests
{
    [TestClass]
    public class CruiseLineTests
    {
        SystemFactory testFactory = new CruiseFactory();

        [TestMethod]
        public void Create_CruiseLine_Success()
        {
            (Line newLine, string result) = testFactory.CreateLine("Disney Cruises");

            Assert.AreEqual("Success: CruiseLine Disney Cruises Successfully Created!", result);
        }

        [TestMethod]
        public void Create_CruiseLine_Name_Greater_Than_Ten_Letters_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("This Is A Way Too Long Name For A Cruise Line");

            Assert.AreEqual("Error: Cannot create CruiseLine This Is A Way Too Long Name For A Cruise Line, maximum name length is 15 letters!", result);
        }

        [TestMethod]
        public void Create_CruiseLine_Name_Less_Than_1_Letter_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("");

            Assert.AreEqual("Error: Cannot create CruiseLine , minumum name length is 1 letters!", result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.TrainTests
{
    [TestClass]
    public class TrainLineTests
    {
        SystemFactory testFactory = new TrainFactory();

        [TestMethod]
        public void Create_TrainLine_Success()
        {
            (Line newLine, string result) = testFactory.CreateLine("BNSF Line");

            Assert.AreEqual("Success: TrainLine BNSF Line Successfully Created!", result);
        }

        [TestMethod]
        public void Create_TrainLine_Name_Greater_Than_Ten_Letters_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("This Is A Way Too Long Name For A Train Line");

            Assert.AreEqual("Error: Cannot create TrainLine This Is A Way Too Long Name For A Train Line, maximum name length is 10 letters!", result);
        }

        [TestMethod]
        public void Create_AirLine_Name_Less_Than_1_Letter_Fails()
        {
            (Line newLine, string result) = testFactory.CreateLine("");

            Assert.AreEqual("Error: Cannot create TrainLine , minumum name length is 1 letters!", result);
        }
    }
}

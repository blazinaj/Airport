using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.AirportTests
{
    [TestClass]
    public class AirportTests
    {
        [TestMethod]
        public void Create_Airport_Success()
        {
            string result = SystemManager.airFactory.CreatePort("DEN");

            Assert.AreEqual("Success: AirPort DEN Successfully Created!", result);
        }
    }
}

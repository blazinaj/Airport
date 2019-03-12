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
            SystemFactory factory = new AirportFactory();

            var airport = factory.CreatePort("DEN");

            Assert.AreEqual("AirPort: DEN", airport.DisplaySystemDetails());
        }
    }
}

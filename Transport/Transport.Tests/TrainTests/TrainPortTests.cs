using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.AirportTests
{
    [TestClass]
    public class TrainPortTests
    {
        [TestMethod]
        public void Create_TrainPort_Success()
        {
            SystemFactory factory = new TrainFactory();

            string result = factory.CreatePort("London Train Station");

            Assert.AreEqual("Success: TrainPort London Train Station Successfully Created!", result);
        }
    }
}

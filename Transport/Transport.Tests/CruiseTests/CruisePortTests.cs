using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Factories;

namespace Transport.Tests.CruiseTests
{
    [TestClass]
    public class CruisePortTests
    {
        [TestMethod]
        public void Create_CruisePort_Success()
        {
            SystemFactory factory = new CruiseFactory();

            (Port port, string result) = factory.CreatePort("Puget Sound Cruise Dock");

            Assert.AreEqual("Success: CruisePort Puget Sound Cruise Dock Successfully Created!", result);
        }
    }
}

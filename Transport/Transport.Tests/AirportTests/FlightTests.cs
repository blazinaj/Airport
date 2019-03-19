using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Tests.AirportTests
{
    [TestClass]
    public class FlightTests
    {
        [TestInitialize]
        public void Init()
        {
            SystemManager.airFactory.CreatePort("DEN");
            SystemManager.airFactory.CreatePort("LON");
            SystemManager.airFactory.CreateLine("FRONT");
        }
        [TestMethod]
        public void Create_Flight_Success()
        {
            string result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2020, 10, 20, 10, 10, "flight77777");

            Assert.AreEqual("Success: Flight flight77777 Successfully Created!", result);
        }

        [TestMethod]
        public void Create_Flight_Invalid_AirLine_Fails()
        {
            string result = SystemManager.airFactory.CreateTrip("INVALID", "DEN", "LON", 2020, 10, 20, 10, 10, "flight7891");

            Assert.AreEqual("Error: AirLine INVALID does not exist!", result);
        }

        [TestMethod]
        public void Create_Flight_Invalid_AirPort_Fails()
        {
            string result = SystemManager.airFactory.CreateTrip("FRONT", "INVALID-ORIGIN", "LON", 2020, 10, 20, 10, 10, "flight9999");

            Assert.AreEqual("Error: AirPort INVALID-ORIGIN does not exist!", result);

            result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "INVALID-DEST", 2020, 10, 20, 10, 10, "flight99999");

            Assert.AreEqual("Error: AirPort INVALID-DEST does not exist!", result);
        }

        [TestMethod]
        public void Create_Flight_Date_Fails()
        {
            string result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2018, 10, 20, 10, 10, "flight789");

            Assert.AreEqual("Error: Year: 2018 is invalid!", result);

            result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2020, 13, 20, 10, 10, "flight345");

            Assert.AreEqual("Error: Month: 13 is invalid!", result);

            result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2020, 10, 0, 10, 10, "flight678");

            Assert.AreEqual("Error: Day: 0 is invalid!", result);
        }

        [TestMethod]
        public void Create_Flight_ID_Exists_Fails()
        {
            SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2019, 10, 20, 10, 10, "flight11111");
            string result = SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2019, 10, 20, 10, 10, "flight11111");

            Assert.AreEqual("Error: Trip (flight11111) already exists!", result);
        }
    }
}

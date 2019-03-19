using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Tests.AirportTests
{
    [TestClass]
    public class AirSectionTests
    {
        [TestInitialize]
        public void Init()
        {
            SystemManager.airFactory.CreatePort("DEN");
            SystemManager.airFactory.CreatePort("LON");
            SystemManager.airFactory.CreateLine("FRONT");
            SystemManager.airFactory.CreateTrip("FRONT", "DEN", "LON", 2020, 01, 25, 10, 30, "flight123");
        }

        [TestMethod]
        public void Create_Section_Success()
        {
            string result = SystemManager.airFactory.CreateSection("FRONT", "flight123", 5, 'S', SeatClass.E, 200);

            Assert.AreEqual("Success: Flight Section (5 rows, S layout) with Seat Class E and price 200 on Flight flight123 with FRONT airline  Created!", result);
        }

        [TestMethod]
        public void Create_Section_Airline_Doesnt_Exist_Fails()
        {
            string result = SystemManager.airFactory.CreateSection("DOESNTEXIST", "flight0000", 5, 'S', SeatClass.E, 200);

            Assert.AreEqual("Error: DOESNTEXIST does not exist!", result);
        }

        [TestMethod]
        public void Create_Section_Flight_Doesnt_Exist_Fails()
        {
            string result = SystemManager.airFactory.CreateSection("FRONT", "DOESNTEXIST", 5, 'S', SeatClass.E, 200);

            Assert.AreEqual("Error: DOESNTEXIST does not exist!", result);
        }
    }
}

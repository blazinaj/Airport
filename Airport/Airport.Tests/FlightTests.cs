using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class FlightTests
    {
        SystemManager testManager = new SystemManager();

        [TestMethod]
        public void Create_Flight_Success()
        {
            string result = testManager.CreateFlight("DELTA", "DEN", "LON", 2018, 10, 10, "123");

            Assert.AreEqual("Success: Flight 123 Created!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Flight_Same_Origin_And_Dest_Fails()
        {
            string result = testManager.CreateFlight("DELTA", "DEN", "DEN", 2018, 8, 8, "567abc");

            Assert.AreEqual("Error: You cannot have the same Origin (DEN) and Destination (DEN) Airports!", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Flight_Invalid_Date_Fails()
        {
            // Invalid Month
            string result = testManager.CreateFlight("AMER", "DEN", "LON", 2010, 40, 10, "123abc");
            Assert.AreEqual("invalid month", result);

            // Invalid Day
            result = testManager.CreateFlight("AMER", "DEN", "LON", 2010, 10, 400, "123abc");
            Assert.AreEqual("Invalid day", result);

            // Invalid Year
            result = testManager.CreateFlight("AMER", "DEN", "LON", 199d, 10, 20, "123abc");
            Assert.AreEqual("Invalid Year", result);

            // Invalid Date: inputted a past date
            result = testManager.CreateFlight("AMER", "DEN", "LON", 2018, 10, 20, "123abc");
            Assert.AreEqual("Date is in past", result);
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Flight_Invalid_Airline_Fails()
        {

        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_Flight_Invalid_Airport_Fails()
        {

        }
    }
}

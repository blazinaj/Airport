using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class FlightSectionTests
    {
        //res.CreateSection("DELTA","123", 2, 2, SeatClass.economy);
        //res.CreateSection("DELTA","123", 2, 3, SeatClass.first);
        //res.CreateSection("DELTA","123", 2, 3, SeatClass.first);//Invalid
        //res.CreateSection("SWSERTT","123", 5, 5, SeatClass.economy);//Invalid airline

        SystemManager testManager = new SystemManager();
        [TestInitialize]
        public void Init()
        {
            testManager.CreateAirport("DEN");
            testManager.CreateAirport("LON");
            testManager.CreateAirline("DELTA");
            testManager.CreateFlight("DELTA", "DEN", "LON", 2019, 10, 19, "123");
        }
        [TestMethod]
        public void Create_FlightSection_Success()
        {
            string result = testManager.CreateSection("DELTA", "123", 2, 2, SeatClass.economy);

            Assert.AreEqual("Success: Flight Section (2 rows, 2 cols) with Seat Class economy on Flight 123 with DELTA airline  Created!", result);
        }

        [TestMethod]
        public void Create_FlightSection_Invalid_Airline_Fails()
        {
            string result = testManager.CreateSection("SWSERTT", "123", 5, 5, SeatClass.economy);

            Assert.AreEqual("Error: The Airline SWSERTT Does Not Exist!", result);
        }

        [TestMethod]
        public void Create_FlightSection_SeatClass_Already_Exists()
        {
            testManager.CreateSection("DELTA", "123", 2, 3, SeatClass.first);
            string result = testManager.CreateSection("DELTA", "123", 2, 3, SeatClass.first);
            Assert.AreEqual("Error: A flight section with Seat Class first already exists on Flight 123 with DELTA airline!", result);
        }

        //[TestMethod]
        //public void Create_FlightSection_Invalid_SeatClass_Fails()
        //{
        //    testManager.CreateSection("DELTA", "123", 2, 3, SeatClass.second);
        //    Assert.AreEqual("temp", "fails");
        //}

        [TestMethod]
        public void Create_FlightSection_Invalid_Flight_Fails()
        {
            string result = testManager.CreateSection("DELTA", "123fail", 5, 5, SeatClass.economy);
            Assert.AreEqual("Error: The Flight 123fail associated with the Airline DELTA Does Not Exist!", result);
        }

        [TestMethod]
        public void Create_FlightSection_Invalid_Rows_Or_Cols_Fails()
        {
            string result = testManager.CreateSection("DELTA", "123", -1, 5, SeatClass.economy);
            Assert.AreEqual("Error: You must have between 1 and 100 rows!", result);

            result = testManager.CreateSection("DELTA", "123", 101, 5, SeatClass.economy);
            Assert.AreEqual("Error: You must have between 1 and 100 rows!", result);

            result = testManager.CreateSection("DELTA", "123", 1, 11, SeatClass.economy);
            Assert.AreEqual("Error: You must have between 1 and 10 columns!", result);

            result = testManager.CreateSection("DELTA", "123", 1, 0, SeatClass.economy);
            Assert.AreEqual("Error: You must have between 1 and 10 columns!", result);
        }
    }
}

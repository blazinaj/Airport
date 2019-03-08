using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class FlightSectionTests
    {
        //res.CreateSection("DELTA","123", 2, 2, SeatClass.economy);
        //  res.CreateSection("DELTA","123", 2, 3, SeatClass.first);
        //res.CreateSection("DELTA","123", 2, 3, SeatClass.first);//Invalid
        //res.CreateSection("SWSERTT","123", 5, 5, SeatClass.economy);//Invalid airline

        SystemManager testManager = new SystemManager();
        
        [TestMethod]
        public void Create_FlightSection_Success()
        {
            Assert.AreEqual("temp", "fails");
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_FlightSection_Invalid_Airline_Fails()
        {
            Assert.AreEqual("temp", "fails");
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_FlightSection_SeatClass_Already_Exists()
        {
            Assert.AreEqual("temp", "fails");
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_FlightSection_Invalid_SeatClass_Fails()
        {
            Assert.AreEqual("temp", "fails");
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_FlightSection_Invalid_Flight_Fails()
        {
            Assert.AreEqual("temp", "fails");
        }

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Create_FlightSection_Invalid_Rows_Or_Cols_Fails()
        {
            Assert.AreEqual("temp", "fails");
        }
    }
}

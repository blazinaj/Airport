using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Airport.Tests
{
    [TestClass]
    public class SeatTests
    {
            //res.BookSeat("DELTA", "123", SeatClass.first, 1, 'A');
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'A');
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'B');
            //res.BookSeat("DELTA888", "123", SeatClass.business, 1, 'A'); //Invalid airline
            //res.BookSeat("DELTA", "123haha7", SeatClass.business, 1, 'A'); //Invalid flightId
            //res.BookSeat("DELTA", "123", SeatClass.economy, 1, 'A'); //already booked

        SystemManager testManager = new SystemManager();

        [TestInitialize]
        public void Init()
        {
            testManager.CreateAirport("DEN");
            testManager.CreateAirport("LON");
            testManager.CreateAirline("DELTA");
            testManager.CreateFlight("DELTA", "DEN", "LON", 2019, 10, 19, "123");
            testManager.CreateSection("DELTA", "123", 2, 2, SeatClass.economy);
        }

        [TestMethod]
        public void Book_Seat_Success()
        {
            string result;
            //result = testManager.BookSeat("DELTA", "123", SeatClass.economy, 1, 'A');
            //Assert.AreEqual("Success: Seat (A1) with Seat Class economy on Flight 123 with DELTA airline  Booked!", result);

            //result = testManager.BookSeat("DELTA", "123", SeatClass.first, 1, 'A');
            //Assert.AreEqual("Success: Seat (A1) with Seat Class first on Flight 123 with DELTA airline  Booked!", result);

            result = testManager.BookSeat("DELTA", "123", SeatClass.economy, 1, 'B');
            Assert.AreEqual("Success: Seat (B1) with Seat Class economy on Flight 123 with DELTA airline  Booked!", result);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}

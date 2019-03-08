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

        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void Book_Seat_Success()
        {
            Assert.AreEqual("temp", "fails");
        }
    }
}

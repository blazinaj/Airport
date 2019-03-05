namespace Airport
{
    public class FlightSection
    {
        private string air;
        private string flId;
        private int rows;
        private int cols;
        internal SeatClass seatClass = SeatClass.economy;

        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            this.air = air;
            this.flId = flId;
            this.rows = rows;
            this.cols = cols;
            this.seatClass = seatClass;
        }

        public bool HasAvailableSeats()
        {
            return false;
        }

        public void BookSeat()
        {

        }
    }
}
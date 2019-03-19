namespace Transport
{
    public class Seat
    {
        internal string Line { get; set; }
        internal string TripId { get; set; }
        internal int RowNumber { get; set; }
        internal char ColumnCharacter { get; set; }
        internal bool IsBooked { get; set; }
        internal SeatType Type { get; set; }

        public enum SeatType
        {
            window,
            aisle
        }

        public Seat(string line, string tripId, int row, char col, bool isBooked, SeatType type)
        {
            Line = line;
            TripId = tripId;
            RowNumber = row;
            ColumnCharacter = col;
            IsBooked = isBooked;
        }


    }
}
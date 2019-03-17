namespace Transport
{
    public class Seat
    {
        internal string Line { get; set; }
        internal string TripId { get; set; }
        internal int RowNumber { get; set; }
        internal char ColumnCharacter { get; set; }
        internal bool IsBooked { get; set; }

        public Seat(string line, string tripId, int row, char col, bool isBooked)
        {
            Line = line;
            TripId = tripId;
            RowNumber = row;
            ColumnCharacter = col;
            IsBooked = isBooked;
        }


    }
}
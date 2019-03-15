namespace Transport
{
    public class Seat
    {
        internal int RowNumber { get; set; }
        internal char ColumnCharacter { get; set; }
        internal bool IsBooked { get; set; }

        public Seat(int row, char col, bool isBooked)
        {
            RowNumber = row;
            ColumnCharacter = col;
            IsBooked = isBooked;
        }


    }
}
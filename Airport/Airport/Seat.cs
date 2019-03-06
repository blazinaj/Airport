using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class Seat
    {
        public int RowNumber { get; set; }
        public char ColumnCharacter { get; set; }
        public bool IsBooked { get; set; }

        public Seat(int row, char col, bool isBooked)
        {
            RowNumber = row;
            ColumnCharacter = col;
            IsBooked = isBooked;
        }

        public override string ToString()
        {
            return "Seat " + ColumnCharacter+RowNumber;
        }
    }
}

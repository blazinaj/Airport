using System;
using System.Collections.Generic;
using System.Text;

namespace Airport
{
    class Seat
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

        public string DisplaySystemDetails()
        {
            string result = "Seat " + ColumnCharacter + RowNumber + ", Is Booked: " + IsBooked;
            Console.WriteLine(result);
            return result;
        }

        public override string ToString()
        {
            return "Seat " + ColumnCharacter+RowNumber;
        }
    }
}

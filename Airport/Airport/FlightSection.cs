using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport
{
    public class FlightSection : IDisplaySystemDetails
    {
        private string air;
        private string flId;
        public int rows;
        public int cols;
        public SeatClass seatClass = SeatClass.economy;

        internal List<Seat> BookedSeatsList { get; set; } = new List<Seat>();

        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
        {
            this.air = air;
            this.flId = flId;
            this.rows = rows;
            this.cols = cols;
            this.seatClass = seatClass;

            for (int i = 1; i <= cols; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    BookedSeatsList.Add(new Seat(j, (char)((i-1)+65), false));
                }
               
            }   
        }

        public bool HasAvailableSeats()
        {
            var booked = false;

            foreach (var seat in BookedSeatsList)
            {
               booked = seat.IsBooked;
            }

            return booked;
        }

        public void BookSeat(string air, string fId, SeatClass s, int row, char col)
        {
            BookedSeatsList.Where(x=> (x.ColumnCharacter == col) && (x.RowNumber == row) && (x.IsBooked == false)).ToList().ForEach(x=>x.IsBooked = true);

//            BookedSeatsList.Add(new Seat(row, col, true));
            Console.WriteLine("Success: Seat (" + col + row+ ") with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Booked!");
        }

        public override string ToString()
        {
            return "Available Sections for: Flight " + flId + " " + air+" airline" + " Seat Class " + seatClass + " with "+rows+" rows and " + cols+ " columns" ;
        }

        public void DisplaySystemDetails()
        {
            foreach (var seat in BookedSeatsList)
            {
                Console.WriteLine(seat.ToString());
            }
        }
    }
}
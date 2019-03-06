using System;
using System.Collections.Generic;

namespace Airport
{
    public class FlightSection : IDisplaySystemDetails
    {
        private string air;
        private string flId;
        private int rows;
        private int cols;
        internal SeatClass seatClass = SeatClass.economy;

        internal List<Seat> BookedSeatsList { get; set; } = new List<Seat>();

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
            foreach (var seat in BookedSeatsList)
            {
                
            }

            return false;
        }

        public void BookSeat(string air, string fId, SeatClass s, int row, char col)
        {
            BookedSeatsList.Add(new Seat(row, col, true));
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
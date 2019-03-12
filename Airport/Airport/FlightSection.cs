//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Airport
//{
//    public class FlightSection : IDisplaySystemDetails
//    {
//        private string air;
//        private string flId;
//        private int rows;
//        private int cols;
//        internal SeatClass seatClass = SeatClass.economy;

//        internal List<Seat> BookedSeatsList { get; set; } = new List<Seat>();

//        public FlightSection(string air, string flId, int rows, int cols, SeatClass seatClass)
//        {
//            this.air = air;
//            this.flId = flId;
//            this.rows = rows;
//            this.cols = cols;
//            this.seatClass = seatClass;

//            for (int i = 1; i <= cols; i++)
//            {
//                for (int j = 1; j <= rows; j++)
//                {
//                    BookedSeatsList.Add(new Seat(j, (char)((i-1)+65), false));
//                }
               
//            }   
//        }

//        private bool HasAvailableSeats()
//        {
//            var booked = false;

//            foreach (var seat in BookedSeatsList)
//            {
//               booked = seat.IsBooked;
//            }

//            return booked;
//        }

//        internal string BookSeat(string air, string fId, SeatClass s, int row, char col)
//        {
//            string result;
//            BookedSeatsList.Where(x => (x.ColumnCharacter == col) && (x.RowNumber == row) && (x.IsBooked == false)).ToList().ForEach(x => x.IsBooked = true);
//            result = "Success: Seat (" + col + row + ") with Seat Class " + seatClass + " on Flight " + flId + " with " + air + " airline " + " Booked!";
//            Console.WriteLine(result);
//            return result;
//        }

//        public override string ToString()
//        {
//            return "Flight Section " + seatClass + " class for Flight " + flId + " on " + air + " with " + rows + " rows and " + cols + " columns.";
//        }

//        public string DisplaySystemDetails()
//        {
//            string result = "";
//            result = ToString();
//            Console.WriteLine(result);
//            foreach (var seat in BookedSeatsList)
//            {
//                seat.DisplaySystemDetails();
//            }
//            Console.WriteLine();
//            return result;
//        }
//    }
//}
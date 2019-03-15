using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transport.Trips
{
    public class TripSection
    {
        private string line;
        private string tripId;
        private int rows;
        private int cols;
        private int price;
        internal SeatClass seatClass = SeatClass.E;

        public TripSection(string line, string tripId, int rows, int cols, SeatClass seatClass, int price)
        {
            this.line = line;
            this.tripId = tripId;
            this.rows = rows;
            this.cols = cols;
            this.seatClass = seatClass;
            this.price = price;

            for (int i = 1; i <= cols; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    SystemInformation systemInformation = new SystemInformation();
                    systemInformation.BookedSeatsList.Add(new Seat(j, (char)((i - 1) + 65), false));
                }

            }
        }
    }
}

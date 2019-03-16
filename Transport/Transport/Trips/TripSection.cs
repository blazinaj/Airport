using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transport.Trips
{
    public class TripSection
    {
        public string line;
        public string tripId;
        public int rows;
        public char cols;
        public int price;
        internal SeatClass seatClass = SeatClass.E;

        public TripSection(string line, string tripId, int rows, char cols, SeatClass seatClass, int price)
        {
            this.line = line;
            this.tripId = tripId;
            this.rows = rows;
            this.cols = cols;
            this.seatClass = seatClass;
            this.price = price;

            int columnCheck = ColumnCheck(cols);

            for (int i = 1; i <= columnCheck; i++)
            {
                for (int j = 1; j <= rows; j++)
                {    
                    SystemManager.airportInformation.BookedSeatsList.Add(new Seat(line, tripId, j, cols, false));
                }

            }
        }

        public int ColumnCheck(char cols)
        {
            if (cols == 'S')
            {
                return 3;
            }

            if (cols == 'M')
            {
                return 4;
            }

            if (cols == 'W')
            {
                return 10;
            }

            return 0;
        }
    }
}

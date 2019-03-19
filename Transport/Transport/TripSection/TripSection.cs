using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transport.Exceptions;

namespace Transport.Trips
{
    public class TripSection
    {
        public string line;
        public string tripId;
        public int rows;
        public char layout;
        public int price;
        internal SeatClass seatClass = SeatClass.E;
        public List<Seat> seatList;

        public TripSection(string line, string tripId, int rows, char layout, SeatClass seatClass, int price)
        {
            if (!SystemManager.airportInformation.DoesLineExist(line))
            {
                throw new InvalidJourneyException("Error: " + line + " does not exist!");
            }

            if (!SystemManager.airportInformation.DoesTripExist(tripId))
            {
                throw new InvalidJourneyException("Error: " + tripId + " does not exist!");
            }

            this.line = line;
            this.tripId = tripId;
            this.rows = rows;
            this.layout = layout;
            this.seatClass = seatClass;
            this.price = price;
            /*
             * Seat Layout 
             * S = 3 columns, with an aisle between 1 and 2 |-||
             * M = 4 columns with an aisle between 2 and 3 ||-||
             * W = 10 columns with aisles between 3,4 and 7,8 |||-||||-|||
             */

            seatList = CreateLayout(rows, layout);
        }

        public List<Seat> CreateLayout(int rows, char type)
        {
            List<Seat> layoutList = new List<Seat>();
            
            if (rows < 1)
            {
                throw new InvalidJourneyException("Error: Not a valid row input");
            }

            switch (type)
            {
                case 'S':
                    return CreateLayoutS(rows);
                case 'M':
                    return CreateLayoutM(rows);
                case 'W':
                    return CreateLayoutW(rows);
                default:
                    throw new InvalidJourneyException("Error: Not a valid layout");
            }
        }

        //S = 3 columns, with an aisle between 1 and 2 |-||
        public List<Seat> CreateLayoutS(int rows)
        {
            char total_cols = 'C';

            List<Seat> layout = new List<Seat>();

            //Loops through columns A -C
            for (char columnLetter = 'A'; columnLetter <= total_cols; columnLetter++)
            {
                //Loops through each row
                for (int row = 1; row <= rows; row++)
                {
                    Seat.SeatType type = Seat.SeatType.window;
                    switch (columnLetter)
                    {
                        case 'A':
                            type = Seat.SeatType.window;
                            break;
                        case 'B':
                            type = Seat.SeatType.aisle;
                            break;
                        case 'C':
                            type = Seat.SeatType.window;
                            break;
                        default:
                            throw new InvalidJourneyException("Error: Invalid Column");
                    }
                    Seat seat = new Seat(line, tripId, row, columnLetter, false, type);
                    layout.Add(seat);
                }
            }

            return layout;
        }

        // M = 4 columns with an aisle between 2 and 3 ||-||
        public List<Seat> CreateLayoutM(int rows)
        {
            char total_cols = 'D';

            List<Seat> layout = new List<Seat>();

            //Loops through columns A - D
            for (char cols = 'A'; cols <= total_cols; cols++)
            {
                //Loops through each row
                for (int row = 1; row <= rows; row++)
                {
                    Seat.SeatType type = Seat.SeatType.window;
                    switch (cols)
                    {
                        case 'A':
                            type = Seat.SeatType.window;
                            break;
                        case 'B':
                            type = Seat.SeatType.aisle;
                            break;
                        case 'C':
                            type = Seat.SeatType.aisle;
                            break;
                        case 'D':
                            type = Seat.SeatType.window;
                            break;
                        default: break;
                    }
                    Seat seat = new Seat(line, tripId, row, cols, false, type);
                    layout.Add(seat);
                }
            }

            return layout;
        }

        // W = 10 columns with aisles between 3,4 and 7,8 |||-||||-|||
        public List<Seat> CreateLayoutW(int rows)
        {
            int total_cols = 10;

            List<Seat> layout = new List<Seat>();

            //Loops through columns A - J
            for (char cols = 'A'; cols <= total_cols; cols++)
            {
                //Loops through each row
                for (int row = 1; row <= rows; row++)
                {
                    Seat.SeatType type = Seat.SeatType.window;
                    switch (cols)
                    {
                        case 'A':
                            type = Seat.SeatType.window;
                            break;
                        case 'J':
                            type = Seat.SeatType.window;
                            break;
                        default:
                            type = Seat.SeatType.aisle;
                            break;
                    }
                    Seat seat = new Seat(line, tripId, row, cols, false, type);
                    layout.Add(seat);
                }
            }

            return layout;
        }
    }
}

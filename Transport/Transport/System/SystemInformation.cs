using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks.Sources;
using Transport.Trips;

namespace Transport
{
    public class SystemInformation
    {
        public List<Port> PortList { get; set; } = new List<Port>();
        public List<Line> LineList { get; set; } = new List<Line>();
        public List<Trip> TripList { get; set; } = new List<Trip>();
        internal List<TripSection> TripSectionList { get; set; } = new List<TripSection>();
        public List<Seat> BookedSeatsList { get; set; } = new List<Seat>();

        // Ports
        public void AddPort(Port port)
        {
            PortList.Add(port);
        }
        public void RemovePort(Port port)
        {
            Port toRemove = PortList.Find(x => x.Name == port.Name);
            PortList.Remove(toRemove);
        }
        public bool DoesPortExist(string port)
        {
            return PortList.FindAll(x => x.Name == port).Count > 0;
        }

        // Lines
        public void AddLine(Line line)
        {
            LineList.Add(line);
        }
        public void RemoveLine(Line line)
        {
            Line toRemove = LineList.Find(x => x.Name == line.Name);
            LineList.Remove(toRemove);
        }
        public bool DoesLineExist(string line)
        {
            return LineList.FindAll(x => x.Name == line).Count > 0;
        }

        // Trips
        public void AddTrip(Trip trip)
        {
            TripList.Add(trip);
        }
        public void RemoveTrip(Trip trip)
        {
            Trip toRemove = TripList.Find(x => x.TripID == trip.TripID);
            TripList.Remove(toRemove);
        }
        public bool DoesTripExist(string trip)
        {
            return TripList.FindAll(x => x.TripID == trip).Count > 0;
        }

        public bool DoesSeatExist(char col, int row)
        {
            return BookedSeatsList.FindAll(x => (x.ColumnCharacter == col) && (x.RowNumber == row)).Count > 0;
        }

        public void AddTripSection(TripSection tripSection)
        {
            TripSectionList.Add(tripSection);
        }

        public string SaveToFile(string type)
        {
            string path = "";

            if (type == "airport")
            {
                path = @"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\airportFile.out";
            }
            if(type == "train")
            {
                path = @"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\trainFile.out";
            }

            if (type == "cruise")
            {
                path = @"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\cruiseFile.out";
            }

            using (StreamWriter writetext = new StreamWriter(path))
            {
                StringBuilder state = new StringBuilder();

                state.Append("[");

                foreach (var port in PortList)
                {
                    state.Append(port.Name + ", ");
                }

                state.Length = state.Length-2;

                state.Append("]{");

                foreach (var line in LineList)
                {

                    state.Append(line.Name + "[");

                    foreach (var trip in TripList.FindAll(x => x.TripLine.Name == line.Name))
                    {
                        state.Append(trip.TripID + "|" + trip.Year + ", " + trip.Month + ", " + trip.Day + ", " +
                                     trip.Hour + ", " + trip.Minutes + "|" + trip.OriginPort.Name + "|" +
                                     trip.DestinationPort.Name + "[");

                        foreach (var section in TripSectionList.FindAll(x => x.tripId == trip.TripID))
                        {
                            state.Append(section.seatClass + ":" + section.price + ":" + section.layout + ":" + section.rows+",");
                        }

                        state.Length--;

                        state.Append("], ");
                    }

                    state.Length = state.Length - 2;
                    state.Append("], ");

                }

                state.Length = state.Length - 2;
                state.Append("}");

                //write to the file
                writetext.WriteLine(state);
            }

            return "Success";
        }

        public string BookSeat(string line, string tripId, SeatClass s, int row, char col)
        {
            string result;

            BookedSeatsList.Where(x => (x.ColumnCharacter == col) && (x.RowNumber == row) && (x.IsBooked == false)).ToList().ForEach(x => x.IsBooked = true);
            result = "Success: Seat (" + col + row + ") with Seat Class " + s + " on Flight " + tripId + " with " + line + " airline " + " Booked!";
            Console.WriteLine(result);
            return result;
        }
    }
}

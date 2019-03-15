using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    public class SystemInformation
    {
        public List<Port> PortList { get; set; } = new List<Port>();
        public List<Line> LineList { get; set; } = new List<Line>();
        public List<Trip> TripList { get; set; } = new List<Trip>();

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

    }
}

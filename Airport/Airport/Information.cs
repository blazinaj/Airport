using System;
using System.Collections.Generic;

namespace Airport
{
    internal class Information
    {
        internal List<Port> AirportList = new List<Port>();
        internal List<Port> CruiseportList = new List<Port>();
        internal List<Port> TrainportList = new List<Port>();

        internal List<Line> AirlineList = new List<Line>();
        internal List<Line> CruiselineList = new List<Line>();
        internal List<Line> TrainlineList = new List<Line>();

        internal List<Port> GetPortList(string type)
        {
            switch (type)
            {
                case "airport":
                    return AirportList;
                case "cruiseport":
                    return CruiseportList;
                case "trainport":
                    return TrainportList;
                default:
                    return null;
            }
        }

        internal void AddPortInformation(string type, Port port)
        {
            switch (type)
            {
                case "airport":
                    AirportList.Add(port);
                    break;
                case "cruiseport":
                    CruiseportList.Add(port);
                    break;
                case "trainport":
                    TrainportList.Add(port);
                    break;
                default:
                    break;
            }
        }

        internal void AddLineInformation(string type, Line line)
        {
            switch (type)
            {
                case "airline":
                    AirlineList.Add(line);
                    break;
                case "cruiseline":
                    CruiselineList.Add(line);
                    break;
                case "trainline":
                    TrainlineList.Add(line);
                    break;
                default:
                    break;
            }
        }
    }
}
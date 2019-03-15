using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// An abstract object.
    /// </summary>
    public abstract class Trip : IDisplaySystemDetails
    {
        public string TripID { get; set; }
        public Line TripLine { get; set; }
        public Port OriginPort { get; set; }
        public Port DestinationPort { get; set; }
        public List<Port> DestinationPorts { get; set; } = new List<Port>();
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public int Year { get; set; }

        public string DisplaySystemDetails()
        {
            string details = GetType() + ": " + TripID + " | Origin: " + OriginPort.Name + " | Destination(s)" + DestinationPorts.ToString();
            Console.WriteLine(details);
            return details;
        }
    }
}

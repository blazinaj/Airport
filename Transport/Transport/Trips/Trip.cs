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
        public Port OriginPort { get; set; }
        public List<Port> DestinationPorts { get; set; }
        public string DisplaySystemDetails()
        {
            string details = GetType() + ": " + TripID + " | Origin: " + OriginPort.Name + " | Destination(s)" + DestinationPorts.ToString();
            Console.WriteLine(details);
            return details;
        }
    }
}

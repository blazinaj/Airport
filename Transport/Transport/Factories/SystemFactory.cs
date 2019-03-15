using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// The AbstractFactory class, which defines methods for creating abstract objects.
    /// </summary>
    public abstract class SystemFactory
    {
        public abstract string CreatePort(string name);
        public abstract string CreateLine(string name);
        public abstract string CreateTrip(string airLine, string originAirPort, string destinationAirPort, int year, int month, int day, string tripID);
    }
}

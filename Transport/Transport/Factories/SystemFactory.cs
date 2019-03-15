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
        public abstract string CreateTrip(string line, string originPort, string destinationPort, int year, int month, int day, int hour, int minutes, string tripID);
        public abstract string CreateSection(string line, string tripID, int rows, char cols, SeatClass seatClass, int price);
    }
}

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
        public abstract (Port, string) CreatePort(string name);
        public abstract (Line, string) CreateLine(string name);
        public abstract Trip CreateTrip(string name);
    }
}

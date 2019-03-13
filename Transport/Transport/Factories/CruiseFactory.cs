using System;
using System.Collections.Generic;
using System.Text;
using Transport.Exceptions;
using Transport.Lines;
using Transport.Trips;

namespace Transport.Factories
{
    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    public class CruiseFactory : SystemFactory
    {
        public override (Port, string) CreatePort(string name)
        {
            try
            {
                Port newCruisePort = new CruisePort(name);
                string success = "Success: CruisePort " + newCruisePort.Name + " Successfully Created!";
                return (newCruisePort, success);
            }
            catch (InvalidCruisePortException e)
            {
                return (null, e.Message);
            }
        }
        public override (Line, string) CreateLine(string name)
        {
            try
            {
                Line newCruiseLine = new CruiseLine(name);
                string success = "Success: CruiseLine " + newCruiseLine.Name + " Successfully Created!";
                return (newCruiseLine, success);
            }
            catch (InvalidCruiseLineException e)
            {
                return (null, e.Message);
            }
        }

        public override Trip CreateTrip(string name)
        {
            return new CruiseTrip(name);
        }
    }
}

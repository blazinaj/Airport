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
    public class AirportFactory : SystemFactory
    {
        public override (Port, string) CreatePort(string name)
        {
            try
            {
                Port newAirPort = new AirPort(name);
                string success = "Success: AirPort " + newAirPort.Name + " Successfully Created!";
                return (newAirPort, success);
            }
            catch (InvalidAirPortException e)
            {
                return (null, e.Message);
            }
        }
        public override (Line, string) CreateLine(string name)
        {
            try
            {
                Line newAirLine = new AirLine(name);
                string success = "Success: AirLine " + newAirLine.Name + " Successfully Created!";
                return (newAirLine, success);
            }
            catch (InvalidAirlineException e)
            {
                return (null, e.Message);
            }
        }

        public override Trip CreateTrip(string name)
        {
            return new AirTrip(name);
        }
    }
}

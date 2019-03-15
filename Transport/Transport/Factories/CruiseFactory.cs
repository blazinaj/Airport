﻿using System;
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
        public override string CreatePort(string name)
        {
            try
            {
                Port newCruisePort = new CruisePort(name);
                string success = "Success: CruisePort " + newCruisePort.Name + " Successfully Created!";
                return success;
            }
            catch (InvalidCruisePortException e)
            {
                return e.Message;
            }
        }
        public override string CreateLine(string name)
        {
            try
            {
                Line newCruiseLine = new CruiseLine(name);
                string success = "Success: CruiseLine " + newCruiseLine.Name + " Successfully Created!";
                return success;
            }
            catch (InvalidCruiseLineException e)
            {
                return e.Message;
            }
        }

        public override string CreateTrip(string cruiseLine, string originCruisePort, string destinationCruisePort, int year, int month, int day, string tripID)
        {
            try
            {
                Trip newCruise = new CruiseTrip(cruiseLine, originCruisePort, destinationCruisePort, year, month, day, tripID);
                string success = "Success: CruiseTrip " + newCruise.TripID + " Successfully Created!";
                SystemManager.airportInformation.AddTrip(newCruise);
                return success;
            }
            catch (InvalidCruiseException e)
            {
                return e.Message;
            }
        }
    }
}

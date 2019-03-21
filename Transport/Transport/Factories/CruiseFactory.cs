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
        public override string CreatePort(string name)
        {
            try
            {
                Port newCruisePort = new CruisePort(name);
                string success = "Success: CruisePort " + newCruisePort.Name + " Successfully Created!";
                SystemManager.cruiseInformation.AddPort(newCruisePort);
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
                SystemManager.cruiseInformation.AddLine(newCruiseLine);
                return success;
            }
            catch (InvalidCruiseLineException e)
            {
                return e.Message;
            }
        }

        public override string CreateTrip(string cruiseLine, string originCruisePort, string destinationCruisePort, int year, int month, int day, int hour, int minutes, string tripID)
        {
            try
            {
                Trip newCruise = new CruiseTrip(cruiseLine, originCruisePort, destinationCruisePort, year, month, day, hour, minutes, tripID);
                string success = "Success: CruiseTrip " + newCruise.TripID + " Successfully Created!";
                SystemManager.cruiseInformation.AddTrip(newCruise);
                return success;
            }
            catch (InvalidCruiseException e)
            {
                return e.Message;
            }
        }

        public override string CreateSection(string cruiseLine, string cID, int rows, char cols, SeatClass seatClass, int price)
        {
            try
            {
                if (!SystemManager.cruiseInformation.DoesLineExist(cruiseLine))
                {
                    return "Error: " + cruiseLine + " does not exist!";
                }

                if (!SystemManager.cruiseInformation.DoesTripExist(cID))
                {
                    return "Error: " + cID + " does not exist!";
                }
                TripSection newSection = new TripSection(cruiseLine, cID, rows, cols, seatClass, price);
                string success = "Success: Cruise Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass + " and price " + price + " on Cruise journey " + cID + " with " + cruiseLine + " cruise line " + " Created!";
                SystemManager.cruiseInformation.AddTripSection(newSection);
                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

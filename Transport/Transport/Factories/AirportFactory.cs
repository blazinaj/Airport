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
        public override string CreatePort(string name)
        {
            try
            {
                Port newAirPort = new AirPort(name);
                string success = "Success: AirPort " + newAirPort.Name + " Successfully Created!";
                SystemManager.airportInformation.AddPort(newAirPort);
                return success;
            }
            catch (InvalidAirPortException e)
            {
                return e.Message;
            }
        }
        public override string CreateLine(string name)
        {
            try
            {
                Line newAirLine = new AirLine(name);
                string success = "Success: AirLine " + newAirLine.Name + " Successfully Created!";
                SystemManager.airportInformation.AddLine(newAirLine);
                return success;
            }
            catch (InvalidAirlineException e)
            {
                return e.Message;
            }
        }

        public override string CreateTrip(string airLine, string originAirPort, string destinationAirPort, int year, int month, int day, int hour, int minutes, string tripID)
        {
            try
            {
                Trip newFlight = new Flight(airLine, originAirPort, destinationAirPort, year, month, day, hour, minutes, tripID);
                string success = "Success: Flight " + newFlight.TripID + " Successfully Created!";
                SystemManager.airportInformation.AddTrip(newFlight);
                return success;
            }
            catch (InvalidFlightException e)
            {
                return e.Message;
            }
        }

        public override string CreateSection(string airLine, string fID, int rows, char cols, SeatClass seatClass, int price)
        {
            try
            {
                TripSection newSection = new TripSection(airLine, fID, rows, cols, seatClass, price);
                string success = "Success: Flight Section (" + rows + " rows, " + cols + " cols) with Seat Class " + seatClass +" and price " + price + " on Flight " + fID + " with " + airLine + " airline " + " Created!";
                SystemManager.airportInformation.AddTripSection(newSection);
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

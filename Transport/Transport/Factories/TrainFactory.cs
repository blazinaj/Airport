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
    public class TrainFactory : SystemFactory
    {
        public override string CreatePort(string name)
        {
            try
            {
                Port newTrainPort = new TrainPort(name);
                string success = "Success: TrainPort " + newTrainPort.Name + " Successfully Created!";
                return success;
            }
            catch (InvalidTrainPortException e)
            {
                return e.Message;
            }
        }
        public override string CreateLine(string name)
        {
            try
            {
                Line newTrainLine = new TrainLine(name);
                string success = "Success: TrainLine " + newTrainLine.Name + " Successfully Created!";
                return success;
            }
            catch (InvalidTrainLineException e)
            {
                return e.Message;
            }
        }

        public override string CreateTrip(string trainLine, string originTrainPort, string destinationTrainPort, int year, int month, int day, string tripID)
        {
            try
            {
                Trip newTrainTrip = new CruiseTrip(trainLine, originTrainPort, destinationTrainPort, year, month, day, tripID);
                string success = "Success: CruiseTrip " + newTrainTrip.TripID + " Successfully Created!";
                SystemManager.airportInformation.AddTrip(newTrainTrip);
                return success;
            }
            catch (InvalidJourneyException e)
            {
                return e.Message;
            }
        }
    }
}

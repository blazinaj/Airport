using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions.Airline
{
    class InvalidAirportException : Exception
    {
        public InvalidAirportException()
        {

        }
        public InvalidAirportException(string message)
            : base(message)
        {

        }

        public InvalidAirportException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

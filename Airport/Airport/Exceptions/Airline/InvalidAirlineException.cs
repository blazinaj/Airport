using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class InvalidAirlineException : Exception
    {
        public InvalidAirlineException()
        {

        }
        public InvalidAirlineException(string message)
            : base(message)
        {

        }

        public InvalidAirlineException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

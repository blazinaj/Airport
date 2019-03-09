using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class FlightIDException : Exception
    {
        public FlightIDException()
        {

        }
        public FlightIDException(string message)
            :base(message)
        {

        }

        public FlightIDException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class InvalidFlightException : Exception
    {
        public InvalidFlightException()
        {

        }
        public InvalidFlightException(string message)
            : base(message)
        {

        }

        public InvalidFlightException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

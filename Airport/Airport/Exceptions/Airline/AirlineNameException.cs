using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class AirlineNameException : Exception
    {
        public AirlineNameException()
        {

        }
        public AirlineNameException(string message)
            :base(message)
        {

        }

        public AirlineNameException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}

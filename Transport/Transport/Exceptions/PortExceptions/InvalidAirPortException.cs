using System;

namespace Transport.Exceptions
{
    class InvalidAirPortException : Exception
    {
        public InvalidAirPortException()
        {

        }
        public InvalidAirPortException(string message)
            : base(message)
        {

        }

        public InvalidAirPortException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
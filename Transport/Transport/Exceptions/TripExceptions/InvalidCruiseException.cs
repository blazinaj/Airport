using System;

namespace Transport.Exceptions
{
    class InvalidCruiseException : Exception
    {
        public InvalidCruiseException()
        {

        }
        public InvalidCruiseException(string message)
            : base(message)
        {

        }

        public InvalidCruiseException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
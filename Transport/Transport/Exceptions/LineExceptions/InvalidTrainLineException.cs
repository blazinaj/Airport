using System;

namespace Transport.Exceptions
{
    class InvalidCruiseLineException : Exception
    {
        public InvalidCruiseLineException()
        {

        }
        public InvalidCruiseLineException(string message)
            : base(message)
        {

        }

        public InvalidCruiseLineException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
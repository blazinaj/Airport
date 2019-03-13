using System;

namespace Transport.Exceptions
{
    class InvalidTrainPortException : Exception
    {
        public InvalidTrainPortException()
        {

        }
        public InvalidTrainPortException(string message)
            : base(message)
        {

        }

        public InvalidTrainPortException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
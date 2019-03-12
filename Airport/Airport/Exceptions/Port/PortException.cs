using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Exceptions
{
    class PortException : Exception
    {
        public PortException()
        {

        }
        public PortException(string message)
            : base(message)
        {

        }

        public PortException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

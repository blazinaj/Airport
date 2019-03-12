using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class AirPort : Port
    {
        public AirPort(string name)
        {
            base.Name = name;
        }
    }
}

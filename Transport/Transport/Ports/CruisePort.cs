using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class CruisePort : Port
    {
        public CruisePort(string name)
        {
            Name = name;
        }
    }
}

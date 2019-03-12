using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    class TrainPort : Port
    {
        /// <summary>
        /// A ConcreteProduct
        /// </summary>
        public TrainPort(string name)
        {
            Name = name;
        }
    }
}

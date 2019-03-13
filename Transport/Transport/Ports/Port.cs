using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// An abstract object.
    /// </summary>
    public abstract class Port : IDisplaySystemDetails
    {
        public string Name { get; set; }
        public string DisplaySystemDetails()
        {
            return GetType().Name + ": " + Name;
        }
    }
}

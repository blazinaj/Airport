using System;
using System.Collections.Generic;
using System.Text;

namespace Transport
{
    /// <summary>
    /// An abstract object.
    /// </summary>
    public abstract class Line : IDisplaySystemDetails
    {
        public string Name { get; set; }

        public string DisplaySystemDetails()
        {
            string details = GetType() + ": " + Name;
            Console.WriteLine(details);
            return details;
        }
    }
}

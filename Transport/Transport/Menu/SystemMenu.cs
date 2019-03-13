using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Menu
{
    abstract class SystemMenu
    {
        public SystemManager systemManager = new SystemManager();
        public abstract string DisplayMenu();
    }
}

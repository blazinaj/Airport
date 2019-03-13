using System;
using Transport.Menu;
using Transport.UserMenu;

namespace Transport
{
    class Client
    {
        public static void Main(string[] args)
        {
            UserMenu.UserMenu userMenu = new ClientMenu();
            userMenu.DisplayMenu();

        }
    }
}

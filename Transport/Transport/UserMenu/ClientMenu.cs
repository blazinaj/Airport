using System;
using System.Collections.Generic;
using System.Text;
using Transport.Menu;

namespace Transport.UserMenu
{
    class ClientMenu : UserMenu
    {
        public override string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Transportation System Manager!");
            Console.WriteLine("Please choose one of following options: ");
            Console.WriteLine();
            Console.WriteLine("1. Go to Airport Transportation System");
            Console.WriteLine("2. Go to Train Transportation System");
            Console.WriteLine("3. Go to Cruise Transportation System");
            var isNumeric = int.TryParse(Console.ReadLine(), out int res);


            if (res > 0 && res < 4)
            {
                if (res == 1)
                {
                    UserMenu airportMenu = new AirportUserMenu();
                    airportMenu.DisplayMenu();
                }

                if (res == 2)
                {
                    UserMenu trainMenu = new TrainUserMenu();
                    trainMenu.DisplayMenu();
                }

                if (res == 3)
                {
                    UserMenu cruiseMenu = new CruiseUserMenu();
                    cruiseMenu.DisplayMenu();
                }

            }
            else
            {
                //Throw an exception 
            }

            return DisplayMenu();

        }

        public override void DisplaySystemDetails()
        {
            throw new NotImplementedException();
        }
    }
}

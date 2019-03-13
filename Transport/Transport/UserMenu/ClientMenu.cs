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
                    SystemMenu airportMenu = new AirportMenu();
                    airportMenu.DisplayMenu();
                }

                if (res == 2)
                {
                    SystemMenu trainMenu = new TrainMenu();
                    trainMenu.DisplayMenu();
                }

                if (res == 3)
                {
                    SystemMenu cruiseMenu = new CruiseMenu();
                    cruiseMenu.DisplayMenu();
                }

            }
            else
            {
                //Throw an exception 
            }

            return DisplayMenu();

        }
    }
}

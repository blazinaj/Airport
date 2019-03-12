using System;
using Transport.Menu;

namespace Transport
{
    class Client
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                ImportFile.ReadFromFile(args);
            }
            else
            {
                Console.WriteLine("Welcome to the Transportation System Manager!");
                Console.WriteLine("Please choose one of following options: ");
                Console.WriteLine();
                Console.WriteLine("1. Go to Airport Transportation System");
                Console.WriteLine("2. Go to Train Transportation System");
                Console.WriteLine("3. Go to Cruise Transportation System");
                var isNumeric = int.TryParse(Console.ReadLine(), out int res);
                

                 if(res > 0 && res < 4)
                 {
                    if (res == 1)
                    {
                        SystemMenu airportMenu = new AirportMenu();
                        Console.WriteLine(airportMenu.DisplayMenu());
                    }

                    if (res == 2)
                    {
                        SystemMenu trainMenu = new TrainMenu();
                        Console.WriteLine(trainMenu.DisplayMenu());
                    }

                    if (res == 3)
                    {
                        SystemMenu cruiseMenu = new CruiseMenu();
                        Console.WriteLine(cruiseMenu.DisplayMenu());
                    }

                 }
                 else
                 {
                    //Throw an exception 
                 }
            }
  
        }
    }
}

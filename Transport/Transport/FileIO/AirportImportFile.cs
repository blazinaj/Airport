using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Transport
{
    public class AirportImportFile
    {
        public static string ReadFromFile()
        {
            // change to your path to make it work
                var fileStream = new FileStream(@"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\airportFile.in",
                    FileMode.Open, FileAccess.Read);
            

            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line = streamReader.ReadLine();


                if (line != null)
                {

                    char[] charArrayWholeLine = line.ToCharArray();

                    int index = 0;

                    if (charArrayWholeLine[0] == '[')
                    {
                        StringBuilder stringOfAirports = new StringBuilder();
                        for (int i = 1; i < charArrayWholeLine.Length; i++)
                        {
                            index = i;
                            if (charArrayWholeLine[i] == ']')
                            {
                                index++;
                                break;
                            }

                            stringOfAirports.Append(charArrayWholeLine[i]);
                        }

                        string[] airports = stringOfAirports.ToString().Split(',');

                        foreach (string airport in airports)
                        {
                            //call for System Manager to create an Airport
                            SystemManager.airFactory.CreatePort(airport);
                        }
                    }

                    if (charArrayWholeLine[index] == '{')
                    {
                        do
                        {

                                //--------------------------------------------------------------------------------------------------------
                                //Create Airline

                                string airline ="";
                                StringBuilder stringOfAirline = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                    index = i;
                                    if (charArrayWholeLine[i] == '[')
                                    {
                                        break;
                                    }

                                    stringOfAirline.Append(charArrayWholeLine[i]);
                                    airline = stringOfAirline.ToString();
                                }

                                // call to create an airline with parameter: airline <-- one airline inside this string
                                SystemManager.airFactory.CreateLine(airline);


                            do
                            {
                                //--------------------------------------------------------------------------------------------------------
                                //create a flight for the airline above
                                string flightID ="";
                                string[] dateTime = new string[5];
                                int flightYear = 0, flightMonth = 0, flightDay = 0, flightHour = 0, flightMinutes = 0;
                                string origAirport="", distAirport="";
                                SeatClass sectionClass;
                                int sectionPrice = 0, sectionRows = 0;
                                char sectionColumns;

                                //getting FlightID

                                StringBuilder Flight = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                     index = i;
                                      if (charArrayWholeLine[i] == '|')
                                      {
                                          break;
                                      }

                                        Flight.Append(charArrayWholeLine[i]);
                                }

                                  flightID = Flight.ToString();

                                

                                //getting flight date
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder FlightDate = new StringBuilder();

                                    for (int j = index + 1; j < charArrayWholeLine.Length; j++)
                                    {
                                        index = j;
                                        if (charArrayWholeLine[j] == '|')
                                        {
                                            break;
                                        }

                                        FlightDate.Append(charArrayWholeLine[j]);

                                    }

                                    dateTime = FlightDate.ToString().Split(',');

                                    flightYear = int.Parse(dateTime[0].Trim());
                                    flightMonth = int.Parse(dateTime[1].Trim());
                                    flightDay = int.Parse(dateTime[2].Trim());
                                    flightHour = int.Parse(dateTime[3].Trim());
                                    flightMinutes = int.Parse(dateTime[4].Trim());
                                }

                                //getting origAirport
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder originationAirport = new StringBuilder();


                                    for (int k = index + 1; k < charArrayWholeLine.Length; k++)
                                    {
                                        index = k;
                                        if (charArrayWholeLine[k] == '|')
                                        {
                                            break;
                                        }

                                        originationAirport.Append(charArrayWholeLine[k]);
                                        origAirport = originationAirport.ToString();
                                    }
                                }

                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder destinationAirport = new StringBuilder();

                                    //getting distAirport
                                    for (int l = index + 1; l < charArrayWholeLine.Length; l++)
                                    {
                                        index = l;
                                        if (charArrayWholeLine[l] == '[')
                                        {
                                            break;
                                        }

                                        destinationAirport.Append(charArrayWholeLine[l]);
                                    }

                                    distAirport = destinationAirport.ToString();
                                }

                                //call to create an airline
                                SystemManager.airFactory.CreateTrip(airline, origAirport, distAirport, flightYear,
                                    flightMonth, flightDay, flightHour, flightMinutes, flightID);

                                //getting flightSection
                                if (charArrayWholeLine[index] == '[')
                                {
                                    StringBuilder flightsection = new StringBuilder();
                                    for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                    {
                                        index++;
                                        if (charArrayWholeLine[i] == ']')
                                        {
                                            break;
                                        }

                                        flightsection.Append(charArrayWholeLine[i]);
                                    }

                                    string[] sectionsArray = flightsection.ToString().Split(',');

                                    foreach (var section in sectionsArray)
                                    {
                                        string[] sectionItems = section.Split(':');

                                        sectionClass = (SeatClass)Enum.Parse(typeof(SeatClass),sectionItems[0]);
                                        sectionPrice = int.Parse(sectionItems[1]);
                                        sectionColumns = Convert.ToChar(sectionItems[2]);
                                        sectionRows = int.Parse(sectionItems[3]);

                                        //here will be call to create flight, with date, section, class, price, columns and rows
                                        SystemManager.airFactory.CreateSection(airline, flightID, sectionRows,
                                            sectionColumns, sectionClass, sectionPrice);
                                    }
                                }

                                index = index + 2;
                                Console.WriteLine(charArrayWholeLine[index]);
                                Console.WriteLine(charArrayWholeLine[index - 1]);
                                Console.WriteLine(charArrayWholeLine[index - 2]);

                            } while (charArrayWholeLine[index] != ']' && charArrayWholeLine[index - 1] != ']');

                            index = index + 1;

                        } while (charArrayWholeLine[index-1] != '}');
                    }
                }
            }

            return "Success";
        }
    }
}
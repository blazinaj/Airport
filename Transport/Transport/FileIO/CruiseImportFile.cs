using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Transport
{
    public class CruiseImportFile
    {
        public static string ReadFromFile()
        {
            // change to your path to make it work
                var fileStream = new FileStream(@"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\cruiseFile.in",
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
                        StringBuilder stringOfCruises = new StringBuilder();
                        for (int i = 1; i < charArrayWholeLine.Length; i++)
                        {
                            index = i;
                            if (charArrayWholeLine[i] == ']')
                            {
                                index++;
                                break;
                            }

                            stringOfCruises.Append(charArrayWholeLine[i]);
                        }

                        string[] cruises = Array.ConvertAll(stringOfCruises.ToString().Split(','), p => p.Trim());

                        foreach (string airport in cruises)
                        {
                            //call for System Manager to create an CruisePort
                            SystemManager.cruiseFactory.CreatePort(airport);
                        }
                    }

                    if (charArrayWholeLine[index] == '{')
                    {
                        do
                        {

                                //--------------------------------------------------------------------------------------------------------
                                //Create CruiseLine

                                string cruiseline ="";
                                StringBuilder stringOfCruiseline = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                    index = i;
                                    if (charArrayWholeLine[i] == '[')
                                    {
                                        break;
                                    }

                                    stringOfCruiseline.Append(charArrayWholeLine[i]);
                                    cruiseline = stringOfCruiseline.ToString();
                                }

                                // call to create an airline with parameter: cruiseline <-- one cruise inside this string
                                SystemManager.cruiseFactory.CreateLine(cruiseline);


                            do
                            {
                                //--------------------------------------------------------------------------------------------------------
                                //create a cruiseTrip for the airline above
                                string cruiseTripID ="";
                                string[] dateTime = new string[5];
                                int cruiseTripYear = 0, cruiseTripMonth= 0, cruiseTripDay= 0, cruiseTripHour= 0, cruiseTripMinutes = 0;
                                string origCruiseport = "", distCruiseport ="";
                                SeatClass sectionClass; 
                                int sectionPrice = 0, sectionRows = 0;
                                char sectionColumns;

                                //getting FlightID

                                StringBuilder CruiseTrip = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                     index = i;
                                      if (charArrayWholeLine[i] == '|')
                                      {
                                          break;
                                      }

                                    CruiseTrip.Append(charArrayWholeLine[i]);
                                }

                                     cruiseTripID = CruiseTrip.ToString();

                                

                                //getting flight date
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder CruiseTriptDate = new StringBuilder();

                                    for (int j = index + 1; j < charArrayWholeLine.Length; j++)
                                    {
                                        index = j;
                                        if (charArrayWholeLine[j] == '|')
                                        {
                                            break;
                                        }

                                        CruiseTriptDate.Append(charArrayWholeLine[j]);

                                    }

                                    dateTime = CruiseTriptDate.ToString().Split(',');

                                    cruiseTripYear = int.Parse(dateTime[0].Trim());
                                    cruiseTripMonth = int.Parse(dateTime[1].Trim());
                                    cruiseTripDay = int.Parse(dateTime[2].Trim());
                                    cruiseTripHour = int.Parse(dateTime[3].Trim());
                                    cruiseTripMinutes = int.Parse(dateTime[4].Trim());
                                }

                                //getting origAirport
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder originationCruseport = new StringBuilder();


                                    for (int k = index + 1; k < charArrayWholeLine.Length; k++)
                                    {
                                        index = k;
                                        if (charArrayWholeLine[k] == '|')
                                        {
                                            break;
                                        }

                                        originationCruseport.Append(charArrayWholeLine[k]);
                                        origCruiseport = originationCruseport.ToString();
                                    }
                                }

                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder destinationCruiseport = new StringBuilder();

                                    //getting distAirport
                                    for (int l = index + 1; l < charArrayWholeLine.Length; l++)
                                    {
                                        index = l;
                                        if (charArrayWholeLine[l] == '[')
                                        {
                                            break;
                                        }

                                        destinationCruiseport.Append(charArrayWholeLine[l]);
                                    }

                                    distCruiseport = destinationCruiseport.ToString();
                                }

                                //call to create CruiseTrip
                                SystemManager.cruiseFactory.CreateTrip(cruiseline, origCruiseport,
                                    distCruiseport, cruiseTripYear, cruiseTripMonth, cruiseTripDay, cruiseTripHour, cruiseTripMinutes,
                                    cruiseTripID);

                                //getting flightSection
                                if (charArrayWholeLine[index] == '[')
                                {
                                    StringBuilder tripsection = new StringBuilder();
                                    for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                    {
                                        index++;
                                        if (charArrayWholeLine[i] == ']')
                                        {
                                            break;
                                        }

                                        tripsection.Append(charArrayWholeLine[i]);
                                    }

                                    string[] sectionsArray = tripsection.ToString().Split(',');

                                    foreach (var section in sectionsArray)
                                    {
                                        string[] sectionItems = section.Split(':');

                                        sectionClass = (SeatClass)Enum.Parse(typeof(SeatClass),sectionItems[0]);
                                        sectionPrice = int.Parse(sectionItems[1]);
                                        sectionColumns = Convert.ToChar(sectionItems[2]);
                                        sectionRows = int.Parse(sectionItems[3]);

                                        //here will be call to create flight, with date, section, class, price, columns and rows
                                        SystemManager.cruiseFactory.CreateSection(cruiseline, cruiseTripID, sectionRows,
                                            sectionColumns, sectionClass, sectionPrice);


                                    }
                                }

                                index = index + 2;
                                
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
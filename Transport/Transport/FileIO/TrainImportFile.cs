using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Transport
{
    public class TrainImportFile
    {
        public static string ReadFromFile()
        {
            // change to your path to make it work
                var fileStream = new FileStream(@"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\FileIO\trainFile.in",
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
                        StringBuilder stringOfTrainports = new StringBuilder();
                        for (int i = 1; i < charArrayWholeLine.Length; i++)
                        {
                            index = i;
                            if (charArrayWholeLine[i] == ']')
                            {
                                index++;
                                break;
                            }

                            stringOfTrainports.Append(charArrayWholeLine[i]);
                        }

                        string[] trainports = stringOfTrainports.ToString().Split(',');

                        foreach (string trainport in trainports)
                        {
                            //call for System Manager to create an Airport
                            SystemManager.trainFactory.CreatePort(trainport);
                        }
                    }

                    if (charArrayWholeLine[index] == '{')
                    {
                        do
                        {

                                //--------------------------------------------------------------------------------------------------------
                                //Create Trainline

                                string trainline ="";
                                StringBuilder stringOTrainline = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                    index = i;
                                    if (charArrayWholeLine[i] == '[')
                                    {
                                        break;
                                    }

                                    stringOTrainline.Append(charArrayWholeLine[i]);
                                    trainline = stringOTrainline.ToString();
                                }

                                // call to create an trainline with parameter: trainline <-- one trainline inside this string
                                SystemManager.trainFactory.CreateLine(trainline);


                            do
                            {
                                //--------------------------------------------------------------------------------------------------------
                                //create a TrainJourney for the trainline above
                                string TrainJourneyID = "";
                                string[] dateTime = new string[5];
                                int TrainJourneyYear = 0, TrainJourneyMonth = 0, TrainJourneyDay = 0, TrainJourneyHour = 0, TrainJourneyMinutes = 0;
                                string origTrainport, distTrainport;
                                SeatClass sectionClass; 
                                int sectionPrice = 0, sectionColumns = 0, sectionRows = 0;

                                //getting TrainJourneyID

                                StringBuilder TrainJourney = new StringBuilder();

                                for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                {
                                     index = i;
                                      if (charArrayWholeLine[i] == '|')
                                      {
                                          break;
                                      }

                                    TrainJourney.Append(charArrayWholeLine[i]);
                                }

                                    TrainJourneyID = TrainJourney.ToString();

                                

                                //getting TrainJourney date
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder TrainJourneyDate = new StringBuilder();

                                    for (int j = index + 1; j < charArrayWholeLine.Length; j++)
                                    {
                                        index = j;
                                        if (charArrayWholeLine[j] == '|')
                                        {
                                            break;
                                        }

                                        TrainJourneyDate.Append(charArrayWholeLine[j]);

                                    }

                                    dateTime = TrainJourneyDate.ToString().Split(',');

                                    TrainJourneyYear = int.Parse(dateTime[0].Trim());
                                    TrainJourneyMonth = int.Parse(dateTime[1].Trim());
                                    TrainJourneyDay = int.Parse(dateTime[2].Trim());
                                    TrainJourneyHour = int.Parse(dateTime[3].Trim());
                                    TrainJourneyMinutes = int.Parse(dateTime[4].Trim());
                                }

                                //getting origTrainport
                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder originationTrainport = new StringBuilder();


                                    for (int k = index + 1; k < charArrayWholeLine.Length; k++)
                                    {
                                        index = k;
                                        if (charArrayWholeLine[k] == '|')
                                        {
                                            break;
                                        }

                                        originationTrainport.Append(charArrayWholeLine[k]);
                                        origTrainport = originationTrainport.ToString();
                                    }
                                }

                                if (charArrayWholeLine[index] == '|')
                                {
                                    StringBuilder destinationTrainport = new StringBuilder();

                                    //getting distTrainport
                                    for (int l = index + 1; l < charArrayWholeLine.Length; l++)
                                    {
                                        index = l;
                                        if (charArrayWholeLine[l] == '[')
                                        {
                                            break;
                                        }

                                        destinationTrainport.Append(charArrayWholeLine[l]);
                                    }

                                    distTrainport = destinationTrainport.ToString();
                                }

                                //getting TrainJourneySection
                                if (charArrayWholeLine[index] == '[')
                                {
                                    StringBuilder TrainJourneysection = new StringBuilder();
                                    for (int i = index + 1; i < charArrayWholeLine.Length; i++)
                                    {
                                        index++;
                                        if (charArrayWholeLine[i] == ']')
                                        {
                                            break;
                                        }

                                        TrainJourneysection.Append(charArrayWholeLine[i]);
                                    }

                                    string[] sectionsArray = TrainJourneysection.ToString().Split(',');

                                    foreach (var section in sectionsArray)
                                    {
                                        string[] sectionItems = section.Split(':');

                                        sectionClass = (SeatClass)Enum.Parse(typeof(SeatClass),sectionItems[0]);
                                        sectionPrice = int.Parse(sectionItems[1]);
                                        sectionColumns = int.Parse(sectionItems[2]);
                                        sectionRows = int.Parse(sectionItems[3]);

                                        //here will be call to create flight, with date, section, class, price, columns and rows
                                        SystemManager.trainFactory.CreateSection(trainline, TrainJourneyID, sectionRows,
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
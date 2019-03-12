using System;
using System.IO;
using System.Text;

namespace Transport
{
    public class ImportFile
    {
        public static string ReadFromFile(string[] args)
        {
            FileStream fileStream;

            if (args.Length != 0)
            {
                string inputFileName = args[0];

                // change to your path to make it work
                fileStream =
                    new FileStream($@"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\{inputFileName}",
                        FileMode.Open, FileAccess.Read);
            }
            else
            {
                // change to your path to make it work
                fileStream =
                    new FileStream(@"C:\Users\Anatoli\Source\Repos\Airport\Transport\Transport\inputFile.in",
                        FileMode.Open, FileAccess.Read);
            }

            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {

            }


            return "";
        }
    }
}
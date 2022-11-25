using System;

namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader stream = new StreamReader(inputFilePath))
            {
                using (StreamWriter streamWriter = new StreamWriter(outputFilePath))
                {
                    string line = stream.ReadLine();
                    int row = 0;

                    while (line != null)
                    {
                        if (row % 2 == 1)
                        {
                            streamWriter.WriteLine(line);
                        }

                        line = stream.ReadLine();
                        row++;
                    }
                }
            }
        }
    }
}

namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader readerTextOne = new StreamReader(firstInputFilePath))
            {
                using (StreamReader readerTextTwo = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string lineOne = readerTextOne.ReadLine();
                        string lineTwo = readerTextTwo.ReadLine();

                        while (lineOne != null || lineTwo != null)
                        {
                            if (lineOne != null)
                            {
                                writer.WriteLine(lineOne);
                            }
                        
                            if (lineTwo != null)
                            {
                                writer.WriteLine(lineTwo);
                            }

                            lineOne = readerTextOne.ReadLine();
                            lineTwo = readerTextTwo.ReadLine();
                        }

                    }
                }
            }
        }
    }
}

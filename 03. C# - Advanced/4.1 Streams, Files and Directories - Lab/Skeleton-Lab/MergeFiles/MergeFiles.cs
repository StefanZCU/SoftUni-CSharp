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
            using (var input1 = new StreamReader(firstInputFilePath))
            {
                using (var input2 = new StreamReader(secondInputFilePath))
                {
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        string line1;
                        string line2;
                        while ((line1 = input1.ReadLine()) != null && (line2 = input2.ReadLine()) != null)
                        {
                            if (line2 != null)
                            {
                                writer.WriteLine(line1);
                            }

                            if (line1 != null)
                            {
                                writer.WriteLine(line2);
                            }
                        }
                    }
                }
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var inputStream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long partSize = inputStream.Length / 2;
                if (inputStream.Length % 2 != 0)
                {
                    partSize++;
                }

                using (var output1 = new FileStream(partOneFilePath, FileMode.Create))
                using (var output2 = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[partSize];
                    int bytesRead = inputStream.Read(buffer, 0, buffer.Length);

                    output1.Write(buffer, 0, bytesRead);

                    buffer = new byte[partSize];
                    bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                    output2.Write(buffer, 0, bytesRead);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var outputFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (var input1 = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[input1.Length];
                    int bytesRead = input1.Read(buffer, 0, buffer.Length);
                    outputFile.Write(buffer, 0, bytesRead);
                }

                using (var input2 = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[input2.Length];
                    int bytesRead = input2.Read(buffer, 0, buffer.Length);
                    outputFile.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
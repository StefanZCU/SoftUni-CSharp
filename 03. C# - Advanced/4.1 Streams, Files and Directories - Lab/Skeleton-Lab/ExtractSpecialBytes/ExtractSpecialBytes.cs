using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }


        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            byte[] bytesToExtract = File.ReadAllText(bytesFilePath)
                .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(b => byte.Parse(b))
                .ToArray();
            
            using (FileStream inputStream = new FileStream(binaryFilePath, FileMode.Open))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
            {
                int currentByte;
                while ((currentByte = inputStream.ReadByte()) != -1)
                {
                    if (bytesToExtract.Contains((byte)currentByte))
                    {
                        outputStream.WriteByte((byte)currentByte);
                    }
                }
            }
        }
    }
}

using System.Linq;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            using (var output = new StreamWriter(outputFilePath))
            {
                var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                decimal totalSize = files.Sum(file => new FileInfo(file).Length);
                
                output.WriteLine($"{totalSize / 1024} KB");
            }

        }
    }
}

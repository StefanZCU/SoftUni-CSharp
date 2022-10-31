using System;

namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int index = filePath.LastIndexOf('\\');

            string file = filePath.Substring(index + 1);

            string[] seperateFile = file.Split(".");

            Console.WriteLine($"File name: {seperateFile[0]}");
            Console.WriteLine($"File extension: {seperateFile[1]}");
        }
    }
}

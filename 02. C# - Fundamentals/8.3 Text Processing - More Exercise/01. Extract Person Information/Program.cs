using System;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numLines; i++)
            {
                string input = Console.ReadLine();

                int indexNameStart = input.IndexOf('@');
                int indexNameEnd = input.IndexOf('|');

                int nameLength = indexNameEnd - indexNameStart;

                string name = input.Substring(indexNameStart + 1, nameLength - 1);

                int indexAgeStart = input.IndexOf('#');
                int indexAgeEnd = input.IndexOf('*');

                int ageLength = indexAgeEnd - indexAgeStart;

                string age = input.Substring(indexAgeStart + 1, ageLength - 1);


                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}


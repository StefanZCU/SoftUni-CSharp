using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            string fullString = RepeatString(word, num);

            Console.WriteLine(fullString);
        }

        private static string RepeatString(string word, int num)
        {
            string repeatedString = "";

            for (int i = 0; i < num; i++)
            {
                repeatedString += word;
            }

            return repeatedString;
        }
    }
}

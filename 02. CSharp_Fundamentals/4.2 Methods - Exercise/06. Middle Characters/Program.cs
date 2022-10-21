using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string result = GetMiddleChar(word);

            Console.WriteLine(result);
        }

        static string GetMiddleChar(string word)
        {
            if (word.Length % 2 == 0)
            {
                int middle = word.Length / 2;

                char[] chars = new char[] { word[middle - 1], word[middle] };

                return String.Join("", chars);
            }
            else
            {
                double middle = Math.Floor(word.Length / 2.0);

                char[] chars = new char[] { word[(int)middle] };

                return String.Join("", chars);
            }
        }
    }
}

using System;

namespace _03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            GetChars(char1, char2);
        }

        static void GetChars(char firstChar, char secondChar)
        {
            if (firstChar < secondChar)
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }

            
        }
    }
}

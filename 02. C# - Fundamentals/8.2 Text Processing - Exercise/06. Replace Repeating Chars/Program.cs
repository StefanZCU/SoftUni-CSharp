using System;
using System.Globalization;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                if (sb.Length == 0)
                {
                    sb.Append(currentChar);
                }
                else if (sb[sb.Length - 1] == currentChar)
                {
                    continue;
                }
                else
                {
                    sb.Append(currentChar);
                }
            }

            Console.WriteLine(sb);
        }
    }
}

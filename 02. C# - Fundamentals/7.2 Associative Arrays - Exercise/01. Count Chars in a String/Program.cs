using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, int> occurenceByLetter = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    char currentChar = words[i][j];

                    if (!occurenceByLetter.ContainsKey(currentChar))
                    {
                        occurenceByLetter.Add(currentChar, 0);
                    }
                    occurenceByLetter[currentChar]++;
                }
            }

            foreach (var letter in occurenceByLetter)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}

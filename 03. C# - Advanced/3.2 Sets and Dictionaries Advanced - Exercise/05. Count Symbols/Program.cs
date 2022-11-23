using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charOccurrences = new Dictionary<char, int>();

            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                if (!charOccurrences.ContainsKey(word[i]))
                {
                    charOccurrences[word[i]] = 0;
                }

                charOccurrences[word[i]]++;
            }

            foreach (var charOccurrence in charOccurrences.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{charOccurrence.Key}: {charOccurrence.Value} time/s");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Select(s => s.ToLower()).ToArray();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var word in input)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 0);
                }

                dictionary[word]++;
            }

            foreach (var word in dictionary)
            {
                if (dictionary[word.Key] % 2 != 0)
                {
                    Console.Write($"{word.Key} ");
                }
            }
        }
    }
}

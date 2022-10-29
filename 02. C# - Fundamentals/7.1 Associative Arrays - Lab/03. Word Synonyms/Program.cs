using System;
using System.Collections.Generic;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCycles = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsAndSynonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < numCycles; i++)
            {
                string mainWord = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordsAndSynonyms.ContainsKey(mainWord))
                {
                    wordsAndSynonyms.Add(mainWord, new List<string>());
                    wordsAndSynonyms[mainWord].Add(synonym);
                }
                else
                {
                    wordsAndSynonyms[mainWord].Add(synonym);
                }

            }

            foreach (var word in wordsAndSynonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}

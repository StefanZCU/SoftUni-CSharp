using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexPattern = @"([@#])(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();
            List<string> mirrorWords = new List<string>();

            MatchCollection matches = Regex.Matches(input, regexPattern);

            int matchPairs = matches.Count;
            int mirrorPairs = 0;

            foreach (Match match in matches)
            {
                string mirrorWordChecker = string.Empty;
                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;

                for (int i = 0; i < wordTwo.Length; i++)
                {
                    char currentChar = wordTwo[wordTwo.Length - i - 1];
                    mirrorWordChecker += currentChar;
                }

                if (mirrorWordChecker == wordOne)
                {
                    mirrorWords.Add($"{wordOne} <=> {wordTwo}");
                    mirrorPairs++;
                }
            }

            if (matchPairs == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchPairs} word pairs found!");

            }

            if (mirrorPairs == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}

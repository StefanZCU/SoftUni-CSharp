using System;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexPattern = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regexPattern);

            int coolThreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (char.IsDigit(currentChar))
                {
                    coolThreshold *= (currentChar - 48);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");


            foreach (Match match in matches)
            {
                string emoji = match.Groups["emoji"].Value;
                int coolness = 0;

                for (int i = 0; i < emoji.Length; i++)
                {
                    char currentChar = emoji[i];
                    coolness += currentChar;
                }

                if (coolness >= coolThreshold)
                {
                    Console.WriteLine($"{match}");
                }
            }
        }
    }
}

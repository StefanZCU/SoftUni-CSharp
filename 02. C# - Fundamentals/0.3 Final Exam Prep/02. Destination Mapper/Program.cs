using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexPattern = @"([=/])(?<location>[A-Z][A-Za-z]{2,})\1";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regexPattern);

            int points = 0;
            List<string> locations = new List<string>();

            foreach (Match match in matches)
            {
                points += match.Groups["location"].Value.Length;
                locations.Add(match.Groups["location"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}

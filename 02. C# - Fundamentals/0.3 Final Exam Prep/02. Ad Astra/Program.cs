using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexPattern = @"([|#])(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1";

            int daysPerCalories = 0;

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regexPattern);


            foreach (Match match in matches)
            {
                daysPerCalories += int.Parse(match.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {daysPerCalories / 2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}

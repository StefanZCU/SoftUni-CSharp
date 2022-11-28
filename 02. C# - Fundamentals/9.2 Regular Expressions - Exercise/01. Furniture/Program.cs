using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            double totalPrice = 0.0;
            List<string> matches = new List<string>();

            string commandArgs;
            while ((commandArgs = Console.ReadLine()) != "Purchase")
            {
                Match furniture = Regex.Match(commandArgs, regex, RegexOptions.IgnoreCase);

                if (furniture.Success)
                {
                    totalPrice += double.Parse(furniture.Groups["price"].Value) * double.Parse(furniture.Groups["quantity"].Value);

                    matches.Add(furniture.Groups["name"].Value);
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var name in matches)
            {
                Console.WriteLine($"{name}");
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}

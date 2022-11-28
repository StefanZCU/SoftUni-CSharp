using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex =
                @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>[\d]+.?[\d+]+)?\$";

            double totalPrice = 0.0;

            string command;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(command, regex);

                if (match.Success)
                {
                    double price = int.Parse(match.Groups["count"].Value) *
                                   double.Parse(match.Groups["price"].Value);

                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {price:F2}");

                    totalPrice += price;
                }
            }

            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}

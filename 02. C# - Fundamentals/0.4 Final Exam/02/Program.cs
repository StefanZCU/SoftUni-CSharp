using System;
using System.Text.RegularExpressions;

namespace _02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$]|[%])(?<tag>[A-Z][a-z]{2,})\1[:][ ]\[(?<charOne>[\d]+)\]\|\[(?<charTwo>[\d]+)\]\|\[(?<charThree>[\d]+)\]\|$";

            int numInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numInputs; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                }
                else
                {
                    int firstChar = int.Parse(match.Groups["charOne"].Value);
                    int secondChar = int.Parse(match.Groups["charTwo"].Value);
                    int thirdChar = int.Parse(match.Groups["charThree"].Value);

                    Console.WriteLine($"{match.Groups["tag"].Value}: {(char)firstChar}{(char)secondChar}{(char)thirdChar}");
                }
            }
        }
    }
}

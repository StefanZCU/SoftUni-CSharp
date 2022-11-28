using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string getNameRegex = @"[A-Za-z+]";
            string getNumRegex = @"[0-9]";

            Dictionary<string, int> map = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder sb = new StringBuilder();

                MatchCollection nameChars = Regex.Matches(input, getNameRegex);

                foreach (Match nameArg in nameChars)
                {
                    sb.Append(nameArg.Value);
                }

                MatchCollection kmPerPerson = Regex.Matches(input, getNumRegex);

                int totalKmPerPerson = 0;
                foreach (Match digit in kmPerPerson)
                {
                    totalKmPerPerson += int.Parse(digit.Value);
                }

                string name = sb.ToString();
                if (participants.Contains(name))
                {
                    if (!map.ContainsKey(name))
                    {
                        map.Add(name, 0);
                    }

                    map[name] += totalKmPerPerson;
                }
            }

            //List<KeyValuePair<string, int>> newList =
            //    map.ToList();

            //newList.Sort(delegate(KeyValuePair<string, int>))

            int i = 1;
            foreach (var name in map.OrderByDescending(x => x.Value))
            {

                if (i == 1)
                {
                    Console.WriteLine($"1st place: {name.Key}");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"2nd place: {name.Key}");
                }
                else if (i == 3)
                {
                    Console.WriteLine($"3rd place: {name.Key}");
                    break;
                }

                i++;
            }
        }
    }
}

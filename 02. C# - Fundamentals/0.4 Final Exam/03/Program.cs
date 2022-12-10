using System;
using System.Collections.Generic;

namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Enroll")
                {
                    if (!heroes.ContainsKey(input[1]))
                    {
                        heroes.Add(input[1], new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} is already enrolled.");
                    }
                }
                else if (input[0] == "Learn")
                {
                    string heroName = input[1];
                    string spellName = input[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Add(spellName);
                    }
                }
                else if (input[0] == "Unlearn")
                {
                    string heroName = input[1];
                    string spellName = input[2];

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        heroes[heroName].Remove(spellName);
                    }
                }
            }

            Console.WriteLine("Heroes:");

            foreach (var hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarvesByName = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] input = command.Split(" <:> ");

                string currentDwarfName = input[0];
                string currentDwarfHatColor = input[1];
                int currentDwarfPhysics = int.Parse(input[2]);

                if (!dwarvesByName.ContainsKey($"{currentDwarfName}:{currentDwarfHatColor}"))
                {
                    dwarvesByName.Add($"{currentDwarfName}:{currentDwarfHatColor}", currentDwarfPhysics);
                }

                if (dwarvesByName.ContainsKey($"{currentDwarfName}:{currentDwarfHatColor}") && dwarvesByName[$"{currentDwarfName}:{currentDwarfHatColor}"] < currentDwarfPhysics)
                {
                    dwarvesByName[$"{currentDwarfName}:{currentDwarfHatColor}"] = currentDwarfPhysics;
                }
            }

            foreach (var dwarf in dwarvesByName.OrderByDescending(x => x.Value).ThenByDescending(x => dwarvesByName.Count(d => d.Key.Split(':')[1] == x.Key.Split(':')[1])))
            {
                string[] currentDwarf = dwarf.Key.Split(":", StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine($"({currentDwarf[1]}) {currentDwarf[0]} <-> {dwarf.Value}");
            }
            
        }
    }
}



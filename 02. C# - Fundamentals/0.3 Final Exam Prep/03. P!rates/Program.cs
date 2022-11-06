using System;
using System.Collections.Generic;
using System.Drawing;

namespace _03._P_rates
{
    public class PopulationGold
    {
        public int Population { get; set; }
        public int Gold { get; set; }

        public PopulationGold(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PopulationGold> citiesPG = new Dictionary<string, PopulationGold>();
            List<string> citiesToDisban = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] input = command.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string city = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (!citiesPG.ContainsKey(city))
                {
                    PopulationGold populationGold = new PopulationGold(population, gold);
                    citiesPG.Add(city, populationGold);
                }
                else
                {
                    citiesPG[city].Population += population;
                    citiesPG[city].Gold += gold;
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = input[0];

                if (cmdArg == "Plunder")
                {
                    string town = input[1];
                    int peopleAmount = int.Parse(input[2]);
                    int gold = int.Parse(input[3]);

                    if (!citiesToDisban.Contains(town))
                    {
                        citiesPG[town].Gold -= gold;
                        citiesPG[town].Population -= peopleAmount;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {peopleAmount} citizens killed.");

                        if (citiesPG[town].Gold <= 0 || citiesPG[town].Population <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            citiesToDisban.Add(town);
                        }
                    }
                }
                else if (cmdArg == "Prosper")
                {
                    string town = input[1];
                    int gold = int.Parse(input[2]);


                    if (!citiesToDisban.Contains(town))
                    {
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            citiesPG[town].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {citiesPG[town].Gold} gold.");
                        }
                    }
                }
            }


            foreach (var city in citiesToDisban)
            {
                citiesPG.Remove(city);
            }

            if (citiesPG.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesPG.Count} wealthy settlements to go to:");

                foreach (var city in citiesPG)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
        }
    }
}

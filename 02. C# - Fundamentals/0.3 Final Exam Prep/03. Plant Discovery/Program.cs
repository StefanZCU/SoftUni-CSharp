using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            Dictionary<string, int> rarityPerPlant = new Dictionary<string, int>();
            Dictionary<string, List<double>> ratingPerPlant = new Dictionary<string, List<double>>();

            for (int i = 0; i < numLines; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = input[0];
                int rarity = int.Parse(input[1]);

                if (!rarityPerPlant.ContainsKey(plant))
                {
                    rarityPerPlant.Add(plant, rarity);
                    ratingPerPlant.Add(plant, new List<double>());
                }
                else
                {
                    rarityPerPlant[plant] = rarity;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] input = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArgs = input[0];

                if (cmdArgs == "Rate")
                {
                    string[] plantRating = input[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = plantRating[0];
                    double rating = double.Parse(plantRating[1]);

                    if (ratingPerPlant.ContainsKey(plant))
                    {
                        ratingPerPlant[plant].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs == "Update")
                {
                    string[] plantRarity = input[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string plant = plantRarity[0];
                    int rarity = int.Parse(plantRarity[1]);

                    if (rarityPerPlant.ContainsKey(plant))
                    {
                        rarityPerPlant[plant] = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (cmdArgs == "Reset")
                {
                    if (ratingPerPlant.ContainsKey(input[1]))
                    {

                        ratingPerPlant[input[1]].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            double average = 0.0;

            foreach (var plant in rarityPerPlant)
            {
                foreach (var ratingName in ratingPerPlant)
                {
                    if (ratingName.Key == plant.Key)
                    {
                        foreach (var rating in ratingName.Value)
                        {
                            average += rating;
                        }

                        if (average == 0)
                        {
                            Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: 0.00");
                            average = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {average / ratingName.Value.Count:F2}");
                            average = 0;
                            break;
                        }
                    }
                }
            }
        }
    }
}

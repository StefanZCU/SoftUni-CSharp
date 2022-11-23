using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colorClotheCount =
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] color = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (!colorClotheCount.ContainsKey(color[0]))
                {
                    colorClotheCount[color[0]] = new Dictionary<string, int>();

                }

                string[] items = color[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < items.Length; j++)
                {
                    if (!colorClotheCount[color[0]].ContainsKey(items[j]))
                    {
                        colorClotheCount[color[0]][items[j]] = 0;
                    }

                    colorClotheCount[color[0]][items[j]]++;
                }
            }

            string[] itemToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string colorToFind = itemToFind[0];
            string clotheToFind = itemToFind[1];

            foreach (var color in colorClotheCount)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothe in color.Value)
                {
                    if (clothe.Key == clotheToFind && color.Key == colorToFind)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }

        }
    }
}

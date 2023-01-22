using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> locationCount = new Dictionary<string, int>()
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0 }
            };


            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int newTile = whiteTiles.Peek() + greyTiles.Peek();

                    if (newTile == 70)
                    {
                        locationCount["Wall"]++;
                    }
                    else if (newTile == 60)
                    {
                        locationCount["Countertop"]++;
                    }
                    else if (newTile == 50)
                    {
                        locationCount["Oven"]++;
                    }
                    else if (newTile == 40)
                    {
                        locationCount["Sink"]++;
                    }
                    else
                    {
                        locationCount["Floor"]++;
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    int newWhiteTile = whiteTiles.Pop();
                    whiteTiles.Push(newWhiteTile / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            Console.WriteLine(whiteTiles.Count == 0
                ? "White tiles left: none"
                : $"White tiles left: {string.Join(", ", whiteTiles)}");

            Console.WriteLine(greyTiles.Count == 0
                ? "Grey tiles left: none"
                : $"Grey tiles left: {string.Join(", ", greyTiles)}");

            foreach (var location in locationCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (location.Value != 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}

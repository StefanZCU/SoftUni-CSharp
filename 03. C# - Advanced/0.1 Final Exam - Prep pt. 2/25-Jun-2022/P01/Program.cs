namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Queue<int> grayTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<string, int> tilesMade = new Dictionary<string, int>
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0 },
                { "Wall", 0 },
                { "Floor", 0 }
            };

            while (whiteTiles.Any() && grayTiles.Any())
            {
                if (whiteTiles.Peek() == grayTiles.Peek())
                {
                    switch (whiteTiles.Peek() + grayTiles.Peek())
                    {
                        case 40:
                            tilesMade["Sink"]++;
                            break;
                        case 50:
                            tilesMade["Oven"]++;
                            break;
                        case 60:
                            tilesMade["Countertop"]++;
                            break;
                        case 70:
                            tilesMade["Wall"]++;
                            break;
                        default:
                            tilesMade["Floor"]++;
                            break;
                    }

                    whiteTiles.Pop();
                    grayTiles.Dequeue();
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    grayTiles.Enqueue(grayTiles.Dequeue());
                }
            }

            Console.WriteLine(whiteTiles.Any()
                ? $"White tiles left: {string.Join(", ", whiteTiles)}"
                : "White tiles left: none");

            Console.WriteLine(grayTiles.Any()
                ? $"Grey tiles left: {string.Join(", ", grayTiles)}"
                : "Grey tiles left: none");

            foreach (var tile in tilesMade.Where(x => x.Value >= 1).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
        }
    }
}

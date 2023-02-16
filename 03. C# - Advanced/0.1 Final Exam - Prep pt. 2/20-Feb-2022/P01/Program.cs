namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (water.Any() && flour.Any())
            {
                var productSum = water.Peek() + flour.Peek();
                var waterRatio = (water.Peek() / productSum) * 100;

                switch (waterRatio)
                {
                    case 50:
                        bakedProducts["Croissant"]++;
                        flour.Pop();
                        break;
                    case 40:
                        bakedProducts["Muffin"]++;
                        flour.Pop();
                        break;
                    case 30:
                        bakedProducts["Baguette"]++;
                        flour.Pop();
                        break;
                    case 20:
                        bakedProducts["Bagel"]++;
                        flour.Pop();
                        break;
                    default:
                        flour.Push(flour.Pop() - water.Peek());
                        bakedProducts["Croissant"]++;
                        break;
                }

                water.Dequeue();
            }

            foreach (var bakedProduct in bakedProducts
                         .Where(x => x.Value >= 1)
                         .OrderByDescending(x => x.Value)
                         .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{bakedProduct.Key}: {bakedProduct.Value}");
            }

            Console.WriteLine(water.Any()
                ? $"Water left: {string.Join(", ", water)}"
                : "Water left: None");

            Console.WriteLine(flour.Any()
                ? $"Flour left: {string.Join(", ", flour)}"
                : "Flour left: None");
        }
    }
}

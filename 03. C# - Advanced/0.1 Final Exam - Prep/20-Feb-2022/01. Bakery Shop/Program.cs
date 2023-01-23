using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());

            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray());


            Dictionary<string, int> productsQnt = new Dictionary<string, int>
            {
                { "Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0 },
                { "Bagel", 0 }
            };

            while (water.Any() && flour.Any())
            {
                var waterAndFlour = flour.Peek() + water.Peek();
                var ratioWater = water.Peek() / waterAndFlour * 100;
                var ratioFlour = flour.Peek() / waterAndFlour * 100;

                if (ratioWater == ratioFlour)
                {
                    productsQnt["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (ratioWater == 40 && ratioFlour == 60)
                {
                    productsQnt["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (ratioWater == 30 && ratioFlour == 70)
                {
                    productsQnt["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (ratioWater == 20 && ratioFlour == 80)
                {
                    productsQnt["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    var currentFlour = flour.Pop();
                    currentFlour -= water.Dequeue();
                    flour.Push(currentFlour);
                    productsQnt["Croissant"]++;
                }
            }

            foreach (var product in productsQnt.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                if (product.Value != 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
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

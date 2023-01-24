using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> cookedDishes = new Dictionary<string, int>
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                var freshnessLevel = ingredients.Peek() * freshness.Peek();

                switch (freshnessLevel)
                {
                    case 150:
                        cookedDishes["Dipping sauce"]++;
                        ingredients.Dequeue();
                        break;
                    case 250:
                        cookedDishes["Green salad"]++;
                        ingredients.Dequeue();
                        break;
                    case 300:
                        cookedDishes["Chocolate cake"]++;
                        ingredients.Dequeue();
                        break;
                    case 400:
                        cookedDishes["Lobster"]++;
                        ingredients.Dequeue();
                        break;
                    default:
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                        break;
                }

                freshness.Pop();
            }

            Console.WriteLine(cookedDishes.All(x => x.Value >= 1)
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cookedDish in cookedDishes.Where(x => x.Value >= 1).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {cookedDish.Key} --> {cookedDish.Value}");
            }

        }
    }
}

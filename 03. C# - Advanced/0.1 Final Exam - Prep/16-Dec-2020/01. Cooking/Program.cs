using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> cookedFood = new Dictionary<string, int>
            {
                { "Bread", 0 },
                { "Cake", 0 },
                { "Pastry", 0 },
                { "Fruit Pie", 0 }
            };

            while (liquids.Any() && ingredients.Any())
            {
                var foodValue = liquids.Peek() + ingredients.Peek();

                switch (foodValue)
                {
                    case 25:
                        cookedFood["Bread"]++;
                        ingredients.Pop();
                        break;
                    case 50:
                        cookedFood["Cake"]++;
                        ingredients.Pop();
                        break;
                    case 75:
                        cookedFood["Pastry"]++;
                        ingredients.Pop();
                        break;
                    case 100:
                        cookedFood["Fruit Pie"]++;
                        ingredients.Pop();
                        break;
                    default:
                        ingredients.Push(ingredients.Pop() + 3);
                        break;
                }

                liquids.Dequeue();
            }

            Console.WriteLine(cookedFood.All(x => x.Value >= 1)
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Any() 
                ? $"Liquids left: {string.Join(", ", liquids)}" 
                : "Liquids left: none");

            Console.WriteLine(ingredients.Any()
                ? $"Ingredients left: {string.Join(", ", ingredients)}"
                : "Ingredients left: none");

            foreach (var food in cookedFood.OrderBy( x=> x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}

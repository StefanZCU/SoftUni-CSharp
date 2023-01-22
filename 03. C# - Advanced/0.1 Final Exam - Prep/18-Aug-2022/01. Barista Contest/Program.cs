using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantity = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> milkQuantity = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> drinksMade = new Dictionary<string, int>
            {
                { "Cortado" , 0 },
                { "Espresso" , 0 },
                { "Capuccino" , 0 },
                { "Americano" , 0 },
                { "Latte" , 0 }
            };

            while (coffeeQuantity.Any() && milkQuantity.Any())
            {
                int quantity = coffeeQuantity.Peek() + milkQuantity.Peek();

                if (quantity == 200)
                {
                    drinksMade["Latte"]++;
                    milkQuantity.Pop();
                }
                else if (quantity == 150)
                {
                    drinksMade["Americano"]++;
                    milkQuantity.Pop();
                }
                else if (quantity == 100)
                {
                    drinksMade["Capuccino"]++;
                    milkQuantity.Pop();
                }
                else if (quantity == 75)
                {
                    drinksMade["Espresso"]++;
                    milkQuantity.Pop();
                }
                else if (quantity == 50)
                {
                    drinksMade["Cortado"]++;
                    milkQuantity.Pop();
                }
                else
                {
                    var currMilk = milkQuantity.Pop();
                    milkQuantity.Push(currMilk - 5);
                }

                coffeeQuantity.Dequeue();
            }

            if (coffeeQuantity.Count == 0 && milkQuantity.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (!coffeeQuantity.Any())
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantity)}");
            }

            if (!milkQuantity.Any())
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantity)}");
            }

            foreach (var drink in drinksMade.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (drink.Value != 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
            }
        }
    }
}

namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantity = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> milkQuantity = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> drinksMade = new Dictionary<string, int>
            {
                { "Cortado", 0 },
                { "Espresso", 0 },
                { "Capuccino", 0 },
                { "Americano", 0 },
                { "Latte", 0 }
            };

            while (coffeeQuantity.Any() && milkQuantity.Any())
            {
                var coffeeSum = coffeeQuantity.Peek() + milkQuantity.Peek();

                switch (coffeeSum)
                {
                    case 50:
                        drinksMade["Cortado"]++;
                        milkQuantity.Pop();
                        break;
                    case 75:
                        drinksMade["Espresso"]++;
                        milkQuantity.Pop();
                        break;
                    case 100:
                        drinksMade["Capuccino"]++;
                        milkQuantity.Pop();
                        break;
                    case 150:
                        drinksMade["Americano"]++;
                        milkQuantity.Pop();
                        break;
                    case 200:
                        drinksMade["Latte"]++;
                        milkQuantity.Pop();
                        break;
                    default:
                        milkQuantity.Push(milkQuantity.Pop() - 5);
                        break;
                }

                coffeeQuantity.Dequeue();
            }

            Console.WriteLine(!coffeeQuantity.Any() && !milkQuantity.Any()
                ? "Nina is going to win! She used all the coffee and milk!"
                : "Nina needs to exercise more! She didn't use all the coffee and milk!");

            Console.WriteLine(coffeeQuantity.Any()
                ? $"Coffee left: {string.Join(", ", coffeeQuantity)}"
                : "Coffee left: none");

            Console.WriteLine(milkQuantity.Any()
                ? $"Milk left: {string.Join(", ", milkQuantity)}"
                : "Milk left: none");

            foreach (var drinks in drinksMade.Where(x => x.Value >= 1).OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drinks.Key}: {drinks.Value}");
            }
        }
    }
}

namespace P01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> energyDrink = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int caffeineDrank = 0;

            while (caffeine.Any() && energyDrink.Any())
            {
                if (caffeine.Peek() * energyDrink.Peek() + caffeineDrank <= 300)
                {
                    caffeineDrank += caffeine.Pop() * energyDrink.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    if (caffeineDrank - 30 >= 0)
                    {
                        caffeineDrank -= 30;
                    }
                    else
                    {
                        caffeineDrank = 0;
                    }
                    energyDrink.Enqueue(energyDrink.Dequeue());
                }
            }

            Console.WriteLine(energyDrink.Any()
                ? $"Drinks left: {string.Join(", ", energyDrink)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.");

            Console.WriteLine($"Stamat is going to sleep with {caffeineDrank} mg caffeine.");
        }
    }
}
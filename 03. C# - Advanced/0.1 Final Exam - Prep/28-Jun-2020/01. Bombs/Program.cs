using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()); 
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> bombPouch = new Dictionary<string, int>
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };
            bool filledPouch = false;
            while (bombEffect.Any() && bombCasings.Any())
            {
                var value = bombEffect.Peek() + bombCasings.Peek();

                switch (value)
                {
                    case 40:
                        bombPouch["Datura Bombs"]++;
                        bombEffect.Dequeue();
                        bombCasings.Pop();
                        break;
                    case 60:
                        bombPouch["Cherry Bombs"]++;
                        bombEffect.Dequeue();
                        bombCasings.Pop();
                        break;
                    case 120:
                        bombPouch["Smoke Decoy Bombs"]++;
                        bombEffect.Dequeue();
                        bombCasings.Pop();
                        break;
                    default:
                        bombCasings.Push(bombCasings.Pop() - 5);
                        break;
                }

                if (bombPouch.All(x => x.Value >= 3))
                {
                    filledPouch = true;
                    break;
                }
            }

            Console.WriteLine(filledPouch 
                ? "Bene! You have successfully filled the bomb pouch!" 
                :"You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(bombEffect.Any()
                ? $"Bomb Effects: {string.Join(", ", bombEffect)}"
                : "Bomb Effects: empty");

            Console.WriteLine(bombCasings.Any()
                ? $"Bomb Casings: {string.Join(", ", bombCasings)}"
                : "Bomb Casings: empty");

            foreach (var bomb in bombPouch.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}

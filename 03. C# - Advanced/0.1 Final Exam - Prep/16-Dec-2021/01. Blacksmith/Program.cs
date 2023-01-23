using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> swordsForged = new Dictionary<string, int>
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 },

            };

            while (steel.Any() && carbon.Any())
            {
                var value = steel.Peek() + carbon.Peek();

                switch (value)
                {
                    case 70:
                        swordsForged["Gladius"]++;
                        carbon.Pop();
                        break;
                    case 80:
                        swordsForged["Shamshir"]++;
                        carbon.Pop();
                        break;
                    case 90:
                        swordsForged["Katana"]++;
                        carbon.Pop();
                        break;
                    case 110:
                        swordsForged["Sabre"]++;
                        carbon.Pop();
                        break;
                    case 150:
                        swordsForged["Broadsword"]++;
                        carbon.Pop();
                        break;
                    default:
                        var newCarbon = carbon.Pop() + 5;
                        carbon.Push(newCarbon);
                        break;
                }

                steel.Dequeue();
            }

            Console.WriteLine(swordsForged.Any(x => x.Value > 0)
                ? $"You have forged {swordsForged.Sum(x => x.Value)} swords."
                : "You did not have enough resources to forge a sword.");

            Console.WriteLine(steel.Any()
                ? $"Steel left: {string.Join(", ", steel)}"
                : "Steel left: none");

            Console.WriteLine(carbon.Any()
                ? $"Carbon left: {string.Join(", ", carbon)}"
                : "Carbon left: none");

            foreach (var sword in swordsForged.OrderBy(x => x.Key))
            {
                if (sword.Value != 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}

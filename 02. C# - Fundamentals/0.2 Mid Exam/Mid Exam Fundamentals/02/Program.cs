using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coffeeNames = Console.ReadLine().Split(" ").ToList();
            int numCMDS = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCMDS; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Include")
                {
                    coffeeNames.Add(input[1]);
                }
                else if (input[0] == "Remove")
                {
                    if (int.Parse(input[2]) >= 0 && int.Parse(input[2]) < coffeeNames.Count)
                    {
                        if (input[1] == "first")
                        {
                            for (int j = 0; j < int.Parse(input[2]); j++)
                            {
                                coffeeNames.RemoveAt(0);
                            }
                        }
                        else if (input[1] == "last")
                        {
                            for (int j = 0; j < int.Parse(input[2]); j++)
                            {
                                coffeeNames.RemoveAt(coffeeNames.Count - 1);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Prefer")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < coffeeNames.Count && int.Parse(input[2]) >= 0 && int.Parse(input[2]) < coffeeNames.Count)
                    {
                        string tempCoffee = coffeeNames[int.Parse(input[1])];
                        coffeeNames[int.Parse(input[1])] = coffeeNames[int.Parse(input[2])];
                        coffeeNames[int.Parse(input[2])] = tempCoffee;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Reverse")
                {
                    coffeeNames.Reverse();
                }
            }
            Console.WriteLine("Coffees:");
            Console.WriteLine(String.Join(" ", coffeeNames));
        }
    }
}

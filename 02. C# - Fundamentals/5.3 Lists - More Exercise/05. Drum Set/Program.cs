using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialSavings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> initialQualities = drumSet.ToList();

            string command;
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int currentHit = int.Parse(command);

                for (int i = 0; i < initialQualities.Count; i++)
                {
                    drumSet[i] -= currentHit;

                    if (drumSet[i] <= 0)
                    {
                        if (initialSavings < (initialQualities[i] * 3))
                        {
                            initialQualities.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            initialSavings -= (initialQualities[i] * 3);
                            drumSet[i] = initialQualities[i];
                        }

                    }
                }
            }

            Console.WriteLine(String.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {initialSavings:F2}lv.");
        }
    }
}

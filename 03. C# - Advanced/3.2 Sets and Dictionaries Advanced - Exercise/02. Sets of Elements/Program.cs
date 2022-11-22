using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int[] numCycles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numCycles[0] + numCycles[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }

                numbers[num]++;
            }

            foreach (var num in numbers)
            {
                if (num.Value > 1)
                {
                    Console.Write($"{num.Key} ");
                }
            }

        }
    }
}

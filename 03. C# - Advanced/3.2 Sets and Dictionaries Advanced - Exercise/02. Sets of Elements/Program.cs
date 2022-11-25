using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numCycles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();

            for (int i = 0; i < numCycles[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < numCycles[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            HashSet<int> uniqueNums = new HashSet<int>();

            foreach (int num1 in firstSet)
            {
                foreach (var num2 in secondSet)
                {
                    if (num1 == num2)
                    {
                        uniqueNums.Add(num1);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", uniqueNums));
        }
    }
}

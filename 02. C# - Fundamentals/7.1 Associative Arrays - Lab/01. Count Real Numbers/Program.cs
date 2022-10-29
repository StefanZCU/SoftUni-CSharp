using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;

namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SortedDictionary<int, int> numOccurences = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!numOccurences.ContainsKey(number))
                {
                    numOccurences.Add(number, 0);
                }

                numOccurences[number]++;
            }

            foreach (var keyNumOccurence in numOccurences)
            {
                Console.WriteLine($"{keyNumOccurence.Key} -> {keyNumOccurence.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numOccurences = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numOccurences.ContainsKey(num))
                {
                    numOccurences.Add(num, 0);
                }

                numOccurences[num]++;
            }

            foreach (var numOccurence in numOccurences)
            {
                if (numOccurence.Value % 2 == 0)
                {
                    Console.WriteLine(numOccurence.Key);
                }
            }
        }
    }
}

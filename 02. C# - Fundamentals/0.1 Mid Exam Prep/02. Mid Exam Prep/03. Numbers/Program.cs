using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> topFive = new List<int>();

            double average = numSequence.Average();
            numSequence.Sort();
            numSequence.Reverse();

            int count = 0;
            foreach (int item in numSequence)
            {
                if (item > average)
                {
                    topFive.Add(item);
                    count++;
                }
                if (count == 5)
                {
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(String.Join(" ", topFive));
            }


        }
    }
}
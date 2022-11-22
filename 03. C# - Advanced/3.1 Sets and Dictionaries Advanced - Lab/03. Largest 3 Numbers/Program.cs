using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sortedNums = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < sortedNums.Length; i++)
            {
                Console.Write($"{sortedNums[i]} ");

                if (i == 2)
                {
                    break;
                }
            }
        }
    }
}

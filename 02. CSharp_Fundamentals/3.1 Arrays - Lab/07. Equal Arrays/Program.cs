using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] arr2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool flag = true;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                int sum = 0;

                for (int i = 0; i < arr1.Length; i++)
                {
                    sum += arr1[i];
                }
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}


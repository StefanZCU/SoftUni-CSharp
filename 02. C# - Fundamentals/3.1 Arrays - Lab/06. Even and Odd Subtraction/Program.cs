using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0; 

            for (int i = 0; i < numberArr.Length; i++)
            {
                if (numberArr[i] % 2 == 0)
                {
                    evenSum += numberArr[i];
                }
                else
                {
                    oddSum += numberArr[i];
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}

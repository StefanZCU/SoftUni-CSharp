using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().
                Split().Select(double.Parse).ToArray();

            double[] newNum = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                newNum[i] = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers[i]} => {newNum[i]}");
            }


        }
    }
}

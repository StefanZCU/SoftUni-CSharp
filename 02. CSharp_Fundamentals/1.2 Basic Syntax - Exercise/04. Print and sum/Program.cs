
using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int total = 0;

            for (int i = num1; i <= num2; i++)
            {
                total += i;
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {total}");
        }
    }
}

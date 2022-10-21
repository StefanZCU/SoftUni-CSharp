using System;
using System.Numerics;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result1 = (double)GetFactorial(num1);
            double result2 = (double)GetFactorial(num2);

            double finalResult = GetResult(result1, result2);
            Console.WriteLine($"{finalResult:F2}");
        }

        static BigInteger GetFactorial(int num)
        {
            BigInteger sum = num;

            for (int i = num - 1; i > 0; i--)
            {
                sum *= i;
            }

            return sum;
        }

        static double GetResult(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}

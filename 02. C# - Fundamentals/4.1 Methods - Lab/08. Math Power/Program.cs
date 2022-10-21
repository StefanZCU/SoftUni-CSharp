using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
            double powerNum = double.Parse(Console.ReadLine());

            double finalNum = GetPower(baseNum, powerNum);

            Console.WriteLine(finalNum);

        }

        static double GetPower(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }
    }
}

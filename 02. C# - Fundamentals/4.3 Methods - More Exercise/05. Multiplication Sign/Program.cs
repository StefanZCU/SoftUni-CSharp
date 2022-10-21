using System;

namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (FindZero(num1, num2, num3))
            {
                Console.WriteLine("zero");
            }
            else if (FindPositiveNegative(num1, num2, num3))
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

        static bool FindPositiveNegative(int num1, int num2, int num3)
        {
            int negativeCounter = 0;

            if (num1 < 0)
            {
                negativeCounter++;
            }
            if (num2 < 0)
            {
                negativeCounter++;
            }
            if (num3 < 0)
            {
                negativeCounter++;
            }

            if (negativeCounter % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool FindZero(int num1, int num2, int num3)
        {
            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                return true;
            }

            return false;
        }
    }
}

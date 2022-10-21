using System;
using System.Linq;
using System.Numerics;

namespace _03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());


            if (num1 > num2)
            {
                if (num1 - num2 < 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
            else
            {
                if (num2 - num1 < 0.000001)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}

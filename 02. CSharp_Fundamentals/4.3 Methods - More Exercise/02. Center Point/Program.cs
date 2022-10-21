using System;

namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double result1 = FindClosest(x1, y1);
            double result2 = FindClosest(x2, y2);

            if (result1 == result2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (result2 < result1)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }

        static double FindClosest(double num1, double num2)
        {
            return Math.Abs(num1) + Math.Abs(num2);
        }
    }
}

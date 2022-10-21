using System;

namespace _03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine()); 

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double sum1 = GetSumCoordinates(x1, y1, x2, y2);
            double sum2 = GetSumCoordinates(x3, y3, x4, y4);

            if (sum1 >= sum2)
            {
                double result1 = FindClosest(x1, y1);
                double result2 = FindClosest(x2, y2);

                if (result1 == result2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else if (result2 < result1)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
            else
            {
                double result1 = FindClosest(x3, y3);
                double result2 = FindClosest(x4, y4);

                if (result1 == result2)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else if (result2 < result1)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
            }
        }

        static double GetSumCoordinates(double num1, double num2, double num3, double num4)
        {
            return Math.Abs(num1) + Math.Abs(num2) + Math.Abs(num3) + Math.Abs(num4);
        }

        static double FindClosest(double num1, double num2)
        {
            return Math.Abs(num1) + Math.Abs(num2);
        }
    }
}

using System;

namespace _06._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = int.Parse(Console.ReadLine());
            double num2 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            if (symbol == "+")
            {
                double sum = num1 + num2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} + {num2} = {sum} - odd");
                }
            }
            else if (symbol == "-")
            {
                double sum = num1 - num2;

                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} - {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} - {num2} = {sum} - odd");
                }
            }
            else if (symbol == "*")
            {
                double sum = num1 * num2;

                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{num1} * {num2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} * {num2} = {sum} - odd");
                }

            }
            else if (symbol == "/")
            {
                double sum = num1 / num2;

                if (num1 == 0)
                {
                    Console.WriteLine($"Cannot divide {num2} by zero");
                }
                else if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} / {num2} = {sum:F2}");
                }
            }
            else if (symbol == "%")
            {
                double sum = num1 % num2;
                if (num1 == 0)
                {
                    Console.WriteLine($"Cannot divide {num2} by zero");
                }
                else if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    Console.WriteLine($"{num1} % {num2} = {sum}");
                }
            }
        }
    }
}

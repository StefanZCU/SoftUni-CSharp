using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string mathOperator = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            if (mathOperator == "*")
            {
                int result = GetMultiply(num1, num2);
                Console.WriteLine(result);
            }
            else if (mathOperator == "+")
            {
                int result = GetAddition(num1, num2);
                Console.WriteLine(result);
            }
            else if (mathOperator == "-")
            {
                int result = GetSubtraction(num1, num2);
                Console.WriteLine(result);
            }
            else if (mathOperator == "/")
            {
                double result = GetDivision(num1, num2);
                Console.WriteLine(result);
            }
        }

        static int GetMultiply(int num1, int num2)
        {
            return num1 * num2;
        }
        static int GetAddition(int num1, int num2)
        {
            return num1 + num2;
        }
        static int GetSubtraction(int num1, int num2)
        {
            return num1 - num2;
        }
        static double GetDivision(int num1, int num2)
        {
            double result = (double)num1 / (double)num2;
            return result;
        }
    }
}

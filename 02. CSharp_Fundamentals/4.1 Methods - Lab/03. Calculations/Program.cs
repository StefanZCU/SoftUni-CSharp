using System;
using System.Reflection.Metadata.Ecma335;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string AMSDstring = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (AMSDstring == "add")
            {
                int newNum = Add(num1, num2);
                Console.WriteLine(newNum);
            }
            else if (AMSDstring == "subtract")
            {
                int newNum = Subtract(num1, num2);
                Console.WriteLine(newNum);
            }
            else if (AMSDstring == "divide")
            {
                int newNum = Divide(num1, num2);
                Console.WriteLine(newNum);
            }
            else if (AMSDstring == "multiply")
            {
                int newNum = Multiply(num1, num2);
                Console.WriteLine(newNum);
            }
        }

        static int Add(int num1, int num2)
        {
            int newNum = num1 + num2;
            return newNum;
        }
        static int Subtract(int num1, int num2)
        {
            int newNum = num1 - num2;
            return newNum;
        }

        static int Multiply(int num1, int num2)
        {
            int newNum = num1 * num2;
            return newNum;
        }

        static int Divide(int num1, int num2)
        {
            int newNum = num1 / num2;
            return newNum;
        }
    }
}

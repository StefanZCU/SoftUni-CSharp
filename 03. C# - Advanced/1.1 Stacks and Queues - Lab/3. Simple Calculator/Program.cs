using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<string> calculator = new Stack<string>(expression.Split().Reverse());

            while (calculator.Count != 1)
            {
                int num1 = int.Parse(calculator.Pop());
                char symbol = char.Parse(calculator.Pop());
                int num2 = int.Parse(calculator.Pop());

                if (symbol == '-')
                {
                    calculator.Push((num1 - num2).ToString());
                }
                else if (symbol == '+')
                {
                    calculator.Push((num1 + num2).ToString());
                }
            }

            Console.WriteLine(calculator.Peek());
        }
    }
}

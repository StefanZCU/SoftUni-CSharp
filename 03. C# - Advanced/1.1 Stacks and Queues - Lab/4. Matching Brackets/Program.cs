using System;
using System.Collections;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> openingBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBrackets.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int index = openingBrackets.Pop();
                    string text = expression.Substring(index, i - index + 1);
                    Console.WriteLine($"{text}");
                }
            }

        }
    }
}

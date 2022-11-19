using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numQueries = int.Parse(Console.ReadLine());
            Stack<int> numberStack = new Stack<int>();

            for (int i = 0; i < numQueries; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "1")
                {
                    numberStack.Push(int.Parse(cmdArgs[1]));
                }
                else if (cmdArgs[0] == "2")
                {
                    if (numberStack.Count != 0)
                    {
                        numberStack.Pop();
                    }
                }
                else if (cmdArgs[0] == "3")
                {
                    if (numberStack.Count != 0)
                    {
                        Console.WriteLine(numberStack.Max());
                    }
                }
                else if (cmdArgs[0] == "4")
                {
                    if (numberStack.Count != 0)
                    {
                        Console.WriteLine(numberStack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numberStack));
        }
    }
}

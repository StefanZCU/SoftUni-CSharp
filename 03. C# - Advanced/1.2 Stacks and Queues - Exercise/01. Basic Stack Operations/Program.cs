using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>();

            int smallestNum = int.MaxValue;

            for (int i = 0; i < NSX[0]; i++)
            {
                numbers.Push(numArray[i]);
            }

            for (int i = 0; i < NSX[1]; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count >= 1)
            {
                if (numbers.Contains(NSX[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    int originalCount = numbers.Count;

                    for (int i = 0; i < originalCount; i++)
                    {
                        int currentNum = numbers.Pop();

                        if (smallestNum > currentNum)
                        {
                            smallestNum = currentNum;
                        }
                    }

                    Console.WriteLine(smallestNum);
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}

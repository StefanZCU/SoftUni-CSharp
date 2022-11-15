using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>();

            int smallestNum = int.MaxValue;

            for (int i = 0; i < NSX[0]; i++)
            {
                numbers.Enqueue(numArray[i]);
            }

            for (int i = 0; i < NSX[1]; i++)
            {
                numbers.Dequeue();
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
                        int currentNum = numbers.Dequeue();

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

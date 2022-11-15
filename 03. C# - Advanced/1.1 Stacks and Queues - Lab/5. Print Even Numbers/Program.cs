using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numQueue = new Queue<int>();
            Queue<int> finalQueue = new Queue<int>();

            for (int i = 0; i < numArray.Length; i++)
            {
                numQueue.Enqueue(numArray[i]);
            }

            int originalCount = numQueue.Count;

            for (int i = 0; i < originalCount; i++)
            {
                if (numQueue.Peek() % 2 == 0)
                {
                    finalQueue.Enqueue(numQueue.Peek());
                }

                numQueue.Dequeue();
            }

            Console.WriteLine(string.Join(", ", finalQueue));
        }
    }
}

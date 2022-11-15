using System;
using System.Collections;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Queue<string> namesPlayers = new Queue<string>(names);

            int numTosses = int.Parse(Console.ReadLine());

            while (namesPlayers.Count != 1)
            {
                for (int i = 0; i < numTosses; i++)
                {
                    if (i == numTosses - 1)
                    {
                        Console.WriteLine($"Removed {namesPlayers.Dequeue()}");
                    }
                    else
                    {
                        namesPlayers.Enqueue(namesPlayers.Peek());
                        namesPlayers.Dequeue();
                    }
                }
            }

            Console.WriteLine($"Last is {namesPlayers.Peek()}");
        }
    }
}

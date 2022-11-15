using System;
using System.Collections;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    int originalCount = names.Count;

                    for (int i = 0; i < originalCount; i++)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else
                {
                    names.Enqueue(command);
                }
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCarsLight = int.Parse(Console.ReadLine());
            Queue<string> totalCars = new Queue<string>();

            int passedCounter = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numCarsLight; i++)
                    {
                        if (totalCars.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{totalCars.Dequeue()} passed!");
                            passedCounter++;
                        }
                    }
                }
                else
                {
                    totalCars.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCounter} cars passed the crossroads.");
        }
    }
}

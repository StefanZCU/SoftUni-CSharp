using System;
using System.ComponentModel;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            if (capacity >= numPeople)
            {
                Console.WriteLine(1);
            }

            else
            {
                if (numPeople / capacity >= 1)
                {
                    int firstCourse = numPeople / capacity;

                    if (numPeople % capacity != 0)
                    {
                        firstCourse++;
                    }

                    Console.WriteLine(firstCourse);
                }
            }

            
        }
    }
}

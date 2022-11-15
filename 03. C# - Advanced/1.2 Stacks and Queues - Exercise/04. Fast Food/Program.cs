using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalQuantityFood = int.Parse(Console.ReadLine());

            int[] customerArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> customers = new Queue<int>(customerArray);

            Console.WriteLine(customers.Max());

            while (true)
            {
                if (customers.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
                else
                {
                    if (totalQuantityFood - customers.Peek() >= 0)
                    {
                        totalQuantityFood -= customers.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine($"Orders left: {string.Join(" ", customers)}");
                        break;
                    }
                }
            }
        }
    }
}

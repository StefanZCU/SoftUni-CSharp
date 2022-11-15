using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesValue);

            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int currentValue = 0;

            while (clothes.Count != 0)
            {
                currentValue += clothes.Peek();

                if (currentValue == rackCapacity)
                {
                    currentValue = 0;
                    rackCount++;
                    clothes.Pop();
                }
                else if (currentValue > rackCapacity)
                {
                    currentValue = 0;
                    currentValue += clothes.Pop();
                    rackCount++;
                }
                else
                {
                    clothes.Pop();
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}

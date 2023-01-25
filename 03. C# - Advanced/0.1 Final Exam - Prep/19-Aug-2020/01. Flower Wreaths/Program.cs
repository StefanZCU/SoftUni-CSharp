using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int leftOverFlowers = 0;
            int wreathesMade = 0;

            while (lilies.Any() && roses.Any())
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    wreathesMade++;
                    lilies.Pop();
                    roses.Dequeue();
                    continue;
                }

                if (lilies.Peek() + roses.Peek() > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                    continue;
                }

                if (lilies.Peek() + roses.Peek() < 15)
                {
                    leftOverFlowers += (lilies.Pop() + roses.Dequeue());
                }
            }

            while (leftOverFlowers > 15)
            {
                leftOverFlowers -= 15;
                wreathesMade++;
            }

            Console.WriteLine(wreathesMade >= 5 
                ? $"You made it, you are going to the competition with {wreathesMade} wreaths!" 
                : $"You didn't make it, you need {5 - wreathesMade} wreaths more!");
        }
    }
}

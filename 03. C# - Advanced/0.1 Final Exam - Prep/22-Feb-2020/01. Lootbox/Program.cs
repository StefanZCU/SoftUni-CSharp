using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray()); 
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int claimedItems = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                if ((firstBox.Peek() + secondBox.Peek()) % 2 == 0)
                {
                    claimedItems += (firstBox.Dequeue() + secondBox.Pop());
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            Console.WriteLine(firstBox.Any() ? "Second lootbox is empty" : "First lootbox is empty");

            Console.WriteLine(claimedItems >= 100
                ? $"Your loot was epic! Value: {claimedItems}"
                : $"Your loot was poor... Value: {claimedItems}");


        }
    }
}

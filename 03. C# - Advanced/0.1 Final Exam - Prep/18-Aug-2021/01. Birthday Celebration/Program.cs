using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int wastedFood = 0;

            while (guests.Any() && plates.Any())
            {
                if (plates.Peek() > guests.Peek())
                {
                    var foodToThrow = plates.Peek() - guests.Peek();
                    guests.Dequeue();
                    wastedFood += foodToThrow;
                }
                else if (plates.Peek() == guests.Peek())
                {
                    guests.Dequeue();
                }
                else
                {
                    var guestsList = guests.ToList();
                    guests.Clear();
                    guestsList[0] -= plates.Peek();

                    foreach (var guest in guestsList)
                    {
                        guests.Enqueue(guest);
                    }
                }

                plates.Pop();

            }

            Console.WriteLine(plates.Any()
                ? $"Plates: {string.Join(" ", plates)}"
                : $"Guests: {string.Join(" ", guests)}");

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}

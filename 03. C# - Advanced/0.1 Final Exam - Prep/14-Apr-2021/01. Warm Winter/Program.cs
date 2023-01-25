using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                if (hats.Peek() > scarfs.Peek())
                {
                    sets.Add(hats.Pop() + scarfs.Dequeue());
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    var newHat = hats.Pop() + 1;
                    hats.Push(newHat);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}

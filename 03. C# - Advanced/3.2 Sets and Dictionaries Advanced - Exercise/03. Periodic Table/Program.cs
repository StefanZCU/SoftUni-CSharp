using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < line.Length; j++)
                {
                    if (!elements.Contains(line[j]))
                    {
                        elements.Add(line[j]);
                    }
                }
            }

            elements = elements.OrderBy(x => x).ToHashSet();

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}

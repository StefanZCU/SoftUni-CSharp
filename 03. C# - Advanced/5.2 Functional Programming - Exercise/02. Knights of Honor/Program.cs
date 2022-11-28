using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> sir = s => Console.WriteLine($"Sir {s}");
            string[] names = Console.ReadLine().Split();

            foreach (var name in names)
            {
                sir(name);
            }
        }
    }
}

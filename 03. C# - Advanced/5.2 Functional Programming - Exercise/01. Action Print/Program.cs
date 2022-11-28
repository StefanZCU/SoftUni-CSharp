using System;
using System.Threading.Channels;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printer = s => Console.WriteLine(s);

            string[] collection = Console.ReadLine().Split();

            foreach (var s in collection)
            {
                printer(s);
            }
        }
    }
}

using System;

namespace _07._Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string one = Console.ReadLine();
            string two = Console.ReadLine();
            string three = Console.ReadLine();  

            Console.WriteLine($"{one}{three}{two}");
        }
    }
}

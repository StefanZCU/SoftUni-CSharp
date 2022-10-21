using System;

namespace _01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());
            int four = int.Parse(Console.ReadLine());

            two = two + one;
            three = two / three;
            four = four * three;

            Console.WriteLine(four);
        }
    }
}

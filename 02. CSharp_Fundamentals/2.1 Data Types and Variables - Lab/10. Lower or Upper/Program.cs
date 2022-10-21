using System;

namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter = char.Parse(Console.ReadLine());

            if (letter >= 65 && letter <= 90)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}

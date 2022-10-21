using System;

namespace _06._Number_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("No");
            }
            else if ((number >= -100) && (number <= 100))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}

using System;

namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string theater = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            if (theater == "Premiere")
            {
                int seats = row * column;
                double price = seats * 12.0;
                Console.WriteLine($"{price:F2}");
            }
            else if (theater == "Normal")
            {
                int seats = row * column;
                double price = seats * 7.5;
                Console.WriteLine($"{price:F2}");
            }
            else if (theater == "Discount")
            {
                int seats = row * column;
                double price = seats * 5.0;
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}

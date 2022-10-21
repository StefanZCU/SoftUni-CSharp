using System;

namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            TotalPrice(product, quantity);
        }

        static void TotalPrice(string product, double quantity)
        {
            double newNum;

            if (product == "coffee")
            {
                newNum = quantity * 1.5;
                Console.WriteLine($"{newNum:F2}");
            }
            else if (product == "water")
            {
                newNum = quantity * 1.0;
                Console.WriteLine($"{newNum:F2}");
            }
            else if (product == "coke")
            {
                newNum = quantity * 1.4;
                Console.WriteLine($"{newNum:F2}");
            }
            else if (product == "snacks")
            {
                newNum = quantity * 2.0;
                Console.WriteLine($"{newNum:F2}");
            }

            
        }
    }
}

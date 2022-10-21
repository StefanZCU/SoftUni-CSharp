using System;

namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOrders = int.Parse(Console.ReadLine());

            double totalPrice = 0.0;

            for (int i = 1; i <= numberOrders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int daysInMonth = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double priceOrder = ((daysInMonth * capsulesCount) * pricePerCapsule);
                totalPrice += priceOrder;

                Console.WriteLine($"The price for the coffee is: ${priceOrder:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}

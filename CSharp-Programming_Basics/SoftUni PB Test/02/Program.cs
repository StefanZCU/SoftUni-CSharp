using System;

namespace _02_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savedMoneyPerDay = double.Parse(Console.ReadLine()) * 5.0;
            double profitPriceSales = double.Parse(Console.ReadLine()) * 5.0;
            double moneySpent = double.Parse(Console.ReadLine());
            double pricePresent = double.Parse(Console.ReadLine());

            double savedMoney = (savedMoneyPerDay + profitPriceSales) - moneySpent;

            if (savedMoney >= pricePresent)
            {
                Console.WriteLine($"Profit: {savedMoney:F2} BGN, the gift has been purchased.");
            }
            else
            {
                pricePresent -= savedMoney;
                Console.WriteLine($"Insufficient money: {pricePresent:F2} BGN.");
            }

        }
    }
}

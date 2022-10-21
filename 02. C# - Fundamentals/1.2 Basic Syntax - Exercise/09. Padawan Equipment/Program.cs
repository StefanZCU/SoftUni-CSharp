using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numStudents = int.Parse(Console.ReadLine());
            double priceSaber = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double totalPriceSaber = priceSaber * Math.Ceiling(numStudents + (numStudents * 0.1));

            double totalPriceRobe = priceRobe * numStudents;

            double totalpriceBelt = priceBelt * numStudents;

            if (numStudents / 6 >= 1)
            {
                double divisibleBySix = Math.Floor(numStudents / 6.0);
                totalpriceBelt = totalpriceBelt - (priceBelt * divisibleBySix);

            }

            double finalPrice = totalpriceBelt + totalPriceRobe + totalPriceSaber;

            if (finalPrice <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {finalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {finalPrice - budget:F2}lv more.");
            }
        }
    }
}

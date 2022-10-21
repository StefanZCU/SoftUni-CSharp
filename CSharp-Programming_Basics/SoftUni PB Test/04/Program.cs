using System;

namespace _04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());

            double totalLitres = 0.0;
            double percentAlcoholCounter = 0.0;

            for (int i = 1; i <= numberOfDays; i++)
            {
                double quantityDay = double.Parse(Console.ReadLine());
                double percentAlcohol = double.Parse(Console.ReadLine());

                totalLitres += quantityDay;
                percentAlcoholCounter = percentAlcoholCounter + quantityDay * percentAlcohol;
            }

            double finalAlcoholPercent = percentAlcoholCounter / totalLitres;

            Console.WriteLine($"Liter: {totalLitres:F2}");
            Console.WriteLine($"Degrees: {finalAlcoholPercent:F2}");

            if (finalAlcoholPercent < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (finalAlcoholPercent >= 38 && finalAlcoholPercent <= 42) 
            {
                Console.WriteLine("Super!");
            }
            else if (finalAlcoholPercent > 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}

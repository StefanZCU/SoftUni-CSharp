using System;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceCPU = double.Parse(Console.ReadLine());
            double priceGPU = double.Parse(Console.ReadLine());
            double pricePerStickRAM = double.Parse(Console.ReadLine());
            int numberRAM = int.Parse(Console.ReadLine());
            double percentDiscount = double.Parse(Console.ReadLine());


            double priceRam = pricePerStickRAM * numberRAM;

            double newPriceCPU = priceCPU - priceCPU * percentDiscount;
            double newPriceGPU = priceGPU - priceGPU * percentDiscount;

            double totalPrice = newPriceGPU + newPriceCPU + priceRam;

            double finalPriceBGN = totalPrice * 1.57;


            Console.WriteLine($"Money needed - {finalPriceBGN:F2} leva.");
                    
        }
    }
}

using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int totalExtracted = 0;
            int days = 0;


            for (int i = startingYield; i >= 100; i -= 10)
            {
                totalExtracted += i;
                totalExtracted -= 26;
                days++;
            }

            if (totalExtracted <= 26)
            {
                totalExtracted = 0;
            }
            else
            {
                totalExtracted -= 26;
            }
            

            Console.WriteLine(days);
            Console.WriteLine(totalExtracted);
        }
    }
}

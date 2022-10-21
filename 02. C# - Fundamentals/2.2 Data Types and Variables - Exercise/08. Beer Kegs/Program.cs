using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double biggestKeg = double.MinValue;
            string biggestKegName = String.Empty;

            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > biggestKeg)
                {
                    biggestKeg = volume;
                    biggestKegName = name;
                }
            }

            Console.WriteLine(biggestKegName);
        }
    }
}

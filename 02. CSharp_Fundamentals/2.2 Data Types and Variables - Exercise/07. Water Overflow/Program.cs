using System;

namespace _07._Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int litres = int.Parse(Console.ReadLine());

                sum += litres;

                if (sum > 255)
                {
                    sum -= litres;
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(sum);
        }
    }
}

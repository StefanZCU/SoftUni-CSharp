using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plunderDays = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= plunderDays; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.5;
                }

                if (i % 5 == 0)
                {
                    totalPlunder = totalPlunder - (totalPlunder * 0.3);
                }
            }

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                double percentage = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}
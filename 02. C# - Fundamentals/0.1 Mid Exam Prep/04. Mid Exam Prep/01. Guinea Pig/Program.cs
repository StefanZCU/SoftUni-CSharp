using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuantity = double.Parse(Console.ReadLine()) * 1000.0;
            double hayQuantity = double.Parse(Console.ReadLine()) * 1000.0;
            double coverQuantity = double.Parse(Console.ReadLine()) * 1000.0;
            double puppyWeight = double.Parse(Console.ReadLine()) * 1000.0;

            bool flag = true;

            for (int i = 1; i <= 30; i++)
            {
                foodQuantity -= 300.0;

                if (foodQuantity <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    flag = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    hayQuantity -= foodQuantity * 0.05;

                    if (hayQuantity <= 0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        flag = false;
                        break;
                    }

                }
                if (i % 3 == 0)
                {
                    coverQuantity -= puppyWeight / 3.0;

                    if (coverQuantity <= 0)
                    {
                        Console.WriteLine("Merry must go to the pet store!");
                        flag = false;
                        break;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodQuantity / 1000:F2}, Hay: {hayQuantity / 1000:F2}, Cover: {coverQuantity / 1000:F2}.");
            }
        }
    }
}
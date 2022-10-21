using System;

namespace _12._Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            if ((sales >= 0) && (sales <= 500))
            {
                switch (city)
                {
                    case "Sofia":
                        double priceSofia = sales * 0.05;
                        Console.WriteLine($"{priceSofia:F2}");
                        break;
                    case "Varna":
                        double priceVarna = sales * 0.045;
                        Console.WriteLine($"{priceVarna:F2}");
                        break;
                    case "Plovdiv":
                        double pricePlovdiv = sales * 0.055;
                        Console.WriteLine($"{pricePlovdiv:F2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if ((sales > 500) && (sales <= 1000))
            {
                switch (city)
                {
                    case "Sofia":
                        double priceSofia = sales * 0.07;
                        Console.WriteLine($"{priceSofia:F2}");
                        break;
                    case "Varna":
                        double priceVarna = sales * 0.075;
                        Console.WriteLine($"{priceVarna:F2}");
                        break;
                    case "Plovdiv":
                        double pricePlovdiv = sales * 0.08;
                        Console.WriteLine($"{pricePlovdiv:F2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if ((sales > 1000) && (sales <= 10000))
            {
                switch (city)
                {
                    case "Sofia":
                        double priceSofia = sales * 0.08;
                        Console.WriteLine($"{priceSofia:F2}");
                        break;
                    case "Varna":
                        double priceVarna = sales * 0.1;
                        Console.WriteLine($"{priceVarna:F2}");
                        break;
                    case "Plovdiv":
                        double pricePlovdiv = sales * 0.12;
                        Console.WriteLine($"{pricePlovdiv:F2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (sales > 10000)
            {
                switch (city)
                {
                    case "Sofia":
                        double priceSofia = sales * 0.12;
                        Console.WriteLine($"{priceSofia:F2}");
                        break;
                    case "Varna":
                        double priceVarna = sales * 0.13;
                        Console.WriteLine($"{priceVarna:F2}");
                        break;
                    case "Plovdiv":
                        double pricePlovdiv = sales * 0.145;
                        Console.WriteLine($"{pricePlovdiv:F2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}

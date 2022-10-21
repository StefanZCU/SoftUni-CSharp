using System;

namespace _05._Small_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string item = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                switch (item)
                {
                    case "coffee":
                        double priceCoffee = quantity * 0.5;
                        Console.WriteLine(priceCoffee);
                        break;
                    case "water":
                        double priceWater = quantity * 0.8;
                        Console.WriteLine(priceWater);
                        break;
                    case "beer":
                        double priceBeer = quantity * 1.2;
                        Console.WriteLine(priceBeer);
                        break;
                    case "sweets":
                        double priceSweets = quantity * 1.45;
                        Console.WriteLine(priceSweets);
                        break;
                    case "peanuts":
                        double pricePeanuts = quantity * 1.6;
                        Console.WriteLine(pricePeanuts);
                        break;
                    default:
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (item)
                {
                    case "coffee":
                        double priceCoffee = quantity * 0.4;
                        Console.WriteLine(priceCoffee);
                        break;
                    case "water":
                        double priceWater = quantity * 0.7;
                        Console.WriteLine(priceWater);
                        break;
                    case "beer":
                        double priceBeer = quantity * 1.15;
                        Console.WriteLine(priceBeer);
                        break;
                    case "sweets":
                        double priceSweets = quantity * 1.3;
                        Console.WriteLine(priceSweets);
                        break;
                    case "peanuts":
                        double pricePeanuts = quantity * 1.5;
                        Console.WriteLine(pricePeanuts);
                        break;
                    default:
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (item)
                {
                    case "coffee":
                        double priceCoffee = quantity * 0.45;
                        Console.WriteLine(priceCoffee);
                        break;
                    case "water":
                        double priceWater = quantity * 0.7;
                        Console.WriteLine(priceWater);
                        break;
                    case "beer":
                        double priceBeer = quantity * 1.1;
                        Console.WriteLine(priceBeer);
                        break;
                    case "sweets":
                        double priceSweets = quantity * 1.35;
                        Console.WriteLine(priceSweets);
                        break;
                    case "peanuts":
                        double pricePeanuts = quantity * 1.55;
                        Console.WriteLine(pricePeanuts);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

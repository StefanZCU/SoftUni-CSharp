using System;

namespace _03._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            switch (typeOfFlower)
            {
                case "Roses":
                    double priceRoses = numberOfFlowers * 5.0;

                    if (numberOfFlowers > 80)
                    {
                        double newPrice = priceRoses - (priceRoses * 0.1);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money, you need {newPrice:F2} leva more.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    else
                    {
                        if (priceRoses > budget)
                        {
                            priceRoses -= budget;
                            Console.WriteLine($"Not enough money, you need {priceRoses:F2} leva more.");
                        }
                        else
                        {
                            budget -= priceRoses;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    break;

                case "Dahlias":
                    double priceDahlias = numberOfFlowers * 3.8;

                    if (numberOfFlowers > 90)
                    {
                        double newPrice = priceDahlias - (priceDahlias * 0.15);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money, you need {newPrice:F2} leva more.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    else
                    {
                        if (priceDahlias > budget)
                        {
                            priceDahlias -= budget;
                            Console.WriteLine($"Not enough money, you need {priceDahlias:F2} leva more.");
                        }
                        else
                        {
                            budget -= priceDahlias;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    break;

                case "Tulips":
                    double priceTulips = numberOfFlowers * 2.8;

                    if (numberOfFlowers > 80)
                    {
                        double newPrice = priceTulips - (priceTulips * 0.15);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money, you need {newPrice:F2} leva more.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    else
                    {
                        if (priceTulips > budget)
                        {
                            priceTulips -= budget;
                            Console.WriteLine($"Not enough money, you need {priceTulips:F2} leva more.");
                        }
                        else
                        {
                            budget -= priceTulips;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    break;

                case "Narcissus":
                    double priceNarcissus = numberOfFlowers * 3.0;

                    if (numberOfFlowers < 120)
                    {
                        double newPrice = priceNarcissus + (priceNarcissus * 0.15);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money, you need {newPrice:F2} leva more.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    else
                    {
                        if (priceNarcissus > budget)
                        {
                            priceNarcissus -= budget;
                            Console.WriteLine($"Not enough money, you need {priceNarcissus:F2} leva more.");
                        }
                        else
                        {
                            budget -= priceNarcissus;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    break;

                case "Gladiolus":
                    double priceGladiolus = numberOfFlowers * 2.5;

                    if (numberOfFlowers < 80)
                    {
                        double newPrice = priceGladiolus + (priceGladiolus * 0.2);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money, you need {newPrice:F2} leva more.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    else
                    {
                        if (priceGladiolus > budget)
                        {
                            priceGladiolus -= budget;
                            Console.WriteLine($"Not enough money, you need {priceGladiolus:F2} leva more.");
                        }
                        else
                        {
                            budget -= priceGladiolus;
                            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {budget:F2} leva left.");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

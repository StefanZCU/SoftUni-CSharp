using System;

namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double pricePerPerson = 0.0;
            double totalPrice = 0.0;

            if (numberOfPeople <= 5)
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 50.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        break;

                    case "summer":
                        pricePerPerson = 48.50;
                        totalPrice = pricePerPerson * numberOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                        break;

                    case "autumn":
                        pricePerPerson = 60.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        break;

                    case "winter":
                        pricePerPerson = 86.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        totalPrice = totalPrice + totalPrice * 0.08;
                        break;

                    default:
                        break;
                }
            }


            else if (numberOfPeople > 5)
            {
                switch (season)
                {
                    case "spring":
                        pricePerPerson = 48.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        break;

                    case "summer":
                        pricePerPerson = 45.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.15);
                        break;

                    case "autumn":
                        pricePerPerson = 49.50;
                        totalPrice = pricePerPerson * numberOfPeople;
                        break;

                    case "winter":
                        pricePerPerson = 85.0;
                        totalPrice = pricePerPerson * numberOfPeople;
                        totalPrice = totalPrice + totalPrice * 0.08;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"{totalPrice:F2} leva.");
        }
    }
}

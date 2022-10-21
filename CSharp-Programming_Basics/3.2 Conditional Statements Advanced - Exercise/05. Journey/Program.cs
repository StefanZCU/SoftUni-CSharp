using System;

namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string stayingPlace;

            switch (season)
            {
                case "summer":
                    if (budget <= 100.0)
                    {
                        double totalPrice = budget * 0.3;
                        stayingPlace = "Camp";
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    else if ((budget > 100) && (budget <= 1000))
                    {
                        double totalPrice = budget * 0.4;
                        stayingPlace = "Camp";
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    else if (budget > 1000)
                    {
                        double totalPrice = budget * 0.9;
                        stayingPlace = "Hotel";
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    break;
                case "winter":
                    if (budget <= 100.0)
                    {
                        double totalPrice = budget * 0.7;
                        stayingPlace = "Hotel";
                        Console.WriteLine("Somewhere in Bulgaria");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    else if ((budget > 100.0) && (budget <= 1000.0))
                    {
                        double totalPrice = budget * 0.8;
                        stayingPlace = "Hotel";
                        Console.WriteLine("Somewhere in Balkans");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    else if (budget > 1000.0)
                    {
                        double totalPrice = budget * 0.9;
                        stayingPlace = "Hotel";
                        Console.WriteLine("Somewhere in Europe");
                        Console.WriteLine($"{stayingPlace} - {totalPrice:F2}");
                    }
                    break;

                default:
                    break;
            }
        }
    }
}

using System;

namespace _09._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            string typeOfPlace = Console.ReadLine();
            string rating = Console.ReadLine();

            double numberOfNights = numberOfDays - 1;
            double price = 0;

            switch (typeOfPlace)
            {
                case "room for one person":

                    price = numberOfNights * 18.0;
                    if (rating == "positive")
                    {
                        price = price + (price * 0.25);
                        Console.WriteLine($"{price:F2}");
                    }
                    else if (rating == "negative")
                    {
                        price = price - (price * 0.1);
                        Console.WriteLine($"{price:F2}");
                    }

                    break;

                case "apartment":

                    price = numberOfNights * 25.0;

                    if (numberOfNights < 10)
                    {
                        double newPrice = price - (price * 0.3);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }
                    else if ((numberOfNights >= 10) && (numberOfNights <= 15))
                    {
                        double newPrice = price - (price * 0.35);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }
                    else
                    {
                        double newPrice = price - (price * 0.5);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }

                    break;

                case "president apartment":

                    price = numberOfNights * 35.0;

                    if (numberOfNights < 10)
                    {
                        double newPrice = price - (price * 0.1);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }
                    else if ((numberOfNights >= 10) && (numberOfNights <= 15))
                    {
                        double newPrice = price - (price * 0.15);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }
                    else
                    {
                        double newPrice = price - (price * 0.2);
                        if (rating == "positive")
                        {
                            newPrice = newPrice + (newPrice * 0.25);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                        else if (rating == "negative")
                        {
                            newPrice = newPrice - (newPrice * 0.1);
                            Console.WriteLine($"{newPrice:F2}");
                        }
                    }

                    break;
                default:
                    break;
            }
        }
    }
}

using System;

namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishers = int.Parse(Console.ReadLine());

            switch (season)
            {
                case "Summer":
                    int priceBoatSummer = 4200;
                    if (numberOfFishers <= 6)
                    {
                        double newPrice = priceBoatSummer - (priceBoatSummer * 0.1);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if ((numberOfFishers >= 7) && (numberOfFishers <= 11))
                    {
                        double newPrice = priceBoatSummer - (priceBoatSummer * 0.15);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if (numberOfFishers >= 12)
                    {
                        double newPrice = priceBoatSummer - (priceBoatSummer * 0.25);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    break;

                case "Spring":
                    int priceBoatSpring = 3000;
                    if (numberOfFishers <= 6)
                    {
                        double newPrice = priceBoatSpring - (priceBoatSpring * 0.1);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if ((numberOfFishers >= 7) && (numberOfFishers <= 11))
                    {
                        double newPrice = priceBoatSpring - (priceBoatSpring * 0.15);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if (numberOfFishers >= 12)
                    {
                        double newPrice = priceBoatSpring - (priceBoatSpring * 0.25);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    break;

                case "Winter":
                    int priceBoatWinter = 2600;
                    if (numberOfFishers <= 6)
                    {
                        double newPrice = priceBoatWinter - (priceBoatWinter * 0.1);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if ((numberOfFishers >= 7) && (numberOfFishers <= 11))
                    {
                        double newPrice = priceBoatWinter - (priceBoatWinter * 0.15);
                        if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    else if (numberOfFishers >= 12)
                    {
                        double newPrice = priceBoatWinter - (priceBoatWinter * 0.25); if ((numberOfFishers % 2) == 0)
                        {
                            double extraDiscount = newPrice - (newPrice * 0.05);
                            if (extraDiscount > budget)
                            {
                                extraDiscount -= budget;
                                Console.WriteLine($"Not enough money! You need {extraDiscount:F2} leva.");
                            }
                            else
                            {
                                budget -= extraDiscount;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                        else
                        {
                            if (newPrice > budget)
                            {
                                newPrice -= budget;
                                Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                            }
                            else
                            {
                                budget -= newPrice;
                                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                            }
                        }
                    }
                    break;

                case "Autumn":
                    int priceBoatAutumn = 4200;
                    if (numberOfFishers <= 6)
                    {
                        double newPrice = priceBoatAutumn - (priceBoatAutumn * 0.1);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                        }

                    }
                    else if ((numberOfFishers >= 7) && (numberOfFishers <= 11))
                    {
                        double newPrice = priceBoatAutumn - (priceBoatAutumn * 0.15);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                        }

                    }
                    else if (numberOfFishers >= 12)
                    {
                        double newPrice = priceBoatAutumn - (priceBoatAutumn * 0.25);

                        if (newPrice > budget)
                        {
                            newPrice -= budget;
                            Console.WriteLine($"Not enough money! You need {newPrice:F2} leva.");
                        }
                        else
                        {
                            budget -= newPrice;
                            Console.WriteLine($"Yes! You have {budget:F2} leva left.");
                        }

                    }
                    break;

                default:
                    break;
            }
        }
    }
}

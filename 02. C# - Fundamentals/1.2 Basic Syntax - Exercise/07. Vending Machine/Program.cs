using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalCoins = 0.0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Start")
                {
                    while (true)
                    {
                        string item = Console.ReadLine();

                        if (item == "End")
                        {
                            Console.WriteLine($"Change: {totalCoins:F2}");
                            return;
                        }


                        if (item == "Nuts")
                        {
                            if (totalCoins - 2.0 < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            else
                            {
                                totalCoins -= 2;
                                Console.WriteLine("Purchased nuts");
                            }
                        }
                        else if (item == "Water")
                        { 
                            if (totalCoins - 0.7 < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            else
                            {
                                totalCoins -= 0.7;
                                Console.WriteLine("Purchased water");
                            }
                        }
                        else if (item == "Crisps")
                        {
                            if (totalCoins - 1.5 < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            else
                            {
                                totalCoins -= 1.5;
                                Console.WriteLine("Purchased crisps");
                            }
                        }
                        else if (item == "Soda")
                        {
                            if (totalCoins - 0.8 < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            else
                            {
                                totalCoins -= 0.8;
                                Console.WriteLine("Purchased soda");
                            }
                        }
                        else if (item == "Coke")
                        {
                            if (totalCoins - 1.0 < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            else
                            {
                                totalCoins -= 1.0;
                                Console.WriteLine("Purchased coke");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid product");
                        }
                    }
                }

                double coin = double.Parse(command);

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    totalCoins += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
            }
        }
    }
}

using System;
using System.Security.Cryptography;

namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());


            double moneySpent = 0.0;

            while (true)
            {
                string game = Console.ReadLine();


                if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${moneySpent:F2}. Remaining: ${budget:F2}");
                    break;
                }
                else if (game == "OutFall 4")
                {
                    if (budget < 39.99)
                    {
                        Console.WriteLine("Too Expensive");

                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        budget -= 39.99;
                        moneySpent += 39.99;
                    }
                }
                else if (game == "CS: OG")
                {
                    if (budget < 15.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        moneySpent += 15.99;
                        budget -= 15.99;
                    }
                }
                else if (game == "Zplinter Zell")
                {
                    if (budget < 19.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        moneySpent += 19.99;
                        budget -= 19.99;
                    }
                }
                else if (game == "Honored 2")
                {
                    if (budget < 59.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        moneySpent += 59.99;
                        budget -= 59.99;
                    }
                }
                else if (game == "RoverWatch")
                {
                    if (budget < 29.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        moneySpent += 29.99;
                        budget -= 29.99;
                    }
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    if (budget < 39.99)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                        moneySpent += 39.99;
                        budget -= 39.99;
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (budget == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
            }
        }
    }
}

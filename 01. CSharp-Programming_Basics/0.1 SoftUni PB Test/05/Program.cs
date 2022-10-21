using System;

namespace _05_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSeaExcursions = int.Parse(Console.ReadLine());
            int numberOfMountainExcursions = int.Parse(Console.ReadLine());

            int totalPrice = 0;
            int seaCounter = numberOfSeaExcursions;
            int mountainCounter = numberOfMountainExcursions;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    Console.WriteLine($"Profit: {totalPrice} leva.");
                    break;
                }

                if (command == "sea")
                {
                    seaCounter--;

                    if (seaCounter < 0)
                    {
                        seaCounter = 0;
                    }
                    else
                    {
                        totalPrice += 680;
                    }
                    
                }
                else if (command == "mountain")
                {
                    mountainCounter--;

                    if (mountainCounter < 0)
                    {
                        mountainCounter = 0;
                    }
                    else
                    {
                        totalPrice += 499;
                    }
                }

                if (mountainCounter == 0 && seaCounter == 0)
                {
                    Console.WriteLine("Good job! Everything is sold.");
                    Console.WriteLine($"Profit: {totalPrice} leva.");
                    break;
                }
            }
        }
    }
}

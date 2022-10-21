using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string command;
            int currentPosition = 0;
            int positionAfterJump;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] input = command.Split();
                int currentJump = int.Parse(input[1]);

                positionAfterJump = currentJump + currentPosition;
                if (positionAfterJump >= houses.Count)
                {
                    positionAfterJump = 0;
                    currentPosition = 0;
                }
                else
                {
                    currentPosition = positionAfterJump;
                }

                if (houses[positionAfterJump] == 0)
                {
                    Console.WriteLine($"Place {positionAfterJump} already had Valentine's day.");
                    continue;
                }
                else if (houses[positionAfterJump] != 0)
                {
                    houses[positionAfterJump] -= 2;

                    if (houses[positionAfterJump] == 0)
                    {
                        Console.WriteLine($"Place {positionAfterJump} has Valentine's day.");
                    }
                }
            }

            int counter = 0;
            foreach (int item in houses)
            {
                if (item == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");

            if (counter == houses.Count)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Count - counter} places.");
            }

        }
    }
}
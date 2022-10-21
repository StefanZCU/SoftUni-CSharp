using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int wonBattles = 0;

            string command;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(command);

                if (wonBattles % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }

                if (initialEnergy - distance >= 0)
                {
                    initialEnergy -= distance;
                    wonBattles++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
                    break;
                }
            }

            if (command == "End of battle")
            {
                if (wonBattles % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }

                Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
            }
        }
    }
}
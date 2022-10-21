using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dungeonRoom = Console.ReadLine().Split("|").ToList();

            int health = 100;
            int bitcoins = 0;
            int healed = 0;
            bool flag = true;

            int originalCount = dungeonRoom.Count;

            for (int i = 0; i < originalCount; i++)
            {
                string[] input = dungeonRoom[0].Split();

                if (input[0] == "potion")
                {
                    (health, healed) = GetHealth(health, int.Parse(input[1]));

                    Console.WriteLine($"You healed for {healed} hp.");
                    Console.WriteLine($"Current health: {health} hp.");

                    dungeonRoom.RemoveAt(0);
                }
                else if (input[0] == "chest")
                {
                    bitcoins += int.Parse(input[1]);
                    Console.WriteLine($"You found {int.Parse(input[1])} bitcoins.");
                    dungeonRoom.RemoveAt(0);
                }
                else
                {
                    health -= int.Parse(input[1]);

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {input[0]}.");
                        dungeonRoom.RemoveAt(0);
                    }
                    else
                    {
                        flag = false;
                        dungeonRoom.RemoveAt(0);
                        Console.WriteLine($"You died! Killed by {input[0]}.");
                        Console.WriteLine($"Best room: {originalCount - dungeonRoom.Count}");
                        break;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }

        static (int, int) GetHealth(int currentHealth, int potion)
        {
            int healthBeforeHealing = currentHealth;
            currentHealth += potion;

            if (currentHealth > 100)
            {
                currentHealth = 100;
            }

            if (healthBeforeHealing + potion > 100)
            {
                potion = 100 - healthBeforeHealing;
            }


            return (currentHealth, potion);
        }
    }
}
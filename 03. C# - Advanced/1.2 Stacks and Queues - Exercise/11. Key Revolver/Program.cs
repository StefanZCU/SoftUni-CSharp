using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelValue = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);

            int totalBulletsBought = 0;

            for (int i = 1; i <= bulletsArray.Length; i++)
            {
                if (bullets.Count != 0 && locks.Count != 0)
                {
                    if (bullets.Peek() <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        totalBulletsBought += bulletPrice;
                        bullets.Pop();
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        totalBulletsBought += bulletPrice;
                        bullets.Pop();
                    }
                }

                if (i % gunBarrelSize == 0 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelValue -= totalBulletsBought}");
                    break;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

            }

        }
    }
}

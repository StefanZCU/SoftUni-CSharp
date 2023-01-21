using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Xml;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numWaves = int.Parse(Console.ReadLine());

            int[] initialPlates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> orcAttacks = new Stack<int>();
            Queue<int> plates = new Queue<int>(initialPlates);

            for (int i = 1; i <= numWaves; i++)
            {
                int[] orcWaves = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                foreach (var wave in orcWaves)
                {
                    orcAttacks.Push(wave);
                }

                while (orcAttacks.Count != 0 && plates.Count != 0)
                {
                    if (orcAttacks.Peek() - plates.Peek() < 0)
                    {
                        List<int> platesList = plates.ToList();
                        plates.Clear();
                        platesList[0] -= orcAttacks.Peek();

                        foreach (var plate in platesList)
                        {
                            plates.Enqueue(plate);
                        }

                        orcAttacks.Pop();
                    }
                    else if (orcAttacks.Peek() - plates.Peek() > 0)
                    {
                        List<int> orcList = orcAttacks.Reverse().ToList();
                        orcAttacks.Clear();
                        orcList[^1] -= plates.Peek();

                        foreach (var orc in orcList)
                        {
                            orcAttacks.Push(orc);
                        }



                        plates.Dequeue();
                    }
                    else if (orcAttacks.Peek() - plates.Peek() == 0)
                    {
                        orcAttacks.Pop();
                        plates.Dequeue();
                    }
                }

                if (plates.Count != 0 && i == numWaves)
                {
                    Console.WriteLine("The people successfully repulsed the orc's attack.");
                    Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                    return;
                }
                
                if (plates.Count == 0)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                    if (orcAttacks.Count != 0)
                    {
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcAttacks)}");
                    }

                    return;
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            if (plates.Count != 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}

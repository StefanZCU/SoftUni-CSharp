using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine().Split("|").ToList();
            List<string> stolenItems = new List<string>();

            string command;
            bool flag = true;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] input = command.Split();

                if (input[0] == "Loot")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (!Checker(treasureChest, input[i]))
                        {
                            treasureChest.Insert(0, input[i]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (input[0] == "Drop")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < treasureChest.Count)
                    {
                        string tempItem = treasureChest[int.Parse(input[1])];
                        treasureChest.RemoveAt(int.Parse(input[1]));
                        treasureChest.Add(tempItem);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Steal")
                {
                    if (int.Parse(input[1]) >= treasureChest.Count)
                    {
                        input[1] = $"{treasureChest.Count}";
                    }

                    int originalCount = treasureChest.Count;

                    for (int i = treasureChest.Count - 1; i >= originalCount - int.Parse(input[1]); i--)
                    {
                        string tempItem = treasureChest[i];
                        treasureChest.RemoveAt(i);
                        stolenItems.Insert(0, tempItem);
                    }
                    Console.WriteLine(String.Join(", ", stolenItems));
                    stolenItems.Clear();

                    if (treasureChest.Count == 0)
                    {
                        Console.WriteLine("Failed treasure hunt.");
                        flag = false;
                        break;
                    }
                }

            }

            double length = 0.0;
            for (int i = 0; i < treasureChest.Count; i++)
            {
                length += treasureChest[i].Length;
            }

            double average = length / treasureChest.Count;

            if (flag)
            {
                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
        }

        static bool Checker(List<string> treasureChest, string input)
        {
            if (treasureChest.Contains(input))
            {
                return true;
            }

            return false;
        }
    }
}
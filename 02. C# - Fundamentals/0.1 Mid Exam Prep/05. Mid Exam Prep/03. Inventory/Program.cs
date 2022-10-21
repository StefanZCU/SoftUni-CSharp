using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> itemsCollected = Console.ReadLine().Split(", ").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] input = command.Split(" - ");

                if (input[0] == "Collect")
                {
                    if (!FindItem(itemsCollected, input[1]))
                    {
                        itemsCollected.Add(input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Drop")
                {
                    if (FindItem(itemsCollected, input[1]))
                    {
                        itemsCollected.Remove(input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Combine Items")
                {
                    string[] combinedItems = input[1].Split(":");

                    if (FindItem(itemsCollected, combinedItems[0]))
                    {
                        for (int i = 0; i < itemsCollected.Count; i++)
                        {
                            if (itemsCollected[i] == combinedItems[0])
                            {
                                itemsCollected.Insert(i + 1, combinedItems[1]);
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Renew")
                {
                    if (FindItem(itemsCollected, input[1]))
                    {
                        string tempItem = input[1];
                        itemsCollected.Remove(input[1]);
                        itemsCollected.Add(tempItem);
                    }
                }
            }

            Console.WriteLine(String.Join(", ", itemsCollected));
        }

        static bool FindItem(List<string> itemsCollected, string item) // if true, found item
        {
            if (itemsCollected.Contains(item))
            {
                return true;
            }

            return false;
        }
    }
}
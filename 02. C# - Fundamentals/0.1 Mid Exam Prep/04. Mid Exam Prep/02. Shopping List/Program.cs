using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] input = command.Split();

                if (input[0] == "Urgent")
                {
                    if (!FindItem(shoppingList, input[1]))
                    {
                        shoppingList.Insert(0, input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Unnecessary")
                {
                    if (FindItem(shoppingList, input[1]))
                    {
                        shoppingList.Remove(input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Correct")
                {
                    if (FindItem(shoppingList, input[1]))
                    {
                        shoppingList = CorrectList(shoppingList, input[1], input[2]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Rearrange")
                {
                    if (FindItem(shoppingList, input[1]))
                    {
                        shoppingList = RearrangeList(shoppingList, input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", shoppingList));
        }

        static bool FindItem(List<string> shoppingList, string item) // if true, found item
        {
            if (shoppingList.Contains(item))
            {
                return true;
            }

            return false;
        }

        static List<string> CorrectList(List<string> shoppingList, string oldItem, string newItem)
        {

            for (int i = 0; i < shoppingList.Count; i++)
            {
                if (shoppingList[i] == oldItem)
                {
                    shoppingList[i] = newItem;
                }
            }

            return shoppingList;
        }

        static List<string> RearrangeList(List<string> shoppingList, string item)
        {
            for (int i = 0; i < shoppingList.Count; i++)
            {
                if (shoppingList[i] == item)
                {
                    shoppingList.RemoveAt(i);
                    shoppingList.Add(item);
                }
            }

            return shoppingList;
        }
    }
}
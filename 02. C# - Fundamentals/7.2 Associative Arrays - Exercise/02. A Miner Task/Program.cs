using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> quantityByResource = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!quantityByResource.ContainsKey(command))
                {
                    quantityByResource.Add(command, quantity);
                }
                else
                {
                    quantityByResource[command] += quantity;
                }
            }

            foreach (var resource in quantityByResource)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}

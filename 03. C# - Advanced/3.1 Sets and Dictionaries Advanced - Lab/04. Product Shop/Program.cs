using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopItems = new Dictionary<string, Dictionary<string, double>>();

            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string store = input[0];
                string item = input[1];
                double price = double.Parse(input[2]);

                if (!shopItems.ContainsKey(store))
                {
                    shopItems.Add(store, new Dictionary<string, double>());
                }

                shopItems[store].Add(item, price);
            }

            foreach (var store in shopItems.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{store.Key}->");

                foreach (var items in store.Value)
                {
                    Console.WriteLine($"Product: {items.Key}, Price: {items.Value}");
                }
            }
        }
    }
}

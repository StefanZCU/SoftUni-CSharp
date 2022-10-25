using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                int serialNum = int.Parse(input[0]);
                string name = input[1];
                int itemQuantity = int.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);

                Item item = new Item(name, itemPrice);
                Box box = new Box(serialNum, item, itemQuantity, (itemPrice * itemQuantity));

                boxes.Add(box);
            }

            boxes = boxes.OrderByDescending(x => x.PriceBox).ToList();

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity, double priceBox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceBox = priceBox;
        }

        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceBox { get; set; }

        public override string ToString()
        {
            return ($"{this.SerialNumber}\n-- {this.Item.Name} - ${this.Item.Price:F2}: {this.ItemQuantity}\n-- ${this.PriceBox:F2}");
        }
    }
}
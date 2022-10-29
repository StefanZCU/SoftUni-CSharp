using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Orders
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();

            Dictionary<string, double> pricePerItem = new Dictionary<string, double>();

            bool flag = false;

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (productsList.Count == 0)
                {
                    Product currentProduct = new Product(name, price, quantity);
                    productsList.Add(currentProduct);
                    pricePerItem.Add(currentProduct.Name, 0.0);
                    continue;
                }

                foreach (var product in productsList)
                {
                    if (product.Name == name)
                    {
                        product.Price = price;
                        product.Quantity += quantity;
                        break;
                    }

                    if (!productsList.Any(s => s.Name == name))
                    {
                        Product currentProduct = new Product(name, price, quantity);
                        productsList.Add(currentProduct);
                        pricePerItem.Add(currentProduct.Name, 0.0);
                        break;
                    }
                }
            }

            foreach (var product in productsList)
            {
                foreach (var item in pricePerItem)
                {
                    if (item.Key == product.Name)
                    {
                        pricePerItem[item.Key] = product.Quantity * product.Price;
                        break;
                    }
                }
            }

            foreach (var item in pricePerItem)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }
        }
    }
}

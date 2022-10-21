using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numProducts = int.Parse(Console.ReadLine());

            List<string> listProducts = new List<string>();

            for (int i = 0; i < numProducts; i++)
            {
                string product = Console.ReadLine();

                listProducts.Add(product);
            }

            listProducts.Sort();

            for (int j = 1; j <= numProducts; j++)
            {
                Console.WriteLine($"{j}.{listProducts[j - 1]}");
            }
        }
    }
}

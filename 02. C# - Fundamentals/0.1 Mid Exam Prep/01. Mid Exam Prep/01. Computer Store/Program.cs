using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double priceWithoutTaxes = 0;
            double priceTaxes = 0;
            double totalPrice = 0;
            string command;
            while (true)
            {
                command = Console.ReadLine();

                if (command == "regular")
                {
                    priceTaxes = (priceWithoutTaxes * 0.2);
                    totalPrice = priceWithoutTaxes + priceTaxes;
                    break;
                }
                else if (command == "special")
                {
                    priceTaxes = (priceWithoutTaxes * 0.2);
                    totalPrice = (priceWithoutTaxes + priceTaxes) - ((priceWithoutTaxes + priceTaxes) * 0.1);
                    break;
                }
                else
                {
                    double price = double.Parse(command);

                    if (price < 0)
                    {
                        Console.WriteLine("Invalid price!");
                    }
                    else
                    {
                        priceWithoutTaxes += price;
                    }
                }
            }

            if (totalPrice <= 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else if (command == "regular")
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {priceTaxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:F2}$");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
                Console.WriteLine($"Taxes: {priceTaxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:F2}$");
            }
        }
    }
}
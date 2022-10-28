using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Person
    {
        public Person(string name, int money)
        {
            this.PersonName = name;
            this.PersonMoney = money;
        }
        public string PersonName { get; set; }
        public int PersonMoney { get; set; }
        public List<string> BoughtProductsList { get; set; } = new List<string>();

        public void TryBuyProduct(Person currentPerson, Product currentProduct)
        {
            if (currentPerson.PersonMoney - currentProduct.ProductPrice >= 0)
            {
                currentPerson.PersonMoney -= currentProduct.ProductPrice;
                currentPerson.BoughtProductsList.Add(currentProduct.ProductName);
                Console.WriteLine($"{currentPerson.PersonName} bought {currentProduct.ProductName}");
            }
            else
            {
                Console.WriteLine($"{currentPerson.PersonName} can't afford {currentProduct.ProductName}");
            }
        }
    }

    class Product
    {
        public Product(string productName, int productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(";");
            string[] products = Console.ReadLine().Split(";");

            List<Person> peopleList = new List<Person>();

            List<Product> productList = new List<Product>();

            for (int i = 0; i < people.Length; i++)
            {
                string[] person = people[i].Split("=");

                string name = person[0];
                int money = int.Parse(person[1]);

                Person currentPerson = new Person(name, money);

                peopleList.Add(currentPerson);
            }

            for (int j = 0; j < products.Length; j++)
            {
                string[] product = products[j].Split("=");

                string productName = product[0];
                int productPrice = int.Parse(product[1]);

                Product currentProduct = new Product(productName, productPrice);

                productList.Add(currentProduct);

            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();
                string name = input[0];
                string currentProduct = input[1];

                foreach (var person in peopleList)
                {
                    if (person.PersonName == name)
                    {
                        foreach (var product in productList)
                        {
                            if (product.ProductName == currentProduct)
                            {
                                person.TryBuyProduct(person, product);
                            }
                        }
                    }
                }
            }

            foreach (var person in peopleList)
            {
                if (person.BoughtProductsList.Count == 0)
                {
                    Console.WriteLine($"{person.PersonName} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.PersonName} - {string.Join(", ", person.BoughtProductsList)}");
                }
            }
        }
    }
}

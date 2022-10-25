using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

    }

    class Catalog
    {
        public List<Car> CarCatalog { get; set; } = new List<Car>();
        public List<Truck> TruckCatalog { get; set; } = new List<Truck>();

        public string Car(int i)
        {
            return $"{this.CarCatalog[i].Brand}: {this.CarCatalog[i].Model} - {this.CarCatalog[i].HorsePower}hp";
        }
        public string Truck(int i)
        {
            return $"{this.TruckCatalog[i].Brand}: {this.TruckCatalog[i].Model} - {this.TruckCatalog[i].Weight}kg";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Catalog catalog = new Catalog();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split("/");

                string type = input[0];
                string brand = input[1];
                string model = input[2];
                int horseWeight = int.Parse(input[3]);



                if (type == "Car")
                {
                    Car currentCar = new Car(brand, model, horseWeight);
                    catalog.CarCatalog.Add(currentCar);
                }
                else
                {
                    Truck currentTruck = new Truck(brand, model, horseWeight);
                    catalog.TruckCatalog.Add(currentTruck);
                }
            }

            catalog.CarCatalog = catalog.CarCatalog.OrderBy(x => x.Brand).ToList();
            catalog.TruckCatalog = catalog.TruckCatalog.OrderBy(x => x.Brand).ToList();

            int counter = 0;

            if (catalog.CarCatalog.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in catalog.CarCatalog)
                {
                    Console.WriteLine(catalog.Car(counter));
                    counter++;
                }
            }

            counter = 0;

            if (catalog.TruckCatalog.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in catalog.TruckCatalog)
                {
                    Console.WriteLine(catalog.Truck(counter));
                    counter++;
                }
            }


        }
    }
}
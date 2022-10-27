using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program
{
    class Car
    {
        public Car(string vehicleType, string model, string color, int horsePower)
        {
            this.VehicleType = vehicleType;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string VehicleType { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var truckList = new List<Car>();
            var carList = new List<Car>();

            int carSum = 0, truckSum = 0;
            
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();

                string typeOfVehicle = input[0];
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);
                
                if (typeOfVehicle == "car")
                {
                    carSum += horsePower;
                    Car car = new Car("Car", model, color, horsePower);
                    carList.Add(car);
                }
                else
                {
                    truckSum += horsePower;
                    Car truck = new Car("Truck", model, color, horsePower);
                    truckList.Add(truck);
                }
            }

            string catalogue;
            while ((catalogue = Console.ReadLine()) != "Close the Catalogue")
            {
                var findModelCar = carList.FirstOrDefault(x => x.Model == catalogue);
                var findModelTruck = truckList.FirstOrDefault(x => x.Model == catalogue);

                if (findModelCar != null)
                {
                    Console.WriteLine($"Type: {findModelCar.VehicleType}");
                    Console.WriteLine($"Model: {findModelCar.Model}");
                    Console.WriteLine($"Color: {findModelCar.Color}");
                    Console.WriteLine($"Horsepower: {findModelCar.HorsePower}");
                }
                else if (findModelTruck != null)
                {
                    Console.WriteLine($"Type: {findModelTruck.VehicleType}");
                    Console.WriteLine($"Model: {findModelTruck.Model}");
                    Console.WriteLine($"Color: {findModelTruck.Color}");
                    Console.WriteLine($"Horsepower: {findModelTruck.HorsePower}");
                }
            }

            if (truckList.Count == 0 && carList.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
            else if (carList.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
                Console.WriteLine($"Trucks have average horsepower of: {(double)truckSum / truckList.Count:F2}.");
            }
            else if (truckList.Count == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(double)carSum / carList.Count:F2}.");
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {(double)carSum / carList.Count:F2}.");
                Console.WriteLine($"Trucks have average horsepower of: {(double)truckSum / truckList.Count:F2}.");
            }
        }
    }
}
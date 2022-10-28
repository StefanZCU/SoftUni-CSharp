using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _03._Speed_Racing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionForKm, double traveledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionForKm = fuelConsumptionForKm;
            this.TraveledDistance = traveledDistance;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionForKm { get; set; }
        public double TraveledDistance { get; set; }

        public void CheckTravel(Car currentCar, int amountOfKm)
        {
            double fuelNeeded = currentCar.FuelConsumptionForKm * amountOfKm;

            if (currentCar.FuelAmount >= fuelNeeded)
            {
                currentCar.FuelAmount -= fuelNeeded;
                currentCar.TraveledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCars = int.Parse(Console.ReadLine());

            List<Car> AllCars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionForKm = double.Parse(input[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumptionForKm, 0.0);
                AllCars.Add(currentCar);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                string model = cmdArgs[1];
                int amountOfKm = int.Parse(cmdArgs[2]);

                foreach (var car in AllCars)
                {
                    if (car.Model == model)
                    {
                        car.CheckTravel(car, amountOfKm);
                    }
                }
            }

            foreach (var car in AllCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}

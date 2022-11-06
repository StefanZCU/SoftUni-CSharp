using System;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    public class MileageFuel
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public MileageFuel(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MileageFuel> carMileageFuel = new Dictionary<string, MileageFuel>();
            List<string> carsToDelete = new List<string>();

            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                string[] newCar = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string carName = newCar[0];
                int mileage = int.Parse(newCar[1]);
                int fuel = int.Parse(newCar[2]);

                MileageFuel mileageFuel = new MileageFuel(mileage, fuel);

                carMileageFuel.Add(carName, mileageFuel);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] input = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArgs = input[0];

                if (cmdArgs == "Drive")
                {
                    string carName = input[1];
                    int distance = int.Parse(input[2]);
                    int fuel = int.Parse(input[3]);

                    if (carMileageFuel[carName].Fuel >= fuel)
                    {
                        carMileageFuel[carName].Mileage += distance;
                        carMileageFuel[carName].Fuel -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else 
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (carMileageFuel[carName].Mileage >= 100000 && !carsToDelete.Contains(carName))
                    {
                        carsToDelete.Add(carName);
                        Console.WriteLine($"Time to sell the {carName}!");
                    }
                }
                else if (cmdArgs == "Refuel")
                {
                    string carName = input[1];
                    int fuel = int.Parse(input[2]);

                    if (carMileageFuel[carName].Fuel + fuel <= 75)
                    {
                        carMileageFuel[carName].Fuel += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                    else
                    {
                        int fuelRefilled = 75 - carMileageFuel[carName].Fuel;
                        carMileageFuel[carName].Fuel += fuelRefilled;
                        Console.WriteLine($"{carName} refueled with {fuelRefilled} liters");
                    }
                }
                else if (cmdArgs == "Revert")
                {
                    string carName = input[1];
                    int kilometers = int.Parse(input[2]);

                    if (carMileageFuel[carName].Mileage - kilometers < 10000)
                    {
                        carMileageFuel[carName].Mileage = 10000;
                    }
                    else
                    {
                        carMileageFuel[carName].Mileage -= kilometers;
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (var car in carsToDelete)
            {
                carMileageFuel.Remove(car);
            }

            foreach (var car in carMileageFuel)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }
}

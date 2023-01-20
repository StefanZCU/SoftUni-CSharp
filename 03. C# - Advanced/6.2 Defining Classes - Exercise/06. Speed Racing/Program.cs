using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                string[] currCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(currCar[0], double.Parse(currCar[1]), double.Parse(currCar[2]));
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[1];
                double amountOfKM = double.Parse(input[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.DistanceChecker(amountOfKM);
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}
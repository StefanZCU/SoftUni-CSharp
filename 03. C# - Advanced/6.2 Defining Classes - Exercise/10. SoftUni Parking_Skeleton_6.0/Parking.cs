using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars { get; }

        private int capacity;

        public int Count => cars.Count;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (cars.All(x => x.RegistrationNumber != RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";

            }

            cars.Remove(cars.First(x => x.RegistrationNumber == RegistrationNumber));
            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            return cars.First(x => x.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string number in RegistrationNumbers)
            {
                RemoveCar(number);
            }
        }
    }
}

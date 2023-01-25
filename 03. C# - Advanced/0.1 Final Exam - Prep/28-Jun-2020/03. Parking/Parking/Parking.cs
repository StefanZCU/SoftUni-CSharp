using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (data.Count != Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = null;

            foreach (var car in data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    carToRemove = car;
                    break;
                }
            }

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car carToGet = null;

            foreach (var car in data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    carToGet = car;
                    break;
                }
            }

            return carToGet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }


        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) 
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public void Drive(double distance)
        {
            Console.WriteLine(FuelQuantity - (distance * FuelConsumption) > 0
                ? FuelQuantity -= (distance * FuelConsumption)
                : "Not enough fuel to perform this trip!");
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\n" +
                   $"Model: {this.Model}\n" +
                   $"Year: {this.Year}\n" +
                   $"Fuel: {this.FuelQuantity:F2}";
        }
    }
}

using System;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "123");
            var car2 = new Car("Audi", "A3", 110, "456");
            var car3 = new Car("BMW", "X3", 590, "789");

            Parking parking = new Parking(5);
            parking.AddCar(car);
            parking.AddCar(car2);
            parking.AddCar(car3);

            Console.WriteLine(parking.Count);
        }
    }
}

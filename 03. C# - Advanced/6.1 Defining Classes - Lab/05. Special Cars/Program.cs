namespace CarManufacturer;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Tire[]> allTires = new List<Tire[]>();
        List<Engine> allEngines = new List<Engine>();
        List<Car> allCars = new List<Car>();

        string command;
        while ((command = Console.ReadLine()) != "No more tires")
        {
            double[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Tire[] tires = 
            {
                new((int)input[0], input[1]),
                new((int)input[2], input[3]),
                new((int)input[4], input[5]),
                new((int)input[6], input[7]),
            };

            allTires.Add(tires);
        }

        while ((command = Console.ReadLine()) != "Engines done")
        {
            double[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Engine engine = new Engine((int)input[0], input[1]);

            allEngines.Add(engine);
        }

        while ((command = Console.ReadLine()) != "Show special")
        {
            string[] currentCar = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string make = currentCar[0];
            string model = currentCar[1];
            int year = int.Parse(currentCar[2]);
            double fuelQuantity = double.Parse(currentCar[3]);
            double fuelConsumption = double.Parse(currentCar[4]);
            int engineIndex = int.Parse(currentCar[5]);
            int tiresIndex = int.Parse(currentCar[6]);

            Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, allEngines[engineIndex], allTires[tiresIndex]);

            allCars.Add(car);
        }

        List<Car> filteredCars = allCars
            .Where(x => x.Year >= 2017)
            .Where(x => x.Engine.HorsePower > 330)
            .Where(x => x.Tires.Sum(p => p.Pressure) >= 9 
                        && x.Tires.Sum(p => p.Pressure) <= 10)
            .ToList();

        foreach (var filteredCar in filteredCars)
        {
            filteredCar.Drive(20);
            Console.WriteLine(filteredCar.WhoAmI());
        }
    }
}
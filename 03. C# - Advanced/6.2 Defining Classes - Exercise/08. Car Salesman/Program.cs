using System.Dynamic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> allEngines = new List<Engine>();
            List<Car> allCars = new List<Car>();

            int numEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = new Engine(model, power);

                if (engineInfo.Length != 4 && engineInfo.Length > 2)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];

                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                allEngines.Add(engine);
            }

            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Car car = new Car(model);

                foreach (var engine in allEngines)
                {
                    if (engine.Model == engineModel)
                    {
                        car.Engine = engine;
                        break;
                    }
                }

                if (carInfo.Length != 4 && carInfo.Length > 2)
                {
                    if (char.IsDigit(carInfo[2][0]))
                    {
                        int weight = int.Parse(carInfo[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                allCars.Add(car);
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}: ");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine(car.Engine.Displacement != 0 ? $"    Displacement: {car.Engine.Displacement}": $"    Displacement: n/a");
                Console.WriteLine(car.Engine.Efficiency != null ? $"    Efficiency: {car.Engine.Efficiency}": $"    Efficiency: n/a");
                Console.WriteLine(car.Weight != 0 ? $"  Weight: {car.Weight}": $"  Weight: n/a");
                Console.WriteLine(car.Color != null ? $"  Color: {car.Color}": $"  Color: n/a");
            }
        }
    }
}
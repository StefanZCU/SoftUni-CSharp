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
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Tires[] tires =
                {
                    new (tire1Age, tire1Pressure),
                    new (tire2Age, tire2Pressure),
                    new (tire3Age, tire3Pressure),
                    new (tire4Age, tire4Pressure) 
                };

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string type = Console.ReadLine();

            switch (type)
            {
                case "fragile":

                    foreach (var car in cars.Where(x => x.Cargo.Type == type).Where(x => x.Tires.Any(y => y.Pressure < 1)))
                    {
                        Console.WriteLine(car.Model);
                    }

                    break;

                case "flammable":

                    foreach (var car in cars.Where(x => x.Cargo.Type == type).Where(x => x.Engine.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }

                    break;
            }
        }
    }
}
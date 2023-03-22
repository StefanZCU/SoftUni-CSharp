using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] carInfo = reader.ReadLine().Split();
            string[] truckInfo = reader.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numLines = int.Parse(reader.ReadLine());

            for (int i = 0; i < numLines; i++)
            {
                string[] line = reader.ReadLine().Split();

                switch (line[0])
                {
                    case "Drive":
                        switch (line[1])
                        {
                            case "Car":
                                writer.WriteLine(car.Drive(double.Parse(line[2])));
                                break;
                            case "Truck":
                                writer.WriteLine(truck.Drive(double.Parse(line[2])));
                                break;
                        }
                        break;
                    case "Refuel":
                        switch (line[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(line[2]));
                                break;
                            case "Truck":
                                truck.Refuel(double.Parse(line[2]));
                                break;
                        }
                        break;
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());


        }
    }
}

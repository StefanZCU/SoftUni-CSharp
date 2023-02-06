namespace Vehicles.Core
{
    using Interface;
    using IO.Interfaces;
    using Exceptions;
    using Factories.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory factory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = vehicleFactory;
        }

        public Engine()
        {
            vehicles = new List<IVehicle>();
        }


        public void Run()
        {
            CreateVehicle();
            CreateVehicle();

            int numCommands = int.Parse(reader.ReadLine());

            for (int i = 0; i < numCommands; i++)
            {
                string[] cmdArgs = reader.ReadLine().Split(" ");

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double value = double.Parse(cmdArgs[2]);

                try
                {
                    IVehicle vehicleToProcess = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                    if (cmdType == "Drive")
                    {
                        writer.WriteLine(vehicleToProcess.Drive(value));

                    }
                    else if (cmdType == "Refuel")
                    {
                        vehicleToProcess.Refuel(value);
                    }
                }
                catch (InvalidFuelAmount IFA)
                {
                    Console.WriteLine(IFA.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] vehicleArgs = reader.ReadLine().Split(" ");
            string vehicleType = vehicleArgs[0];
            double vehicleFuelQty = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);

            IVehicle vehicle = factory.CreateVehicle(vehicleType, vehicleFuelQty, vehicleFuelConsumption);
            
            vehicles.Add(vehicle);
            return vehicle;
        }
    }
}
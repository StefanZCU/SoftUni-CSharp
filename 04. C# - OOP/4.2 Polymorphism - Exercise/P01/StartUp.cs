using Vehicles.Factories;
using Vehicles.Factories.Interfaces;

namespace Vehicles
{
    using Core;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            Engine engine = new Engine(reader, writer, vehicleFactory);
            engine.Run();
        }
    }
}
namespace VehiclesExtension
{
    using IO;
    using IO.Interfaces;
    using Core;
    using Factories;
    using Factories.Interfaces;

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
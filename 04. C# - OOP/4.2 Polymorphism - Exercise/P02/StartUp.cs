﻿namespace P02
{
    using IO;
    using Core;
    using Factories;
    using IO.Interfaces;
    using Core.Interfaces;
    using Factories.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }
    }
}
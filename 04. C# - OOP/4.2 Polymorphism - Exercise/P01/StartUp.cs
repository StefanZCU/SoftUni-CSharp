namespace Vehicles
{
    using IO;
    using Core;
    using IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
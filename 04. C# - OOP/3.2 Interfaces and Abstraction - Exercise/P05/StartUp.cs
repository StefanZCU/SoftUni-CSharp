namespace BirthdayCelebrations
{
    using Core;
    using IO.Interfaces;
    using IO;
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
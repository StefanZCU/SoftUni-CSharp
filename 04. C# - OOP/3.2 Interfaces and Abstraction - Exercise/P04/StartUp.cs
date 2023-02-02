namespace BorderControl
{
    using Core;
    using Core.Interface;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
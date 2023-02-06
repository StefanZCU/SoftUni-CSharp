namespace Raiding
{
    using IO;
    using Core;
    using Factory;
    using Factory.Interfaces;
    using IO.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory factory = new HeroFactory();

            Engine engine = new Engine(reader, writer, factory);
            engine.Run();
        }
    }
}
namespace Telephony
{
    using IO;
    using Core;
    using Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
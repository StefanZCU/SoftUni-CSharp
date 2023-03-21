namespace P07
{
    using Core;
    using Core.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
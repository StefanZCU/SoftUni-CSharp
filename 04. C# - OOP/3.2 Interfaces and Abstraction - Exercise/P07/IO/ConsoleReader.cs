namespace MilitaryElite.IO
{
    using Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

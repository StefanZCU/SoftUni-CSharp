namespace Operations.IO
{
    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}

namespace Vehicles.IO
{
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}

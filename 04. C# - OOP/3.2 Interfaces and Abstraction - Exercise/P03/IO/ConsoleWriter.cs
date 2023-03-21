namespace Telephony.IO
{
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line) => Console.WriteLine(line);
    }
}

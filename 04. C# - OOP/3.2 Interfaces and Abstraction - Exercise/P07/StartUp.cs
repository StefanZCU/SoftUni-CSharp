using MilitaryElite.Core;
using MilitaryElite.IO;
using MilitaryElite.IO.Interfaces;

namespace MilitaryElite
{
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
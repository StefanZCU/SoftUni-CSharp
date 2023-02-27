using CollectionHierarchy.Core;
using CollectionHierarchy.IO;
using CollectionHierarchy.IO.Interfaces;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
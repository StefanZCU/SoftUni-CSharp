namespace Operations.Core
{
    using Interface;
    using IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            MathOperations mo = new MathOperations();
            writer.WriteLine(mo.Add(2, 3).ToString());
            writer.WriteLine(mo.Add(2.2, 3.3, 5.5).ToString());
            writer.WriteLine(mo.Add(2.2m, 3.3m, 4.4m).ToString());

        }
    }
}

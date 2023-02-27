namespace Animals.Core
{
    using Interface;
    using IO.Interfaces;
    using Models;

    internal class Engine : IEngine
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
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            writer.WriteLine(cat.ExplainSelf());
            writer.WriteLine(dog.ExplainSelf());
        }
    }
}

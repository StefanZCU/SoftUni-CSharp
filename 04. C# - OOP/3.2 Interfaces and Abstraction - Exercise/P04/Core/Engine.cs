
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    using Interface;
    using IO.Interfaces;
    using Models;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly List<IIdentifiables> identifiables;

        private Engine()
        {
            identifiables = new List<IIdentifiables>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] input = command.Split();
                string name = input[0];

                if (input.Length == 3)
                {
                    int age = int.Parse(input[1]);
                    string ID = input[2];
                    Citizen citizen = new Citizen(name, ID);
                    identifiables.Add(citizen);
                }
                else if (input.Length == 2)
                {
                    string ID = input[1];
                    Robot robot = new Robot(name, ID);
                    identifiables.Add(robot);
                }
            }

            string lastIDDigits = reader.ReadLine();

            foreach (var id in identifiables.Where(x => x.ID.EndsWith(lastIDDigits)))
            {
                Console.WriteLine(id.ID);
            }
        }
    }
}

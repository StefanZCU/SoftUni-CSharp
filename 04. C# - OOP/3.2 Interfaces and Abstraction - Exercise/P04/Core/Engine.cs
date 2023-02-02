
namespace BorderControl.Core
{
    using Interface;
    using IO.Interfaces;
    using Models;

    internal class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private List<Robot> robots;
        private List<Citizen> citizens;

        public Engine()
        {
            robots = new List<Robot>();
            citizens = new List<Citizen>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            List<string> IDs = new List<string>();

            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] input = command.Split();
                string name = input[0];

                if (input.Length == 3)
                {
                    int age = int.Parse(input[1]);
                    string ID = input[2];
                    Citizen citizen = new Citizen(name, age, ID);
                    citizens.Add(citizen);
                    IDs.Add(ID);
                }
                else if (input.Length == 2)
                {
                    string ID = input[1];
                    Robot robot = new Robot(name, ID);
                    robots.Add(robot);
                    IDs.Add(ID);
                }
            }

            string lastIDDigits = reader.ReadLine();

            foreach (var id in IDs)
            {
                string currentIDLastDigits = id.Substring(id.Length - lastIDDigits.Length);

                if (currentIDLastDigits == lastIDDigits)
                {
                    writer.WriteLine(id);
                }
            }
        }
    }
}

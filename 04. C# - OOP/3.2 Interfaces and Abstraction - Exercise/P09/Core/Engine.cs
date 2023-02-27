namespace ExplicitInterfaces.Core
{
    using Interfaces;
    using Models;
    using ExplicitInterfaces.IO.Interfaces;
    using ExplicitInterfaces.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public Engine(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }


        public void Run()
        {
            string command;
            while ((command = _reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');

                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                _writer.WriteLine(person.GetName());
                _writer.WriteLine(resident.GetName());
            }
        }
    }
}

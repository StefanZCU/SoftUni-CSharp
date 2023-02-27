namespace BirthdayCelebrations.Core
{
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;
    using Interface;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
         
        private readonly List<IIdentifiable> identifiers;
        public Engine()
        {
            identifiers = new List<IIdentifiable>();
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
                string[] input = command.Split(' ');

                if (input[0] == "Citizen")
                {
                    IIdentifiable citizen = new Citizen(input[4]);
                    identifiers.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    IIdentifiable pet = new Pet(input[2]);
                    identifiers.Add(pet);
                }
            }

            string yearToFind = reader.ReadLine();

            foreach (var identifiable in identifiers.Where(x => x.Birthday.EndsWith(yearToFind)))
            {
                writer.WriteLine(identifiable.Birthday);
            }
        }
    }
}

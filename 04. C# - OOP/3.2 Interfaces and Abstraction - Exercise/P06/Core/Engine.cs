namespace FoodShortage.Core
{
    using Interface;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly List<IBuyer> buyerList;

        public Engine()
        {
            buyerList = new List<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            int numCycles = int.Parse(reader.ReadLine());

            for (int i = 0; i < numCycles; i++)
            {
                string[] input = reader.ReadLine().Split();

                if (input.Length == 4)
                {
                    IBuyer buyer = new Citizen(input[0]);
                    buyerList.Add(buyer);
                }
                else if (input.Length == 3)
                {
                    IBuyer buyer = new Rebel(input[0]);
                    buyerList.Add(buyer);
                }
            }

            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                var personToFind = buyerList.FirstOrDefault(x => x.Name == command);

                personToFind?.BuyFood();
            }

            writer.WriteLine(buyerList.Sum(x => x.Food).ToString());
        }
    }
}

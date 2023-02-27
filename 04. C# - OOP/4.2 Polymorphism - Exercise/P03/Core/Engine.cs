namespace Raiding.Core
{ 
    using Interface;
    using IO.Interfaces;
    using Exceptions;
    using Factory.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory factory;

        private readonly ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory factory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
        }

        private Engine()
        {
            heroes = new List<IBaseHero>();
        }


        public void Run()
        {
            int numHeroesNeeded = int.Parse(reader.ReadLine());

            while (heroes.Count != numHeroesNeeded)
            {
                CreateHero();
            }

            int bossHealth = int.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            writer.WriteLine(heroes.Sum(x => x.Power) >= bossHealth 
                ? "Victory!" 
                : "Defeat...");
        }

        private void CreateHero()
        {
            string name = reader.ReadLine();
            string heroType = reader.ReadLine();
            
            try
            {
                IBaseHero hero = factory.CreateHero(heroType, name);
                heroes.Add(hero);
            }
            catch (InvalidHeroException ihe)
            {
                writer.WriteLine(ihe.Message);
            }
        }
    }
}
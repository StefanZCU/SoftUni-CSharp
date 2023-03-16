namespace Easter.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Dyes;
    using Models.Eggs;
    using Repositories;
    using Models.Bunnies;
    using Models.Workshops;
    using Utilities.Messages;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Bunnies.Contracts;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != nameof(HappyBunny) && bunnyType != nameof(SleepyBunny))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = bunnyType switch
            {
                nameof(HappyBunny) => new HappyBunny(bunnyName),
                _ => new SleepyBunny(bunnyName)
            };
            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunnyToFind = bunnies.FindByName(bunnyName);
            if (bunnyToFind == null) throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            IDye dye = new Dye(power);
            bunnyToFind.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg = eggs.FindByName(eggName);

            var bunniesForWork = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (bunniesForWork.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach (var bunny in bunniesForWork)
            {
                Workshop workshop = new Workshop();
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    return string.Format(OutputMessages.EggIsDone, egg.Name);
                }
            }

            return string.Format(OutputMessages.EggIsNotDone, egg.Name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!")
                .AppendLine("Bunnies info:");

            foreach (var bunniesModel in bunnies.Models)
            {
                sb.AppendLine(bunniesModel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

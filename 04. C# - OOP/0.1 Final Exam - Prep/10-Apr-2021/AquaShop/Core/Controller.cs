namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Models.Fish;
    using Repositories;
    using Models.Aquariums;
    using Models.Decorations;
    using Utilities.Messages;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                _ => new SaltwaterAquarium(aquariumName)
            };
            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                _ => new Plant()
            };
            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = decorations.FindByType(decorationType);
            if (!decorations.Remove(decoration)) throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            var aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                _ => new SaltwaterFish(fishName, fishSpecies, price)
            };
            var aquarium = aquariums.First(x => x.Name == aquariumName);

            switch (aquarium.GetType().Name)
            {
                case nameof(FreshwaterAquarium) when fish.GetType().Name == nameof(FreshwaterFish):
                case nameof(SaltwaterAquarium) when fish.GetType().Name == nameof(SaltwaterFish):
                    aquarium.AddFish(fish);
                    break;
                default: return OutputMessages.UnsuitableWater;
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.First(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.First(x => x.Name == aquariumName);
            var value = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

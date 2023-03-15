namespace SpaceStation.Models.Mission
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x => x.Oxygen > 0))
            {
                List<string> itemsToRemove = new List<string>();

                foreach (var planetItem in planet.Items)
                {
                    astronaut.Bag.Items.Add(planetItem);
                    itemsToRemove.Add(planetItem);
                    astronaut.Breath();

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }

                foreach (var item in itemsToRemove)
                {
                    planet.Items.Remove(item);
                }
            }
        }
    }
}

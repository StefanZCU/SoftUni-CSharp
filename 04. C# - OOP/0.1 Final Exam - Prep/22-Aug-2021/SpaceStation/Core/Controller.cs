namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Repositories;
    using Models.Mission;
    using Models.Planets;
    using Models.Astronauts;
    using Utilities.Messages;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;

    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private HashSet<IPlanet> planetsExplored;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            planetsExplored = new HashSet<IPlanet>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                _ => new Meteorologist(astronautName)
            };

            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName)
            {
                Items = items
            };
            planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronautRepository.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsToSend = astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();

            if (astronautsToSend.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            var planet = planetRepository.FindByName(planetName);
            Mission mission = new Mission();
            mission.Explore(planet, astronautsToSend);

            planetsExplored.Add(planet);
            return string.Format(OutputMessages.PlanetExplored, planetName,
                astronautsToSend.Count(x => !x.CanBreath));
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{planetsExplored.Count} planets were explored!")
                .AppendLine("Astronauts info:");

            foreach (var astronautRepositoryModel in astronautRepository.Models)
            {
                sb.AppendLine(astronautRepositoryModel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories;
    using Models.Weapons;
    using Models.Planets;
    using Utilities.Messages;
    using Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var planetToFind = planets.FindByName(planetName);

            if (planetToFind == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planetToFind.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                _ => new StormTroopers()
            };

            planetToFind.Spend(unit.Cost);
            planetToFind.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planetToFind = planets.FindByName(planetName);

            if (planetToFind == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planetToFind.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            IWeapon weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                _ => new SpaceMissiles(destructionLevel)
            };

            planetToFind.Spend(weapon.Price);
            planetToFind.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var planetToFind = planets.FindByName(planetName);

            if (planetToFind == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planetToFind.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planetToFind.Spend(1.25);
            planetToFind.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);
            IPlanet winningPlanet;
            IPlanet losingPlanet;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstPlanet.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon)) &&
                     secondPlanet.Weapons.All(x => x.GetType().Name != nameof(NuclearWeapon))) ||
                    (firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) &&
                     secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }

                winningPlanet = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    ? firstPlanet
                    : secondPlanet;

                losingPlanet = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    ? secondPlanet
                    : firstPlanet;
            }
            else
            {
                winningPlanet = firstPlanet.MilitaryPower > secondPlanet.MilitaryPower 
                    ? firstPlanet
                    : secondPlanet;

                losingPlanet = firstPlanet.MilitaryPower > secondPlanet.MilitaryPower
                    ? secondPlanet
                    : firstPlanet;
            }

            winningPlanet.Spend(winningPlanet.Budget / 2);
            winningPlanet.Profit(losingPlanet.Budget / 2);
            winningPlanet.Profit(losingPlanet.Army.Sum(x => x.Cost) + losingPlanet.Weapons.Sum(x => x.Price));
            planets.RemoveItem(losingPlanet.Name);
            return string.Format(OutputMessages.WinnigTheWar, winningPlanet.Name, losingPlanet.Name);

        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

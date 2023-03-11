namespace PlanetWars.Models.Planets
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Weapons;
    using Contracts;
    using Repositories;
    using MilitaryUnits;
    using Utilities.Messages;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        private double CalculateMilitaryPower()
        {
            double amount = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);

            if (Army.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                amount += amount * 0.3;
            }
            
            if (Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                amount += amount * 0.45;
            }

            return Math.Round(amount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;
        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }

        public void Spend(double amount)
        {
            if (amount > budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            budget -= amount;
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine(Army.Count > 0
                    ? $"--Forces: {string.Join(", ", Army.Select(x => x.GetType().Name))}"
                    : "--Forces: No units")
                .AppendLine(Weapons.Count > 0
                    ? $"--Combat equipment: {string.Join(", ", Weapons.Select(x => x.GetType().Name))}"
                    : "--Combat equipment: No weapons")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }
    }
}

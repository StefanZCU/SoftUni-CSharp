using System;
using System.Linq;
using System.Text;
using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Utilities.Messages;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroAlreadyExists, name));
            }

            if (type != nameof(Knight) &&
                type != nameof(Barbarian))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidHeroType);
            }

            IHero hero;
            switch (type)
            {
                case nameof(Knight):
                    hero = new Knight(name, health, armour);
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessfullyCreatedKnight, name);
                default:
                    hero = new Barbarian(name, health, armour);
                    heroes.Add(hero);
                    return string.Format(OutputMessages.SuccessfullyCreatedBarbarian, name);
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyExists, name));
            }

            if (type != nameof(Mace) &&
                type != nameof(Claymore))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidWeaponType);
            }

            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                _ => new Claymore(name, durability),
            };

            weapons.Add(weapon);
            return string.Format(OutputMessages.SuccessfullyAddedWeaponToCollection, weapon.GetType().Name.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var currentHero = heroes.FindByName(heroName);
            var currentWeapon = weapons.FindByName(weaponName);

            if (currentHero == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroDoesNotExist, heroName));
            }

            if (currentWeapon == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponDoesNotExist, weaponName));
            }

            if (currentHero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HeroAlreadyHasWeapon, heroName));
            }

            currentHero.AddWeapon(currentWeapon);
            weapons.Remove(currentWeapon);
            return string.Format(OutputMessages.HeroCanParticipateInBattle, heroName,
                currentWeapon.GetType().Name.ToLower());
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList());
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models
                         .OrderBy(x => x.GetType().Name)
                         .ThenByDescending(x => x.Health)
                         .ThenBy(x => x.Name))
            {
                sb
                    .AppendLine($"{hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"--Health: {hero.Health}")
                    .AppendLine($"--Armour: {hero.Armour}")
                    .AppendLine(hero.Weapon != null ? $"--Weapon: {hero.Weapon.Name}" : "--Weapon: Unarmed");

            }

            return sb.ToString().TrimEnd();

        }
    }
}

using System;
using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameCannotBeNull);
                }

                name = value;
            }
        }
        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthCannotBeNegative);
                }

                health = value;
            }
        }
        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourCannotBeNegative);
                }

                armour = value;
            }
        }
        public bool IsAlive => Health > 0;
        public IWeapon Weapon
        {
            get => weapon;
            private set => weapon = value ?? throw new ArgumentException(ExceptionMessages.WeaponIsNull);
        }
        public void AddWeapon(IWeapon weapon)
        {
            Weapon ??= weapon;
        }
        public void TakeDamage(int points)
        {
            if (Armour - points <= 0)
            {
                points -= Armour;
                Armour = 0;

                if (Health - points <= 0)
                {
                    Health = 0;
                }
                else
                {
                    Health -= points;
                }
            }
            else
            {
                Armour -= points;
            }

        }
    }
}

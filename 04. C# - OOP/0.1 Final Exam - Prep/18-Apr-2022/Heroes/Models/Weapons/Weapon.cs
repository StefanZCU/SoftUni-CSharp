using System;

using Heroes.Utilities.Messages;
using Heroes.Models.Contracts;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNameCannotBeNull);
                }

                name = value;
            }
        }

        public int Durability
        {
            get => durability;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponDurabilityCannotBeNegative);
                }

                durability = value;
            }
        }

        public abstract int DoDamage();
    }
}

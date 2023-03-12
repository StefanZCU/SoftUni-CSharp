namespace Heroes.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string WeaponNameCannotBeNull = "Weapon type cannot be null or empty.";
        public const string WeaponDurabilityCannotBeNegative = "Durability cannot be below 0.";
        public const string HeroNameCannotBeNull = "Hero name cannot be null or empty.";
        public const string HeroHealthCannotBeNegative = "Hero health cannot be below 0.";
        public const string HeroArmourCannotBeNegative = "Hero armour cannot be below 0.";
        public const string WeaponIsNull = "Weapon cannot be null.";
        public const string HeroAlreadyExists = "The hero {0} already exists.";
        public const string InvalidHeroType = "Invalid hero type.";
        public const string WeaponAlreadyExists = "The weapon {0} already exists.";
        public const string InvalidWeaponType = "Invalid weapon type.";
        public const string HeroDoesNotExist = "Hero {0} does not exist.";
        public const string WeaponDoesNotExist = "Weapon {0} does not exist.";
        public const string HeroAlreadyHasWeapon = "Hero {0} is well-armed.";
    }
}

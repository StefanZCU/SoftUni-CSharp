namespace Raiding.Factory
{
    using Exceptions;
    using Interfaces;
    using Models;
    using Raiding.Models.Interfaces;

    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string heroType, string name)
        {
            IBaseHero baseHero;
            if (heroType == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (heroType == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroException(ExceptionMessages.InvalidHeroException);
            }

            return baseHero;
        }
    }
}

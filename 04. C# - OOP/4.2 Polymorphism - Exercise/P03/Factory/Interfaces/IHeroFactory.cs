namespace Raiding.Factory.Interfaces
{
    using Raiding.Models.Interfaces;

    public interface IHeroFactory
    {
        IBaseHero CreateHero(string heroType, string name);
    }
}

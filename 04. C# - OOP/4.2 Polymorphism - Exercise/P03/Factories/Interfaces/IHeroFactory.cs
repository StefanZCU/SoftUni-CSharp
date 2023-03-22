namespace P03.Factories.Interfaces
{
    using P03.Models.Interfaces;

    public interface IHeroFactory
    {
        IHero Create(string type, string name);
    }
}

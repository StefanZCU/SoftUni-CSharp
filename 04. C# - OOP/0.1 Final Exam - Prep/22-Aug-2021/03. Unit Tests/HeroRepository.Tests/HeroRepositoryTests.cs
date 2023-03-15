using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository repository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Stefan", 5);
        repository = new HeroRepository();
    }

    [Test]
    public void Test_IsHeroConstructorWorkingProperly()
    {
        Assert.AreEqual("Stefan", hero.Name);
        Assert.AreEqual(5, hero.Level);
    }

    [Test]
    public void Test_DoesCreateMethodThrowWithNullHero()
    {
        Assert.Throws<ArgumentNullException>(() => { repository.Create(null); });
    }

    [Test]
    public void Test_DoesCreateMethodThrowWithAlreadyAddedHero()
    {
        repository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => { repository.Create(hero); });
    }

    [Test]
    public void Test_DoesCreateMethodAddHeroesProperly()
    {
        repository.Create(hero);
        Assert.AreEqual(1, repository.Heroes.Count);
    }

    [Test]
    public void Test_DoesRemoveMethodThrowExceptionWithEmptyName()
    {
        Assert.Throws<ArgumentNullException>(() => { repository.Remove(""); });
    }

    [Test]
    public void Test_DoesRemoveMethodReturnFalseIfHeroNotFound()
    {
        bool isRemoved = repository.Remove("Martina");
        Assert.AreEqual(false, isRemoved);
    }

    [Test]
    public void Test_DoesRemoveMethodReturnTrueIfHeroFound()
    {
        repository.Create(hero);
        bool isRemoved = repository.Remove("Stefan");
        Assert.AreEqual(true, isRemoved);
    }

    [Test]
    public void Test_GetHeroWithHighestLevelThrowsExceptionWithNoHeroes()
    {
        Assert.Throws<IndexOutOfRangeException>(() => { repository.GetHeroWithHighestLevel(); });
    }

    [Test]
    public void Test_GetHeroWithHighestLevelThrowsWorksProperly()
    {
        repository.Create(hero);
        Assert.AreEqual(hero, repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void Test_GetHeroMethodReturnsNullWithNoHeroes()
    {
        Assert.AreEqual(null, repository.GetHero("Martina"));
    }

    [Test]
    public void Test_GetHeroMethodWorksProperly()
    {
        repository.Create(hero);
        Assert.AreEqual(hero, repository.GetHero(hero.Name));
    }
}
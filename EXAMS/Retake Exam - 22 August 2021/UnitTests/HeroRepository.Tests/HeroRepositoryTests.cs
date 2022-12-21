using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateHeroNormaly()
    {
        Hero hero = new Hero("name", 1);
        Assert.AreEqual("name", hero.Name);
        Assert.AreEqual(1, hero.Level);
    }
    [Test]
    public void HeroRepositoryCreateHeroNormaly()
    {
        Hero hero = new Hero("name", 1);
        HeroRepository heroes = new HeroRepository();
        string result = "Successfully added hero name with level 1";
        Assert.AreEqual(heroes.Create(hero), result);
    }
    [Test]
    public void CreateHeroBadName()
    {
        HeroRepository heroes = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Create(null);
        });
    }
    [Test]
    public void CreateHeroThatExist()
    {
        Hero hero = new Hero("name", 1);
        HeroRepository heroes = new HeroRepository();
        Assert.Throws<InvalidOperationException>(() =>
        {
            heroes.Create(hero);
            heroes.Create(hero);
        });
    }
    [Test]
    public void RemoveNormaly()
    {
        Hero hero = new Hero("name", 1);
        HeroRepository heroes = new HeroRepository();
        heroes.Create(hero);
        Assert.AreEqual(true, heroes.Remove("name"));
    }
    [Test]
    [TestCase (null)]
    [TestCase ("")]
    public void RemoveNullName(string name)
    {
        HeroRepository heroes = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Remove(name);
        });
    }
    [Test]
    public void GetHeroWithHighestLevel()
    {
        Hero hero1 = new Hero("name1", 1);
        Hero hero2 = new Hero("name2", 2);
        HeroRepository heroes = new HeroRepository();
        heroes.Create(hero1);
        heroes.Create(hero2);
        Assert.AreEqual(hero2, heroes.GetHeroWithHighestLevel());
    }
    [Test]
    public void GetHero()
    {
        Hero hero1 = new Hero("name1", 1);
        HeroRepository heroes = new HeroRepository();
        heroes.Create(hero1);
        Assert.AreEqual(hero1, heroes.GetHero("name1"));
    }

}
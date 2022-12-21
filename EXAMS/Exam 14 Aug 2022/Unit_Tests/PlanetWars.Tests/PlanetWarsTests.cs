using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void TryCreatePlanet()
            {
                Planet planet = new Planet("test", 20.20);
                Assert.AreEqual("test",planet.Name);
                Assert.AreEqual(20.20, planet.Budget);
            }
            [Test]
            [TestCase ("")]
            [TestCase (null)]
            public void TryCreatePlanetWithWrongName(string name)
            {
                
                Assert.Throws<ArgumentException>(() =>
                { Planet planet = new Planet(name, 1); });

            }
            [Test]
            [TestCase (-1)]
            public void TryCreatePlanetWithWrongBudget(double budget)
            {
                
                Assert.Throws<ArgumentException>(() =>
                { Planet planet = new Planet("Test", budget); });

            }
            [Test]
            [TestCase (1.1)]
            public void TryProfit(double profit)
            {
                Planet planet = new Planet("Test", 2);
                planet.Profit(profit);
                Assert.AreEqual(3.1, planet.Budget);
            }
            [Test]
            public void TrySpendFunds()
            {
                Planet planet = new Planet("Test", 2);
                planet.SpendFunds(1);
                Assert.AreEqual(1, planet.Budget);
            }
            [Test]
            public void TrySpendFundsMoreThenBudget()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Test", 2);
                    planet.SpendFunds(3);
                });

            }
            [Test]
            public void TryAddWeapon()
            {
                Planet planet = new Planet("Test", 2);
                Weapon weapon = new Weapon("name", 1, 2);
                planet.AddWeapon(weapon);
                Assert.AreEqual(true, planet.Weapons.FirstOrDefault(x => x.Name == "name") != null);
            }
            [Test]
            public void TryAddWeaponTwise()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Test", 2);
                    Weapon weapon = new Weapon("name", 1, 2);
                    planet.AddWeapon(weapon);
                    planet.AddWeapon(weapon);
                });

            }
            [Test]
            public void TryRemoveWeapon()
            {
                    Planet planet = new Planet("Test", 2);
                    Weapon weapon = new Weapon("name", 1, 2);
                    planet.AddWeapon(weapon);
                    planet.RemoveWeapon("name");
                Assert.AreEqual(true, planet.Weapons.FirstOrDefault(x => x.Name == "name") == null);

            }
            [Test]
            public void TryUpgradeWeapon()
            {
                    Planet planet = new Planet("Test", 2);
                    Weapon weapon = new Weapon("name", 1, 2);
                    planet.AddWeapon(weapon);
                    planet.UpgradeWeapon("name");
                Assert.AreEqual(3, weapon.DestructionLevel);
            }
            [Test]
            public void TryUpgradeNotExistingWeapon()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Test", 2);
                    planet.UpgradeWeapon("name");
                });}
            }
        [Test]
        public void TryDestructOpponent()
        {
                Planet planet1 = new Planet("Test1", 2);
                Planet planet2 = new Planet("Test2", 2);
                Weapon weapon = new Weapon("weapon", 1, 2);
                planet1.AddWeapon(weapon);
            var expected = "Test2 is destructed!";
            Assert.AreEqual(planet1.DestructOpponent(planet2), expected);
        }
        [Test]
        public void TryDestructStrongerOpponent()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Planet planet1 = new Planet("Test1", 2);
                Planet planet2 = new Planet("Test2", 2);
                Weapon weapon = new Weapon("weapon", 1, 2);
                planet1.AddWeapon(weapon);
                planet2.DestructOpponent(planet1);
            });
        }
        [Test]
        public void TryCreateWeapon()
        {
            Weapon weapon = new Weapon("test", 1.1, 1);
            Assert.AreEqual("test", weapon.Name);
            Assert.AreEqual(1.1, weapon.Price);
            Assert.AreEqual(1, weapon.DestructionLevel);
        }
        [Test]
        [TestCase(-1)]
        public void TryCreateWeaponWrongPrice(double price)
        {

            Assert.Throws<ArgumentException>(() =>
            { Weapon weapon = new Weapon("test",price,1); });
        }
        [Test]
        public void TryWeaponIncreaseDestructionLevel()
        {
            Weapon weapon = new Weapon("test", 1.1, 1);
            weapon.IncreaseDestructionLevel();
            Assert.AreEqual(2,weapon.DestructionLevel);
        }
        [Test]
        public void TryWeaponIsNuclear()
        {
            Weapon weapon = new Weapon("test", 1.1, 9);
            weapon.IncreaseDestructionLevel();
            Assert.AreEqual(true,weapon.IsNuclear);
        }
    }

}

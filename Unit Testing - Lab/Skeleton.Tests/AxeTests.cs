using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
        }
        [Test]
        public void AxeLosesDurabilityPoints()
        {
            Axe axe = new Axe(10,10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void AxeAttackWithBrokenWeapon()
        {
            Axe axe = new Axe(10,0);
            Dummy dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() =>
                {
                    axe.Attack(dummy);
                });
        }
    }
}
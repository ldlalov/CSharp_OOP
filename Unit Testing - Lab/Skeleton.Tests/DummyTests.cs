using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealth()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(5);
            Assert.AreEqual(5, dummy.Health);
        }
        [Test]
        public void DeadDummyThrowsException()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
            dummy.TakeAttack(2);
            });
        }
        public void DummyCanGiveExperiance()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(10);

        }
    }
}
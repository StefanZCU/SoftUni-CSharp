using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(15, 10);
            dummy.TakeAttack(10);
            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void DummyThrowsExceptionIfDead()
        {
            Dummy dummy = new Dummy(15, 10);
            dummy.TakeAttack(15);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(15));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(15, 10);
            dummy.TakeAttack(15);
            Assert.AreEqual(10, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            Dummy dummy = new Dummy(15, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
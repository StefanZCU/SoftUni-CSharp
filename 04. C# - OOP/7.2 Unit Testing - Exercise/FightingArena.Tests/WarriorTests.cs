namespace Tests
{
    using System;

    using FightingArena;

    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Test_WarriorConstructorShouldWorksCorrectly()
        {
            var warrior = new Warrior("Pesho", 15, 100);

            var expectedName = "Pesho";
            var expectedDamage = 15;
            var expectedHp = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void Test_WarriorNameShouldThrowExceptionIfIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 25, 50));
        }

        [Test]
        public void Test_WarriorNameShouldThrowExceptionIfIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 25, 50));
        }

        [Test]
        public void Test_WarriorDamageShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pato", -10, 100));
        }

        [Test]
        public void Test_WarriorDamageShouldThrowExceptionIfIsZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pato", 0, 100));
        }

        [Test]
        public void Test_WarriorHpShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pato", 15, -10));
        }

        [Test]
        public void Test_AttackMethodShouldWorksCorrectly()
        {
            var attacker = new Warrior("Pato", 10, 100);
            var defender = new Warrior("Stefcho", 5, 90);

            attacker.Attack(defender);

            var expectedAttackerHp = 95;
            var expectedDefenderHp = 80;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void Test_WarriorShouldNotAttackIfHisHpIsEqualOrLessThan30()
        {
            var attacker = new Warrior("Pato", 10, 25);
            var defender = new Warrior("Stefcho", 5, 45);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Test_WarriorShouldNotAttackEnemyWith30HpOrLess()
        {
            var attacker = new Warrior("Pato", 10, 45);
            var defender = new Warrior("Stefcho", 5, 25);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Test_WarriorShouldNotAttackEnemyWithBiggerDamageThanHisHealth()
        {
            var attacker = new Warrior("Pato", 10, 35);
            var defender = new Warrior("Stefcho", 45, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Test_EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            var attacker = new Warrior("Pato", 50, 100);
            var defender = new Warrior("Onq", 45, 40);

            attacker.Attack(defender);

            var expectedAttackerHp = 55;
            var expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
    }
}
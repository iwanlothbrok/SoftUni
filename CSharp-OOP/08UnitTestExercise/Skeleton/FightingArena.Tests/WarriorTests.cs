namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void NameDamageHpShouldImplementCorrectlyWarrior()
        {
            Warrior warrior = new Warrior("Iwi", 50, 50);
            Assert.AreEqual(warrior, warrior);
        }
        [Test]
        public void NameShouldNotBeNullOrWhiteSpace()
        {
            Warrior warrior;

            Assert.Throws<ArgumentException>(() => warrior = new Warrior(null, 50, 50));
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("", 50, 50));
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(" ", 50, 50));
        }
        [Test]
        public void DamageShouldNotBeZeroOrNegative()
        {
            Warrior warrior;

            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Iwo", 0, 50));
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Iwi", -10, 50));
        }
        [Test]
        public void HpShouldNotBeNegative()
        {
            Warrior warrior;

            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Iwo", 50, -30));
        }
        [Test]
        public void WarriorShouldNotAttackIfHisHpIsBelow30()
        {
            Warrior attacker = new Warrior("Iwi", 70, 20);
            Warrior deffender = new Warrior("Iwo", 50, 100);


            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }
        [Test]
        public void WarriorShouldNotAttackDeffenderWithHpBelow30()
        {
            Warrior attacker = new Warrior("Iwi", 70, 50);
            Warrior deffender = new Warrior("Iwo", 50, 20);


            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }
        [Test]
        public void WarriorShouldNotAttackStrongerEnemy()
        {
            Warrior attacker = new Warrior("Iwi", 50, 50);
            Warrior deffender = new Warrior("Iwo", 80, 80);


            Assert.Throws<InvalidOperationException>(() => attacker.Attack(deffender));
        }
        [Test]
        public void WarriorShouldAttackEnemy()
        {
            Warrior attacker = new Warrior("Iwi", 100, 100);
            Warrior deffender = new Warrior("Iwo", 60, 60);

            attacker.Attack(deffender);

            Assert.AreEqual(0, deffender.HP);
        }
    }

}
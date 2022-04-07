namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void EnrollShouldNotAddWarriorIfHeIsInArena()
        {
            Warrior attacker = new Warrior("iwi", 80, 80);

            Arena arena = new Arena();
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(attacker));
        }
        [Test]
        public void FightMethodShouldThrowExceptionIfWarriorIsNull() // CHECK FOR DEFFENDER=NULL
        {
            Warrior attacker = new Warrior("iwi", 80, 80);
            Arena arena = new Arena();

            arena.Enroll(attacker);


            Assert.Throws<InvalidOperationException>(() => arena.Fight("iwi", "gogi"));
        }
        [Test]
        public void WarriorsShouldFightInArena()
        {
            Warrior attacker = new Warrior("iwi", 80, 80);
            Warrior deffender = new Warrior("pepi", 60, 60);
            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(deffender);


            arena.Fight("iwi", "pepi");

            Assert.AreEqual(0, deffender.HP);
        }
        [Test]
        public void ArenaCountShouldBeCorrect()
        {
            Warrior attacker = new Warrior("iwi", 80, 80);
            Warrior deffender = new Warrior("pepi", 60, 60);
            Arena arena = new Arena();

            arena.Enroll(attacker);
            arena.Enroll(deffender);


         

            Assert.AreEqual(2, arena.Count);
        }
    }
}

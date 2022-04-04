using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldDie()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(9, 9);

            axe.Attack(dummy);
            Assert.True(dummy.IsDead());
        }
        [Test]
        public void DeadDummyShouldThrowsAnExceptionIfDie()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(5, 5);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
        }
        [Test]
        public void DummyShouldGiveXP()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(5, 5);
            axe.Attack(dummy);

            int experience = dummy.GiveExperience();
            Assert.AreEqual(5, experience);
        }
        [Test]
        public void AliveDummyShouldNotGiveXP()
        {
            //var axe = new Axe(2, 2);
            var dummy = new Dummy(5, 5);
           // axe.Attack(dummy);
     
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldDecreaseDurability()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void AxeAttackingWithNegativeNumber()

        {
            var axe = new Axe(1, -1);
            var dummy = new Dummy(1, 1);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}

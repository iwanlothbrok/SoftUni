using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartphoneConstructorShouldValidateCorrectly()
        {
            Smartphone smartphone = new Smartphone("samsuing", 50);

            Assert.IsNotNull(smartphone);
            Assert.AreEqual("samsuing", smartphone.ModelName);
            Assert.AreEqual(50, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(50, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void SmartphoneConstructorWithNegativeNumber()
        {
            Smartphone smartphone = new Smartphone("sams", -20);

            Assert.IsNotNull(smartphone);
            Assert.AreEqual("sams", smartphone.ModelName);
            Assert.AreEqual(-20, smartphone.MaximumBatteryCharge);
        }
        [Test]
        public void ShopConstructorShouldReturnCorrectly()
        {
            Smartphone smartphone = new Smartphone("sams", 20);
            Shop shop = new Shop(5);

            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
            Assert.AreEqual(5, shop.Capacity);

        }
        [Test]
        public void CapacitryShouldThrowExceptionForNegativeCapacity()
        {
            Shop shop;

            Assert.Throws<ArgumentException>(() => shop = new Shop(-2));
        }
        [Test]
        public void AddMethodShouldThrowExceptionForFullCapacity()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("sams", 20);

            Smartphone smartphone1 = new Smartphone("phone", 20);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1));
        }
        [Test]
        public void AddMethodShouldThrowExceptionForAddingSameModelPhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);
            Smartphone smartphone1 = new Smartphone("sams", 20);



            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1));
        }
        [Test]
        public void RemoveMethodShouldRemoveCorrectly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);

            shop.Add(smartphone);
            shop.Remove("sams");

            Assert.AreEqual(0, shop.Count);
            Assert.AreEqual(2, shop.Capacity);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionForIncorectPhoneName()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("incorect"));
        }
        [Test]
        public void TestPhoneMethodShouldRunCorrectly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 100);
            shop.Add(smartphone);

            shop.TestPhone("sams", 20);

            Assert.AreEqual(80, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void TestPhoneMethodShouldThrowExceptionForIncorrectPhoneName()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("incorect", 2));
        }
        [Test]
        public void TestPhoneMethodShouldThrowExceptionForMoreBatteryUsageThanCurrectBattert()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("sams", 50));
        }
        [Test]
        public void ChargePhoneMethoudlShouldRunCurrectly()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);
            shop.Add(smartphone);

            shop.ChargePhone("sams");


            Assert.AreEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
        }
        [Test]
        public void ChargePhoneMethoudlShouldThrowExceptionForIncorrectPhoneName()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("sams", 20);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("incorrect"));
        }
    }
}
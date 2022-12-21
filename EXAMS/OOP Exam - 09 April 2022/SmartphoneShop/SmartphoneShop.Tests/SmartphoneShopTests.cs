using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void CreateSmarphoneNormaly()
        {
            Smartphone phone = new Smartphone("Name", 100);
            Assert.AreEqual("Name",phone.ModelName);
            Assert.AreEqual(100,phone.CurrentBateryCharge);
            Assert.AreEqual(100,phone.MaximumBatteryCharge);
        }
        [Test]
        public void CreateShopNormaly()
        {
            Shop shop = new Shop(10);
            Assert.AreEqual(10, shop.Capacity);
        }
        [Test]
        public void CreateShopBadCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            { Shop shop = new Shop(-1); ; });
        }
        [Test]
        public void AddPhoneToShop()
        {
            Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("Nokia",100);
            shop.Add(phone);
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void AddExistingPhoneToShop()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

            Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("Nokia",100);
            shop.Add(phone);
            shop.Add(phone);
            });
        }
        [Test]
        public void AddPhoneToShopMoreThenCapacity()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("Nokia",100);
            Smartphone phone1 = new Smartphone("Samsung",100);
            shop.Add(phone);
            shop.Add(phone1);
            });
        }
        [Test]
        public void RemovePhoneToShop()
        {
            Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.Remove("Nokia");
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void RemoveUnexistingPhoneToShop()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Shop shop = new Shop(10);
                shop.Remove("Samsung");
            });
        }
        [Test]
        public void TestPhoneNormaly()
        {

                Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("Nokia", 100);
            shop.Add(phone);
            shop.TestPhone("Nokia", 50);
            Assert.AreEqual(50, phone.CurrentBateryCharge);
            //Assert.DoesNotThrow(() => { shop.TestPhone("Nokia", 50); });
        }
        [Test]
        public void TestPhoneNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Shop shop = new Shop(10);
                shop.TestPhone("Nokia", 50);
            });
        }
        [Test]
        public void TestPhoneReturnsLowBattery()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Shop shop = new Shop(10);
                Smartphone phone = new Smartphone("Nokia",50);
                shop.Add(phone);
                shop.TestPhone("Nokia", 60);
            });
        }
        [Test]
        public void ChargePhoneNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Shop shop = new Shop(10);
                shop.ChargePhone("Nokia");
            });
        }
        [Test]
        public void ChargePhoneNormaly()
        {
            Shop shop = new Shop(10);
            Smartphone phone = new Smartphone("Nokia", 50);
            phone.CurrentBateryCharge = 20;
            shop.Add(phone);
            shop.ChargePhone("Nokia");
            Assert.AreEqual(phone.MaximumBatteryCharge,phone.CurrentBateryCharge);
        }

    }
}
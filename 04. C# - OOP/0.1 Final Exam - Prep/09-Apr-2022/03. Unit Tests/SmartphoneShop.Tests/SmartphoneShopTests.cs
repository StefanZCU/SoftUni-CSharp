using System;
using NuGet.Frameworks;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone("iPhone", 5000);
            shop = new Shop(1);
        }

        [Test]
        public void Test_IsSmartPhoneConstructorWorkingProperly()
        {
            Assert.That(smartphone.ModelName == "iPhone" && smartphone.MaximumBatteryCharge == 5000);
        }

        [Test]
        public void Test_IsShopConstructorWorkingProperly()
        {
            Assert.That(shop.Capacity == 1 && shop.Count == 0);
        }

        [Test]
        public void Test_WillThrowExceptionWithInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => { shop = new Shop(-1); }, "Invalid capacity.");
        }

        [Test]
        public void Test_AddSmartphoneWorksProperly()
        {
            shop.Add(smartphone);
            Assert.That(shop.Count == 1);
        }

        [Test]
        public void Test_AddMethodWillThrowExceptionIfPhoneIsAlreadyAdded()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => { shop.Add(smartphone); },
                $"The phone model {smartphone.ModelName} already exist.");
        }

        [Test]
        public void Test_AddMethodWillThrowExceptionIfCapacityIsFull()
        {
            Smartphone smartphone2 = new Smartphone("Android", 4000);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => { shop.Add(smartphone2); }, "The shop is full.");
        }

        [Test]
        public void Test_RemoveMethodWillThrowExceptionIfPhoneIsNotFound()
        {
            Smartphone smartphone2 = new Smartphone("Android", 5000);

            Assert.Throws<InvalidOperationException>(() => { shop.Remove(smartphone2.ModelName); },
                $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

        [Test]
        public void Test_RemoveMethodWillRemoveProperly()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);
            Assert.That(shop.Count == 0);
        }

        [Test]
        public void Test_TestPhoneMethodWillThrowExceptionIfPhoneIsNotFound()
        {
            Smartphone smartphone2 = new Smartphone("Android", 5000);

            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone(smartphone2.ModelName, 4000); },
                $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneMethodWillThrowExceptionIfBatteryUsageIsMoreThanBatteryCapacity()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone.ModelName, 7000);
            }, $"The phone model {smartphone.ModelName} is low on batery.");
        }

        [Test]
        public void Test_TestPhoneMethodWorksProperly()
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 3000);
            Assert.That(smartphone.CurrentBateryCharge == 2000);
        }

        [Test]
        public void Test_ChargePhoneMethodWillThrowExceptionIfPhoneModelDoesNotExist()
        {
            Smartphone smartphone2 = new Smartphone("Android", 5000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(smartphone2.ModelName);
            }, $"The phone model {smartphone2.ModelName} doesn't exist.");
        }

        [Test]
        public void Test_ChargePhoneMethodWorksProperly()
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, 3000);
            shop.ChargePhone(smartphone.ModelName);
            Assert.That(smartphone.CurrentBateryCharge == 5000);
        }
    }
}
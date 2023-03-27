namespace Tests
{
    using System;

    using CarManager;

    using NUnit.Framework;

    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car("BMW", "M8", 8.5, 60.0);
        }

        [Test]
        public void CarShouldBeCreatedSuccessfully()
        {
            var expectedMake = "BMW";
            var expectedModel = "M8";
            var expectedFuelConsumption = 8.5;
            var expectedFuelCapacity = 60.0;

            Assert.That(car.Make, Is.EqualTo(expectedMake));
            Assert.That(car.Model, Is.EqualTo(expectedModel));
            Assert.That(car.FuelConsumption, Is.EqualTo(expectedFuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(expectedFuelCapacity));
        }

        [Test]
        public void Test_CarShouldBeCreatedWithZeroFuelAmount()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_CarMakeShouldThrowExceptionIfIsSetToNull(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "M8", 8.5, 60.0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_CarModelShouldThrowExceptionIfIsSetToNull(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", model, 8.5, 60.0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void Test_CarFuelConsumptionShouldThrowExceptionIfIsNegativeOrZero(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M8", fuelConsumption, 60.0));
        }

        [Test]
        public void Test_CarFuelAmountShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(12));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void Test_CarFuelCapacityShouldThrowExceptionIfIsNegativeOrZero(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "M8", 8.5, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Test_CarRefuelShouldThrowExceptionIfFuelIsNegativeOrZero(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void Test_CarRefuelShouldIncreaseFuelAmount()
        {
            car.Refuel(10);
            var expectedResult = 10;
            var actualResult = car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            car.Refuel(70);
            var expectedResult = 60;
            var actualResult = car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_CarDriveMethodShouldDecreaseFuelAmount()
        {
            car.Refuel(10);
            car.Drive(10);
            var expectedResult = 9.15;
            var actualResult = car.FuelAmount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test_CarDriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            car.Refuel(2);

            Assert.Throws<InvalidOperationException>(() => car.Drive(30));
        }
    }
}
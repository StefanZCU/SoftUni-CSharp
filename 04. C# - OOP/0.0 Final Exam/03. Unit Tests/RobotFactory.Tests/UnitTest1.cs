using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Robot robot;
        private Supplement supplement;
        private Factory factory;
        
        [SetUp]
        public void Setup()
        {
            robot = new Robot("Stef", 50, 1234);
            supplement = new Supplement("Protein", 1234);
            factory = new Factory("BigBoy", 3);
        }

        [Test]
        public void Test1_FactoryCTORName()
        {
            Assert.AreEqual("BigBoy", factory.Name);
        }

        [Test]
        public void Test1_FactoryCTORCapacity()
        {
            factory.Capacity = 1;
            var expectedResult = factory.Capacity;
            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void Test1_FactoryCTORListsHaveBeenProperlyInstantiated()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            var expectedResult = factory.Robots.Count;
            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void Test2_FactoryCTORListsHaveBeenProperlyInstantiated()
        {
            factory.ProduceSupplement("Protein", 1234);
            var expectedResult = factory.Supplements.Count;
            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void Test_IsProduceRobotMethodWorkingProperly()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            string expectedResult = $"Produced --> Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}";
            Assert.AreEqual(factory.Robots.Count, 1);
            var actualResult = factory.ProduceRobot("Stef", 50, 1234);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestForStringRobot()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}");

            string expectedResult = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedResult, robot.ToString());
        }

        [Test]
        public void TestForStringSupplement()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Supplement: {supplement.Name} IS: {supplement.InterfaceStandard}");

            string expectedResult = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedResult, supplement.ToString());
        }

        [Test]
        public void Test_IsProduceRobotMethodNotAddingIfCapacityISFull()
        {
            factory.Capacity = 0;

            var message = factory.ProduceRobot("Stef", 50, 1234);
            string expectedMessage = "The factory is unable to produce more robots for this production day!";
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void Test_IsProduceSupplementWorkingProperly()
        {
            factory.ProduceSupplement("Protein", 12345);
            factory.ProduceSupplement("Eggs", 123456);

            var expectedResult = 2;
            var actual = factory.Supplements.Count;
            
            Assert.AreEqual(expectedResult, actual);
        }

        [Test]
        public void Test_ProduceSupplementReturnsCorrectString()
        {
            string actualString = factory.ProduceSupplement("Protein", 1234);

            string expected = "Supplement: Protein IS: 1234";

            Assert.AreEqual(expected, actualString);
        }


        [Test]
        public void Test_UpgradeRobotReturnsFalseIfRobotAlreadyHasSupplement()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            factory.Robots.First().Supplements.Add(supplement);
            var expectedResult = false;
            var actualResult = factory.UpgradeRobot(factory.Robots.First(), supplement);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_UpgradeRobotReturnsFalseIfRobotHasDifferentInterface()
        {
            factory.ProduceRobot("Stef", 50, 123);
            var expectedResult = false;
            var actualResult = factory.UpgradeRobot(factory.Robots.First(), supplement);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(!factory.Robots.First().Supplements.Contains(supplement));
        }

        [Test]
        public void Test_UpgradeRobotReturnsTrueIfSupplementIsAddedSuccessfully()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            var expectedResult = true;
            var actualResult = factory.UpgradeRobot(factory.Robots.First(), supplement);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(factory.Robots.First().Supplements.Contains(supplement));
        }

        [Test]
        public void Test_SellRobotMethodWorksProperly()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            factory.ProduceRobot("Kris", 60, 12345);

            var robotToFind = factory.Robots.First();
            var actual = factory.SellRobot(50);

            Assert.AreEqual(robotToFind, actual);
        }

        [Test]
        public void Test_SellRobotMethodReturnsNullIfNotFound()
        {
            factory.ProduceRobot("Stef", 50, 1234);
            factory.ProduceRobot("Kris", 60, 12345);

            Robot robotToFind = null;
            var actual = factory.SellRobot(0);

            Assert.AreEqual(robotToFind, actual);
        }
    }
}
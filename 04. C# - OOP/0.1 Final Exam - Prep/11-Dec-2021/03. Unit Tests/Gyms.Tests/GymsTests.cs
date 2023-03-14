using System;

namespace Gyms.Tests
{
    using NUnit.Framework;

    public class GymsTests
    {
        [TestFixture]
        public class GymTests
        {
            private Athlete athlete;
            private Gym gym;

            [SetUp]
            public void SetUp()
            {
                athlete = new Athlete("Stefan");
                gym = new Gym("GorillaGym", 5);
            }

            [Test]
            public void Test_IsAthleteConstructorWorkingProperly()
            {
                Assert.That(athlete.FullName == "Stefan" && athlete.IsInjured == false);
            }

            [Test]
            public void Test_IsAthleteNameGetterWorkingProperly()
            {
                Assert.AreEqual("Stefan", athlete.FullName);
            }

            [Test]
            public void Test_IsGymConstructorWorkingProperly()
            {
                Assert.That(gym.Name == "GorillaGym" && gym.Capacity == 5 && gym.Count == 0);
            }

            [Test]
            public void Test_IsGymNameGetterWorkingProperly()
            {
                Assert.AreEqual("GorillaGym", gym.Name);
            }

            [Test]
            public void Test_IsGymNameSetterThrowingExceptionsProperly()
            {
                Assert.Throws<ArgumentNullException>(() => { gym = new Gym("", 5);});
            }

            [Test]
            public void Test_IsGymCapacityGetterWorkingProperly()
            {
                Assert.AreEqual(5, gym.Capacity);
            }

            [Test]
            public void Test_IsGymCapacitySetterThrowingExceptionsProperly()
            {
                Assert.Throws<ArgumentException>(() => { gym = new Gym("GorillaGym", -1); });
            }

            [Test]
            public void Test_IsGymCounterWorkingProperly()
            {
                Assert.AreEqual(0, gym.Count);
            }

            [Test]
            public void Test_IsAddAthleteMethodThrowingExceptionsForFullCapacity()
            {
                gym = new Gym("GorillaGym", 0);
                Assert.Throws<InvalidOperationException>(() => { gym.AddAthlete(athlete); });
            }

            [Test]
            public void Test_IsAddAthleteMethodAddingProperly()
            {
                gym.AddAthlete(athlete);
                Assert.AreEqual(1, gym.Count);
            }

            [Test]
            public void Test_IsRemoveAthleteMethodThrowingExceptionsForMissingAthlete()
            {
                Assert.Throws<InvalidOperationException>(() => { gym.RemoveAthlete("John"); });
            }

            [Test]
            public void Test_IsRemoveAthleteMethodRemovingProperly()
            {
                gym.AddAthlete(athlete);
                gym.RemoveAthlete(athlete.FullName);
                Assert.AreEqual(0, gym.Count);
            }

            [Test]
            public void Test_IsInjureAthleteMethodThrowingExceptionsForMissingAthlete()
            {
                Assert.Throws<InvalidOperationException>(() => { gym.InjureAthlete("John"); });
            }

            [Test]
            public void Test_IsInjureAthleteMethodChangingIsInjuredValue()
            {
                gym.AddAthlete(athlete);
                gym.InjureAthlete(athlete.FullName);
                Assert.AreEqual(true, athlete.IsInjured);
            }

            [Test]
            public void Test_IsInjureAthleteMethodReturningProperly()
            {
                gym.AddAthlete(athlete);
                Assert.AreEqual(athlete, gym.InjureAthlete(athlete.FullName));
            }

            [Test]
            public void Test_ReportMethodReturnsStringProperly()
            {
                Assert.IsNotNull(gym.Report());
                Assert.IsNotEmpty(gym.Report());
            }
        }
    }
}

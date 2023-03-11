namespace PlanetWars.Models.MilitaryUnits
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost { get; private set; }
        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel <= 20) return;

            EnduranceLevel = 20;
            throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
        }
    }
}

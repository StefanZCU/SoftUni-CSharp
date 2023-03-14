namespace Gym.Models.Athletes
{
    using System;

    using Utilities.Messages;

    public class Boxer : Athlete
    {
        private const int INITIAL_STAMINA = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise()
        {
            Stamina += 15;
            if (Stamina <= 100) return;
            Stamina = 100;
            throw new ArgumentException(ExceptionMessages.InvalidStamina);
        }
    }
}

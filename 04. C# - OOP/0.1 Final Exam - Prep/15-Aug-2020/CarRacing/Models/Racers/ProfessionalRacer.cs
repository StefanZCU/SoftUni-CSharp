namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string RACING_BEHAVIOR = "strict";
        private const int DRIVING_EXPERIENCE = 30;

        public ProfessionalRacer(string username, ICar car) : base(username, RACING_BEHAVIOR, DRIVING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}

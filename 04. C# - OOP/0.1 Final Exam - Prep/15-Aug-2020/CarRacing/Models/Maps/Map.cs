namespace CarRacing.Models.Maps
{
    using Contracts;
    using Utilities.Messages;
    using CarRacing.Models.Racers.Contracts;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            var racerOneScore = racerOne.RacingBehavior switch
            {
                "strict" => racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.2,
                _ => racerOne.Car.HorsePower * racerOne.DrivingExperience * 1.1
            };

            var racerTwoScore = racerTwo.RacingBehavior switch
            {
                "strict" => racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.2,
                _ => racerTwo.Car.HorsePower * racerTwo.DrivingExperience * 1.1
            };

            return racerOneScore > racerTwoScore
                ? string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username)
                : string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }
    }
}

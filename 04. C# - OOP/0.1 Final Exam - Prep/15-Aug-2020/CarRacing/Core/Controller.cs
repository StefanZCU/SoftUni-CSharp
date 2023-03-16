namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Cars;
    using Models.Maps;
    using Repositories;
    using Models.Racers;
    using Utilities.Messages;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;

    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != nameof(TunedCar) && type != nameof(SuperCar))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            ICar car = type switch
            {
                nameof(TunedCar) => new TunedCar(make, model, VIN, horsePower),
                _ => new SuperCar(make, model, VIN, horsePower)
            };

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var carToFind = cars.FindBy(carVIN);
            if (carToFind == null) throw new ArgumentException(ExceptionMessages.CarCannotBeFound);

            if (type != nameof(ProfessionalRacer) && type != nameof(StreetRacer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            IRacer racer = type switch
            {
                nameof(ProfessionalRacer) => new ProfessionalRacer(username, carToFind),
                _ => new StreetRacer(username, carToFind)
            };
            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            var racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null || racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOne == null ? racerOneUsername : racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

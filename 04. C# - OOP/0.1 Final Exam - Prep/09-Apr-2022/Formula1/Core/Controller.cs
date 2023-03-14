namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Models;
    using Utilities;
    using Contracts;
    using Repositories;
    using Models.FormulaOneCars;
    using Formula1.Models.Contracts;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type != nameof(Ferrari) &&
                type != nameof(Williams))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            IFormulaOneCar car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                _ => new Williams(model, horsepower, engineDisplacement)
            };
            carRepository.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            var car = carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage,
                    carModel));
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.FindByName(raceName);
            var pilot = pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || pilot.CanRace == false || race.Pilots.FirstOrDefault(x => x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage,
                    pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(
                    string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var winners = race.Pilots
                .OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();

            sb
                .AppendLine(string.Format(OutputMessages.PilotFirstPlace, winners[0].FullName, raceName))
                .AppendLine(string.Format(OutputMessages.PilotSecondPlace, winners[1].FullName, raceName))
                .AppendLine(string.Format(OutputMessages.PilotThirdPlace, winners[2].FullName, raceName));

            race.TookPlace = true;
            winners[0].WinRace();
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(x => x.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

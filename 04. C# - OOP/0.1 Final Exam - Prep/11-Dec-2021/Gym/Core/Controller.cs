using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                _ => new WeightliftingGym(gymName)
            };

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != nameof(Kettlebell) && equipmentType != nameof(BoxingGloves))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment currEquipment = equipmentType switch
            {
                nameof(Kettlebell) => new Kettlebell(),
                _ => new BoxingGloves()
            };

            equipment.Add(currEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipmentToFind = equipment.FindByType(equipmentType);
            var gym = gyms.First(x => x.Name == gymName);

            if (!equipment.Remove(equipmentToFind))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,
                    equipmentType));
            }

            gym.AddEquipment(equipmentToFind);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IAthlete athlete = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
                _ => new Weightlifter(athleteName, motivation, numberOfMedals)
            };

            var gymToFind = gyms.FirstOrDefault(x => x.Name == gymName);

            switch (gymToFind.GetType().Name)
            {
                case nameof(BoxingGym) when athlete.GetType().Name == nameof(Boxer):
                case nameof(WeightliftingGym) when athlete.GetType().Name == nameof(Weightlifter):
                    gymToFind.AddAthlete(athlete);
                    break;
                default:
                    return OutputMessages.InappropriateGym;
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

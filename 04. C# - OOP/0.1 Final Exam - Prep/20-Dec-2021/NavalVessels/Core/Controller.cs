namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using NavalVessels.Models.Contracts;
    using Repositories;
    using Utilities.Messages;
    using Contracts;

    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            var captainToFind = captains.FirstOrDefault(x => x.FullName == fullName);

            if (captainToFind != null)
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(new Captain(fullName));
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType != nameof(Submarine) && 
                vesselType != nameof(Battleship))
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel vessel;
            if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captainToFind = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            var vesselToFind = vessels.FindByName(selectedVesselName);

            if (captainToFind == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if (vesselToFind == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vesselToFind.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captainToFind.AddVessel(vesselToFind);
            vesselToFind.Captain = captainToFind;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            var captainToFind = captains.First(x => x.FullName == captainFullName);

            return captainToFind.Report();
        }

        public string VesselReport(string vesselName)
        {
            var vesselToFind = vessels.FindByName(vesselName);

            return vesselToFind.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vesselToFind = vessels.FindByName(vesselName);

            switch (vesselToFind)
            { 
                case Submarine s:
                    s.ToggleSubmergeMode();
                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                case Battleship b:
                    b.ToggleSonarMode();
                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                default:
                    return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }
        public string ServiceVessel(string vesselName)
        {
            var vesselToFind = vessels.FindByName(vesselName);

            if (vesselToFind == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vesselToFind.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var firstVessel = vessels.FindByName(attackingVesselName);
            var secondVessel = vessels.FindByName(defendingVesselName);

            if (firstVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if (secondVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (firstVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            if (secondVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            firstVessel.Attack(secondVessel);
            firstVessel.Captain.IncreaseCombatExperience();
            secondVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
                secondVessel.ArmorThickness);
        }

    }
}

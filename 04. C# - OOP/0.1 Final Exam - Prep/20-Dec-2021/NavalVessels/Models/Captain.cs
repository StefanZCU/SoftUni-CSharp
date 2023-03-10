namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utilities.Messages;

    public class Captain : ICaptain
    {
        private string fullName;

        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                fullName = value;
            }
        }
        public int CombatExperience { get; private set; }
        public ICollection<IVessel> Vessels { get; private set; }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                    $"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            foreach (var vessel in Vessels)
            {
                sb.AppendLine(vessel.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

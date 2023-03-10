namespace NavalVessels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Utilities.Messages;

    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            Targets = new List<string>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            
            set => captain = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
        }
        public double ArmorThickness { get; set; }
        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets { get; private set; }
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness = 
                target.ArmorThickness - MainWeaponCaliber <= 0
                ? 0 
                : target.ArmorThickness - MainWeaponCaliber;

            Targets.Add(target.Name);
        }

        public abstract void RepairVessel();
        public virtual string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"- {Name}")
                .AppendLine($" *Type: {GetType().Name}")
                .AppendLine($" *Armor thickness: {ArmorThickness}")
                .AppendLine($" *Main weapon caliber: {MainWeaponCaliber}")
                .AppendLine($" *Speed: {Speed} knots")
                .AppendLine(Targets.Count > 0 ? $" *Targets: {string.Join(", ", Targets)}" : " *Targets: None");

            return sb.ToString().TrimEnd();
        }
    }
}

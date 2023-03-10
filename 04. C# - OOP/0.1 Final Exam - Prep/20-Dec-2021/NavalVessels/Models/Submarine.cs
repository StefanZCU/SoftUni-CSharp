namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double ARMOR_THICKNESS = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, ARMOR_THICKNESS)
        {
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            ArmorThickness = ARMOR_THICKNESS;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine(SubmergeMode ? "*Submerge mode: ON" : "*Submerge mode: OFF");

            return sb.ToString().TrimEnd();
        }
    }
}

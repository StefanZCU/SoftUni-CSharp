namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double ARMOR_THICKNESS = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, ARMOR_THICKNESS)
        {
        }
        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;

            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
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
                .AppendLine(SonarMode ? " *Sonar mode: ON" : " *Sonar mode: OFF");

            return sb.ToString().TrimEnd();
        }
    }
}

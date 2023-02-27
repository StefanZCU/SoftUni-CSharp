namespace MilitaryElite.Models
{
    using Interfaces;
    using System.Text;

    public class Repair : IRepair
    {
        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"  Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}

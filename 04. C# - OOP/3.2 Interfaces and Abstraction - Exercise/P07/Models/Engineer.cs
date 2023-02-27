namespace MilitaryElite.Models
{
    using Enums;
    using Interfaces;
    using System.Reflection;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs 
            => (IReadOnlyCollection<IRepair>)repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:F2}")
                .AppendLine($"Corps: {Corps}")
                .AppendLine("Repairs:");

            foreach (IRepair repair in repairs)
            {
                sb.AppendLine(repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

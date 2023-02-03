namespace MilitaryElite.Models
{
    using Interfaces;
    using Enums;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions
            => (IReadOnlyCollection<IMission>)missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:F2}")
                .AppendLine($"Corps: {Corps}")
                .AppendLine("Missions:");

            foreach (IMission mission in missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam => firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"First team has {firstTeam.Count} players.")
                .AppendLine($"Reserve team has {reserveTeam.Count} players.");

            return sb.ToString().TrimEnd();
        }
    }
}

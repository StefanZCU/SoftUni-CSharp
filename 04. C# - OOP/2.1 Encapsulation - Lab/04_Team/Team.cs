namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        private Team()
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public Team(string name) : this()
        {
            this.name = name;
        }

        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

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
    }
}

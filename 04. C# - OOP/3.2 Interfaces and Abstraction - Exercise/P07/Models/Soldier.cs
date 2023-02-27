namespace MilitaryElite.Models
{
    using Interfaces;

    public class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}

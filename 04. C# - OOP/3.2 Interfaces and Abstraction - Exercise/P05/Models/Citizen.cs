namespace BirthdayCelebrations.Models
{
    using Interfaces;

    public class Citizen : IIdentifiable
    {
        public Citizen(string birthday)
        {
            Birthday = birthday;
        }

        public string Birthday { get; }
    }
}

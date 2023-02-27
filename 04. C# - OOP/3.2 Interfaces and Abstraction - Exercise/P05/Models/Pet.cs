namespace BirthdayCelebrations.Models
{
    using Interfaces;
    public class Pet : IIdentifiable
    {
        public Pet(string birthday)
        {
            Birthday = birthday;
        }

        public string Birthday { get; }
    }
}

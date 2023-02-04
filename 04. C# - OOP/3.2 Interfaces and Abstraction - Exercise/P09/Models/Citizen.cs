namespace ExplicitInterfaces.Models
{
    using Interfaces;

    internal class Citizen : IPerson, IResident
    {
        public string Name { get; }
        public string Country { get; }
        public int Age { get; }

        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }


        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}

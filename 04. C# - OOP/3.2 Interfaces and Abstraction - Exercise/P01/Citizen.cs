namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; }
        public int Age { get; }
    }
}

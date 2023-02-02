
namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IPersonInfo
    {

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }
        public string Name { get; }
        public int Age { get; }
        public string ID { get; }
    }
}

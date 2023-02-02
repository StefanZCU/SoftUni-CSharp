
namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IIdentifiables
    {

        public Citizen(string name, string id)
        {
            Name = name;
            ID = id;
        }
        public string Name { get; }
        public string ID { get; }
    }
}

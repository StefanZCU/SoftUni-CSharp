namespace BorderControl.Models
{
    using Interfaces;

    internal class Robot : IIdentifiables
    {
        public string Name { get; }
        public string ID { get; }

        public Robot(string name, string id)
        {
            Name = name;
            ID = id;
        }
    }
}

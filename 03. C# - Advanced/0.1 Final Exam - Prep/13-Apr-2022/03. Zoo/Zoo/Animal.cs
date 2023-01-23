namespace Zoo
{
    public class Animal
    {
        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }

        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;
        }

        public override string ToString()
        {
            return $"The {Species} is a {Diet} and weighs {Weight} kg.";
        }
    }
}

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Animal> Animals => animals;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimals = 0;

            while (animals.FirstOrDefault(x => x.Species == species) != null)
            {
                animals.Remove(animals.FirstOrDefault(y => y.Species == species));
                removedAnimals++;
            }

            return removedAnimals;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return animals.Where(x => x.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var count = animals.Count(x => x.Length >= minimumLength && x.Length <= maximumLength);

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

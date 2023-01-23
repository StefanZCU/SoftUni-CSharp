using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public IReadOnlyCollection<Animal> Animals => this.animals;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

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

            if (Animals.Count == Capacity)
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
                var animalToRemove = animals.FirstOrDefault(x => x.Species == species);
                animals.Remove(animalToRemove);
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
            int numAnimals = 0;

            foreach (var animal in animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength))
            {
                numAnimals++;
            }

            return $"There are {numAnimals} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

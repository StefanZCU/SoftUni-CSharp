using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public int Capacity { get; set; }
        public int Count => data.Count;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (data.Count != Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var petToFind = data.FirstOrDefault(x => x.Name == name);
            if (petToFind != null)
            {
                data.Remove(petToFind);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet petToFind = null;

            foreach (var pet in data)
            {
                if (pet.Name == name && pet.Owner == owner)
                {
                    petToFind = pet;
                    break;
                }
            }

            return petToFind;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

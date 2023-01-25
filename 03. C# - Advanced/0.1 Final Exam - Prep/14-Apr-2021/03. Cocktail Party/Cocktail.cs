using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Ingredients = new List<Ingredient>();
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.FirstOrDefault(x => x.Name == ingredient.Name) != null)
            {
                return;
            }
            if (Ingredients.Count >= Capacity)
            {
                return;
            }

            if (MaxAlcoholLevel - ingredient.Alcohol < 0)
            {
                return;
            }

            Ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            var ingredientToRemove = Ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredientToRemove != null)
            {
                Ingredients.Remove(ingredientToRemove);
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredientToFind = Ingredients.FirstOrDefault(x => x.Name == name);
            return ingredientToFind;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

namespace _04_Pizza_Calories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType
        {
            get => flourType;

            set
            {
                if (value.ToLower() is not ("white" or "wholegrain"))
                {
                    throw new Exception(ExceptionMessages.InvalidDough);
                }

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => bakingTechnique;

            set
            {
                if (value.ToLower() is not ("crispy" or "chewy" or "homemade"))
                {
                    throw new Exception(ExceptionMessages.InvalidDough);
                }

                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get => weight;

            set
            {
                if (value is >200 or <1)
                {
                    throw new Exception(ExceptionMessages.WrongDoughWeight);
                }

                weight = value;
            }
        }

        public double CaloriesPerGram => GetCaloriesPerGram();

        private double GetCaloriesPerGram()
        {
            Dictionary<string, double> modifiers = new Dictionary<string, double>
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 },
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade", 1.0 }
            };
            
            var totalCalories = 2 * Weight;

            foreach (var modifier in modifiers)
            {
                if (modifier.Key == FlourType.ToLower() || modifier.Key == BakingTechnique.ToLower())
                {
                    totalCalories *= modifier.Value;
                }
            }

            return totalCalories;
        }
    }
}

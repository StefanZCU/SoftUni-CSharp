namespace P04
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;

            private set
            {
                this.ValidateType(value);

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                this.ValidateWeight(value);

                this.weight = value;
            }
        }

        public double CaloriesPerGram
            => 2 * this.Weight * this.GetTypeModifiers();

        private double GetTypeModifiers()
        {
            return this.Type.ToLower() switch
            {
                "meat" => 1.2,
                "veggies" => 0.8,
                "cheese" => 1.1,
                _ => 0.9
            };
        }

        private void ValidateType(string targetType)
        {
            if (targetType.ToLower() != "meat"
                && targetType.ToLower() != "veggies"
                && targetType.ToLower() != "cheese"
                && targetType.ToLower() != "sauce")
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.WrongToppingType,
                        targetType));
            }
        }

        private void ValidateWeight(double targetWeight)
        {
            if (targetWeight < MinWeight || targetWeight > MaxWeight)
            {
                throw new ArgumentException(
                    string.Format(
                        ExceptionMessages.WrongToppingWeight,
                        this.Type));
            }
        }
    }
}

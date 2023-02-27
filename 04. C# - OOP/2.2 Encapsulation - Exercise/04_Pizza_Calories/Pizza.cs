namespace _04_Pizza_Calories
{
    public class Pizza
    {
        private const int MaxToppingsNumber = 10;
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;

        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        private string Name
        {
            get => this.name;

            set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        private Dough Dough { get; set; }

        private double TotalCalories =>
            this.Dough.CaloriesPerGram
            + this.toppings.Sum(x => x.CaloriesPerGram);

        private int ToppingsCount => this.toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount > MaxToppingsNumber)
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidNumberOfToppings);
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

        private void ValidateName(string targetName)
        {
            if (targetName.Length is > MaxNameLength or < MinNameLength 
                || string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentException(
                    ExceptionMessages.InvalidPizzaName);
            }
        }
    }
}

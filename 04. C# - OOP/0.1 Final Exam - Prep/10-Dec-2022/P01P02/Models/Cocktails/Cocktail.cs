namespace ChristmasPastryShop.Models.Cocktails
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                
                name = value;
            }
        }

        public string Size { get; }
        public double Price
        {
            get => price;

            private set
            {
                price = Size switch
                {
                    "Middle" => (value / 3.0) * 2.0,
                    "Small" => (value / 3.0),
                    _ => value
                };
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}

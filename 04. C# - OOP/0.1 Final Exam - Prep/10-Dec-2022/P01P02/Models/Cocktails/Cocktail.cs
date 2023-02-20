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
                    "Middle" => value * (2 / 3),
                    "Small" => value * (1 / 3),
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

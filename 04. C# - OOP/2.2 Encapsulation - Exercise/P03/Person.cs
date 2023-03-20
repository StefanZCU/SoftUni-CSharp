namespace P03
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public List<Product> Products { get; }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public string AddProduct(string productName, List<Product> allProducts)
        {
            if (Money - allProducts.First(x => x.Name == productName).Cost >= 0)
            {
                Money -= allProducts.First(x => x.Name == productName).Cost;
                Products.Add(allProducts.First(x => x.Name == productName));
                return $"{Name} bought {productName}";
            }

            return $"{Name} can't afford {productName}";
        }
    }
}
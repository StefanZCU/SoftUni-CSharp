namespace _04_Pizza_Calories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var pizza = MakePizza();

                var input = Console.ReadLine();

                while (input != "END")
                {
                    var inputParts = input
                        .Split()
                        .ToArray();

                    var command = inputParts[0];

                    var toppingType = inputParts[1];
                    var weight = double.Parse(inputParts[2]);

                    var topping = new Topping(toppingType, weight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Pizza MakePizza()
        {
            var pizzaName = Console.ReadLine().Split()[1];

            var doughInfo = Console.ReadLine()
                .Split()
                .ToArray();

            var flourType = doughInfo[1];
            var bakingTechnique = doughInfo[2];
            var doughWeight = double.Parse(doughInfo[3]);

            var dough = new Dough(flourType, bakingTechnique, doughWeight);

            return new Pizza(pizzaName, dough);
        }
    }
}
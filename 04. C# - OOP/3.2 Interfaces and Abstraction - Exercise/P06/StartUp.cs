namespace P06
{
    using Models;
    using Models.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    IBuyer citizen = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]), tokens[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                buyers.FirstOrDefault(buyer => buyer.Name == input)?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
using System.Xml.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainers> allTrainers = new List<Trainers>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                bool flag = true;

                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                foreach (var trainer in allTrainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        trainer.Pokemons.Add(pokemon);
                        flag = false;
                    }   
                }

                if (flag)
                {
                    Trainers trainer = new Trainers(trainerName, new List<Pokemon>());
                    trainer.Pokemons.Add(pokemon);
                    allTrainers.Add(trainer);
                }
                
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in allTrainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        List<Pokemon> pokemonToRemove = new List<Pokemon>();

                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                pokemonToRemove.Add(pokemon);
                            }
                        }


                        foreach (var pokemon in pokemonToRemove)
                        {
                            if (trainer.Pokemons.Contains(pokemon))
                            {
                                trainer.Pokemons.Remove(pokemon);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in allTrainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Trainers
    {
        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainers(string name, List<Pokemon> pokemons)
        {
            Name = name;
            BadgesCount = 0;
            Pokemons = pokemons;
        }
    }
}

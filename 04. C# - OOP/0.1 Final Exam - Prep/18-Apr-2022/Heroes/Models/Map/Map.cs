using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Utilities.Messages;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public Map()
        {
            
        }
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(x => x.GetType().Name == nameof(Knight)).ToList();
            var barbarians = players.Where(x => x.GetType().Name == nameof(Barbarian)).ToList();

            while (knights.Any(x => x.IsAlive) && barbarians.Any(x => x.IsAlive))
            {
                foreach (var knight in knights.Where(x => x.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians.Where(x => x.IsAlive))
                {
                    foreach (var knight in knights.Where(x => x.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            return knights.Any(x => x.IsAlive)
                ? string.Format(OutputMessages.KnightsWon, knights.Count(x => x.IsAlive == false))
                : string.Format(OutputMessages.BarbariansWon, barbarians.Count(x => x.IsAlive == false));
        }
    }
}

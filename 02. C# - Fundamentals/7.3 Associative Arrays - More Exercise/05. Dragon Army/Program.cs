using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, SortedDictionary<string, int[]>>();
            var countOfDragon = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfDragon; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var type = tokens[0];
                var nameOfDragon = tokens[1];
                var damage = 0;
                var health = 0;
                var armor = 0;

                damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (!data.ContainsKey(type))
                {
                    data.Add(type, new SortedDictionary<string, int[]>());
                }

                if (!data[type].ContainsKey(nameOfDragon))
                {
                    data[type][nameOfDragon] = new int[3];
                }

                data[type][nameOfDragon][0] = damage;
                data[type][nameOfDragon][1] = health;
                data[type][nameOfDragon][2] = armor;
            }

            foreach (var outerKvp in data)
            {
                Console.WriteLine($"{outerKvp.Key}::({outerKvp.Value.Select(x => x.Value[0]).Average():f2}/{outerKvp.Value.Select(x => x.Value[1]).Average():f2}/{outerKvp.Value.Select(x => x.Value[2]).Average():f2})");

                foreach (var innerKvp in outerKvp.Value)
                {
                    Console.WriteLine($"-{innerKvp.Key} -> damage: {innerKvp.Value[0]}, health: {innerKvp.Value[1]}, armor: {innerKvp.Value[2]}");
                }
            }
        }
    }
}




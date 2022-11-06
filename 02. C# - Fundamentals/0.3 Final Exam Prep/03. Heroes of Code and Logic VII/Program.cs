using System;
using System.Collections.Generic;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    public class HPMP
    {
        public int HP { get; set; }
        public int MP { get; set; }

        public HPMP(int hp, int mp)
        {
            HP = hp;
            MP = mp;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numHeroes = int.Parse(Console.ReadLine());

            Dictionary<string, HPMP> heroes = new Dictionary<string, HPMP>();
            List<string> heroesToRemove = new List<string>();

            for (int i = 0; i < numHeroes; i++)
            {
                string[] heroInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroInput[0];
                int HP = int.Parse(heroInput[1]);
                int MP = int.Parse(heroInput[2]);

                HPMP hpmp = new HPMP(HP, MP);
                
                heroes.Add(heroName, hpmp);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string cmdArgs = input[0];

                if (cmdArgs == "CastSpell")
                {
                    string heroName = input[1];
                    int MPNeeded = int.Parse(input[2]);
                    string spellName = input[3];

                    if (heroes[heroName].MP < MPNeeded)
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                    else
                    {
                        heroes[heroName].MP -= MPNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                    }
                }
                else if (cmdArgs == "TakeDamage")
                {
                    string heroName = input[1];
                    int damage = int.Parse(input[2]);
                    string attacker = input[3];

                    if (heroes[heroName].HP - damage > 0 && !heroesToRemove.Contains(heroName))
                    {
                        heroes[heroName].HP -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else if (!heroesToRemove.Contains(heroName))
                    {
                        heroesToRemove.Add(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (cmdArgs == "Recharge")
                {
                    string heroName = input[1];
                    int rechargeMP = int.Parse(input[2]);

                    if (heroes[heroName].MP + rechargeMP <= 200)
                    {
                        heroes[heroName].MP += rechargeMP;
                        Console.WriteLine($"{heroName} recharged for {rechargeMP} MP!");
                    }
                    else
                    {
                        int newRechargeMP = 200 - heroes[heroName].MP;
                        heroes[heroName].MP = 200;
                        Console.WriteLine($"{heroName} recharged for {newRechargeMP} MP!");
                    }
                }
                else if (cmdArgs == "Heal")
                {
                    string heroName = input[1];
                    int healHP = int.Parse(input[2]);

                    if (heroes[heroName].HP + healHP <= 100)
                    {
                        heroes[heroName].HP += healHP;
                        Console.WriteLine($"{heroName} healed for {healHP} HP!");
                    }
                    else
                    {
                        int newHealHP = 100 - heroes[heroName].HP;
                        heroes[heroName].HP = 100;
                        Console.WriteLine($"{heroName} healed for {newHealHP} HP!");
                    }
                }
            }

            foreach (var hero in heroesToRemove)
            {
                heroes.Remove(hero);
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
}

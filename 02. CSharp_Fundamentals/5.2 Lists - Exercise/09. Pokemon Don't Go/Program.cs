using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonSequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            while (true)
            {
                int currentIndex = int.Parse(Console.ReadLine());

                int currentNum;
                

                if (currentIndex < 0)
                {
                    currentNum = pokemonSequence[0];
                    sum += currentNum;
                    pokemonSequence.RemoveAt(0);
                    pokemonSequence.Insert(0, pokemonSequence[pokemonSequence.Count - 1]);

                    for (int i = 0; i < pokemonSequence.Count; i++)
                    {
                        if (pokemonSequence[i] <= currentNum)
                        {
                            pokemonSequence[i] += currentNum;
                        }
                        else if (pokemonSequence[i] > currentNum)
                        {
                            pokemonSequence[i] -= currentNum;
                        }
                    }

                }
                else if (currentIndex >= pokemonSequence.Count)
                {
                    currentNum = pokemonSequence[pokemonSequence.Count - 1];
                    sum += currentNum;
                    pokemonSequence.RemoveAt(pokemonSequence.Count - 1);
                    pokemonSequence.Add(pokemonSequence[0]);

                    for (int i = 0; i < pokemonSequence.Count; i++)
                    {
                        if (pokemonSequence[i] <= currentNum)
                        {
                            pokemonSequence[i] += currentNum;
                        }
                        else if (pokemonSequence[i] > currentNum)
                        {
                            pokemonSequence[i] -= currentNum;
                        }
                    }
                }
                else
                {

                    currentNum = pokemonSequence[currentIndex];
                    sum += currentNum;
                    pokemonSequence.RemoveAt(currentIndex);

                    for (int i = 0; i < pokemonSequence.Count; i++)
                    {
                        if (pokemonSequence[i] <= currentNum)
                        {
                            pokemonSequence[i] += currentNum;
                        }
                        else if (pokemonSequence[i] > currentNum)
                        {
                            pokemonSequence[i] -= currentNum;
                        }
                    }
                }

                if (pokemonSequence.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}

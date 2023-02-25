using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalInfo[0] != "Beast!")
                {
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    try
                    {
                        Animal animal = command switch
                        {
                            "Dog" => new Dog(name, age, gender),
                            "Cat" => new Cat(name, age, gender),
                            "Frog" => new Frog(name, age, gender),
                            "Tomcat" => new Tomcat(name, age),
                            "Kitten" => new Kitten(name, age),
                            _ => null
                        };

                        if (animal != null)
                        {
                            animals.Add(animal);
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    break;
                }

                
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal);
                animal.ProduceSound();
            }
        }
    }
}

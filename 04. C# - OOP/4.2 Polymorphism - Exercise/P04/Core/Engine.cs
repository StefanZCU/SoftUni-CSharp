namespace WildFarm.Core
{
    using Exceptions;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;
    using Interface;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public Engine()
        {
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                string[] animalInfo = command.Split();
                command = reader.ReadLine();
                string[] foodInfo = command.Split(" ");
                try
                {
                    FoodChecker(foodInfo, AnimalCreator(animalInfo));
                }
                catch (InvalidTypeOfFoodForAnimal itoffa)
                {
                    Console.WriteLine(itoffa.Message);
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private IAnimal AnimalCreator(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            IAnimal animal = null;
            switch (type)
            {
                case "Owl":
                    animal = new Owl(name, weight, 0, double.Parse(animalInfo[3]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, 0, double.Parse(animalInfo[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, 0, animalInfo[3]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, 0, animalInfo[3]);
                    break;
                case "Cat":
                    animal = new Cat(name, weight, 0, animalInfo[3], animalInfo[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, 0, animalInfo[3], animalInfo[4]);
                    break;
            }

            writer.WriteLine(animal.ProduceSound());
            animals.Add(animal);
            return animal;
        }

        private void FoodChecker(string[] foodInfo, IAnimal animal)
        {
            string food = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (animal.CheckIfAnimalWillEat(food))
            {
                animal.WeightIncreaser(quantity);
                animal.QuantityIncreaser(quantity);
            }
            else
            {
                throw new InvalidTypeOfFoodForAnimal(string.Format(ExceptionMessages.InvalidTypeOfFoodForAnimal,
                    animal.GetType().Name, food));
            }
        }
    }
}
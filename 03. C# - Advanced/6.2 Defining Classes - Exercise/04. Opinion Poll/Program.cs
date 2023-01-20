namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int numCycles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCycles; i++)
            {
                string[] currPerson = Console.ReadLine().Split();

                Person person = new Person(currPerson[0], int.Parse(currPerson[1]));
                people.Add(person);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
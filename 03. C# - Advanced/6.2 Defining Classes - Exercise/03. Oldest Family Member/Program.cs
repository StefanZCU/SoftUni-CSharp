namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numCycle = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < numCycle; i++)
            {
                string[] member = Console.ReadLine().Split();

                Person person = new Person(member[0], int.Parse(member[1]));

                family.AddMember(person);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
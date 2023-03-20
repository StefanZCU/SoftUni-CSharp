namespace Person
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                Person person = new(name, age);

                Console.WriteLine(person);
            }
            else
            {
                Child child = new(name, age);

                Console.WriteLine(child);
            }
        }
    }
}
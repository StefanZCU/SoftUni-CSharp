using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _02._Oldest_Family_Member
{
    class Family
    {
        public List<Person> PartOfFamily { get; set; }

        public void AddMember(Person member)
        {
            PartOfFamily.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.PartOfFamily.OrderByDescending(x => x.Age).First();
        }

        public Family()
        {
            this.PartOfFamily = new List<Person>();
        }
    }

    class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numInputs = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numInputs; i++)
            {
                string[] familyMember = Console.ReadLine().Split();

                string name = familyMember[0];
                int age = int.Parse(familyMember[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Channels;

//namespace _02._Oldest_Family_Member
//{
//    public class Person
//    {
//        public string Name { get; set; }

//        public int Age { get; set; }

//        public Person()
//        {
//            this.Name = "No Name";
//            this.Age = 0;
//        }


//        public Person(string name, int age)
//        {
//            this.Name = name;
//            this.Age = age;
//        }
//    }

//    public class Family
//    {
//        List<Person> People { get; set; }

//        public void AddMember(Person person)
//        {
//            People.Add(person);
//        }

//        public Person GetOldestMember()
//        {
//            return this.People.OrderByDescending(x => x.Age).FirstOrDefault();
//        }

//        public Family()
//        {
//            this.People = new List<Person>();
//        }
//    }

//    internal class Program
//    {
//        static void Main()
//        {
//            Family thisFamily = new Family();
//            int numberOfMembers = int.Parse(Console.ReadLine());
//            for (int i = 0; i < numberOfMembers; i++)
//            {
//                string[] input = Console.ReadLine().Split();
//                Person person = new Person(input[0], int.Parse(input[1]));
//                thisFamily.AddMember(person);
//            }
//            Person oldestMember = thisFamily.GetOldestMember();
//            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
//        }
//    }
//}


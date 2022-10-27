using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.PersonAge = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int PersonAge { get; set; }
    }

    class PeopleList
    {
        public List<Person> People { get; set; } = new List<Person>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PeopleList people = new PeopleList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split();
                
                string name = input[0];
                string id = input[1];
                int age = int.Parse(input[2]);
                
                if (people.People.Any(y => y.ID == id))
                {
                    var objChange = people.People.Find(x => x.ID == id);

                    objChange.Name = name;
                    objChange.PersonAge = age;
                }
                else
                {
                    Person currentPerson = new Person(name, id, age);

                    people.People.Add(currentPerson);
                }
            }

            var orderedList = people.People.OrderBy(x => x.PersonAge);

            foreach (var person in orderedList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.PersonAge} years old.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public  class Person
    {
        public string Name { get; set; } = default!;
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;  
        }
    }
}

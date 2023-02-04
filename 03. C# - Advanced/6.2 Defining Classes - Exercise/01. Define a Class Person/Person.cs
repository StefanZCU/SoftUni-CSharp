using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public  class Person
    {

        private string name;
        private int age;
        private string mm;
        private string aa;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TheRace
{
    public class Racer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public Car Car { get; set; }

        public Racer(string name, int age, string country, Car car)
        {
            Name = name;
            Age = age;
            Country = country;
            Car = car; 
        }

        public override string ToString()
        {
            return $"Racer: {Name}, {Age} ({Country})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Tires
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tires(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}

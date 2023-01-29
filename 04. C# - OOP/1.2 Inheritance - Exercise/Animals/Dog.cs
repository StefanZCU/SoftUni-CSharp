using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Dog : Animals
    {
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}

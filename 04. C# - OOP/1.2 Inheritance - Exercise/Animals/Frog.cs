using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Frog : Animals
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}

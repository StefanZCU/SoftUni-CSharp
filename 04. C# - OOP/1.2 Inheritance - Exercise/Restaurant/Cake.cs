using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, cakePrice, cakeGrams, cakeCalories)
        {
            Name = name;
        }

        private const double cakeGrams = 250;
        private const double cakeCalories = 1000;
        private const decimal cakePrice = 5.0m;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random = new Random();

        public string RandomString()
        {
            var index = random.Next(0, Count);
            string element = this[index];
            RemoveAt(index);
            return element;
        }
    }
}

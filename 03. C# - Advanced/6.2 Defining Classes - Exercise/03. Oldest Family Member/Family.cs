using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Members { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            return Members.OrderByDescending(x => x.Age).First();
        }

    }
}

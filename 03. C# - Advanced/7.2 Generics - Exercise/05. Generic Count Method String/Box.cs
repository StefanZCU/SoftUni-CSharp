using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
    public class Box
    {
        public int ComparisonChecker<T>(T comparer , List<T> elements) where T : IComparable
        {
            int differences = 0;

            foreach (var element in elements)
            {
                if (element.CompareTo(comparer) > 0)
                {
                    differences++;
                }
            }

            return differences;
        }
    }
}

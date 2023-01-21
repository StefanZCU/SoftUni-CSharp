using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodString
{
    public class Box
    {
        public List<T> SwapMethod<T>(int indexOne, int indexTwo, List<T> elements)
        {
            (elements[indexOne], elements[indexTwo]) = (elements[indexTwo], elements[indexOne]);

            return elements;
        }
    }
}

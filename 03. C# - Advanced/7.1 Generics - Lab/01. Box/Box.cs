using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> Elements { get; set; }
        public int Count => this.Elements.Count;

        public Box()
        {
            Elements = new List<T>();
        }

        public void Add(T element)
        {
            Elements.Add(element);
        }

        public T Remove()
        {
            var lastItem = Elements.Last();
            Elements.RemoveAt(Elements.Count - 1);
            return lastItem;
        }

    }
}

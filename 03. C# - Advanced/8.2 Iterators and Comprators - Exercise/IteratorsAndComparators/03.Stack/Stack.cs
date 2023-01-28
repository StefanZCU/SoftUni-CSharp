using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            elements = new List<T>();
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            elements.Add(item);
        }

        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T removedElement = elements[^1];
            elements.Remove(elements[^1]);

            return removedElement;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

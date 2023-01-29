using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (Count != 0)
            {
                return false;
            }

            return true;
        }

        public Stack<string> AddRange()
        {
            List<string> list = new List<string>();
            list.AddRange(this.ToList());
            Stack<string> stack = new Stack<string>();

            foreach (var item in list)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count == 0;

        public Stack<string> AddRange()
        {
            List<string> list = new List<string>();
            list.AddRange(this.ToList());
            Stack<string> stack = new Stack<string>();

            foreach (var element in list)
            {
                stack.Push(element);
            }

            return stack;
        }
    }
}

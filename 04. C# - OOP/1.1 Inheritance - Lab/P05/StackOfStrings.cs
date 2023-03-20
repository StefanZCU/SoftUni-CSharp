namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public Stack<string> AddRange()
        {
            List<string> newList = new List<string>();
            newList.AddRange(this);
            Stack<string> newStack = new Stack<string>();
            foreach (var VARIABLE in newList)
            {
                newStack.Push(VARIABLE);
            }
            return newStack;
        }
    }
}

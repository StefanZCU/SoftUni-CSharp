string expression = Console.ReadLine();

Stack<int> openBracketIndex = new Stack<int>();

for (int i = 0; i < expression.Length; i++)
{
    if (expression[i] == '(')
    {
        openBracketIndex.Push(i);
    }
    else if (expression[i] == ')')
    {
        int openBracket = openBracketIndex.Pop();

        Console.WriteLine(expression.Substring(openBracket, i - openBracket + 1));
    }
}




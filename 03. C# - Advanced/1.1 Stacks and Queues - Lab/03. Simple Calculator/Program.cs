string[] expressionString = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Stack<string> expression = new Stack<string>(expressionString.Reverse());

while (expression.Count != 1)
{
    int num = int.Parse(expression.Pop());
    char symbol = char.Parse(expression.Pop());
    int num2 = int.Parse(expression.Pop());

    if (symbol == '-')
    {
        expression.Push((num - num2).ToString());
    }
    else
    {
        expression.Push((num + num2).ToString());        
    }
}

Console.WriteLine(expression.Pop());
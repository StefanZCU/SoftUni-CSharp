string line = Console.ReadLine();
Stack<char> openParenthesis = new Stack<char>();
bool flag = true;

foreach (var character in line)
{
    if (character == '(' || character == '{' || character == '[')
    {
        openParenthesis.Push(character);
        continue;
    }

    if (openParenthesis.Count != 0)
    {
        if ((character == ')' && openParenthesis.Peek() == '(') 
            || (character == '}' && openParenthesis.Peek() == '{')
            || (character == ']' && openParenthesis.Peek() == '['))
        {
            openParenthesis.Pop();
        }
        else
        {
            Console.WriteLine("NO");
            flag = false;
            break;
        }
    }
    else
    {
        Console.WriteLine("NO");
        flag = false;
        break;
    }
}

if (flag && openParenthesis.Count == 0)
{
    Console.WriteLine("YES");
}

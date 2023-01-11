using System.Text;

int numOperations = int.Parse(Console.ReadLine());

Stack<string> stringVersions = new Stack<string>();
StringBuilder sb = new StringBuilder();
stringVersions.Push(sb.ToString());

for (int i = 0; i < numOperations; i++)
{
    string[] command = Console.ReadLine().Split();

    if (command[0] == "1")
    {
        sb.Append(command[1]);
        stringVersions.Push(sb.ToString());
    }
    else if (command[0] == "2")
    {
        sb.Remove(sb.Length - int.Parse(command[1]), int.Parse(command[1]));
        stringVersions.Push(sb.ToString());

    }
    else if (command[0] == "3")
    {
        Console.WriteLine(sb.ToString().Substring(int.Parse(command[1]) - 1, 1));
    }
    else if (command[0] == "4")
    {
        sb.Clear();
        stringVersions.Pop();
        sb.Append(stringVersions.Peek());
    }
}

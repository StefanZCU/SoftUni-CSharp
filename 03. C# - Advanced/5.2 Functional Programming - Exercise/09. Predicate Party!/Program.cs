List<string> names = Console.ReadLine().Split().ToList();

string command;
while ((command = Console.ReadLine()) != "Party!")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string action = input[0];
    string criteria = input[1];
    string value = input[2];

    if (action == "Remove")
    {
        switch (criteria)
        {
            case "StartsWith":

                Manipulator(action, names, x => x.Substring(0, value.Length) == value);

                break;

            case "EndsWith":

                Manipulator(action, names, x => x.Substring(x.Length - value.Length, value.Length) == value);

                break;

            case "Length":

                Manipulator(action, names, x => x.Length == int.Parse(value));

                break;
        }
    }
    else if (action == "Double")
    {
        switch (criteria)
        {
            case "StartsWith":

                Manipulator(action, names, x => x.Substring(0, value.Length) == value);

                break;

            case "EndsWith":

                Manipulator(action, names, x => x.Substring(x.Length - value.Length, value.Length) == value);

                break;

            case "Length":

                Manipulator(action, names, x => x.Length == int.Parse(value));

                break;
        }
    }
}

Console.WriteLine(names.Count != 0
    ? $"{string.Join(", ", names)} are going to the party!"
    : "Nobody is going to the party!");


void Manipulator(string action, List<string> names, Predicate<string> op)
{
    if (action == "Remove")
    {
        names.RemoveAll(op);
    }
    else
    {
        for (int i = 0; i < names.Count; i++)
        {
            if (op(names[i]))
            {
                names.Insert(i, names[i]);
                i++;
            }
        }
    }
}


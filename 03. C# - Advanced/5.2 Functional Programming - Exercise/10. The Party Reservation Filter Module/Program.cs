using System;

List<string> originalNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

List<string> filteredList = new List<string>();

foreach (var name in originalNames)
{
    filteredList.Add(name);
}

string command;
while ((command = Console.ReadLine()) != "Print")
{
    string[] PRFM = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

    string cmdArg = PRFM[0];
    string filterType = PRFM[1];
    string filterParameter = PRFM[2];

    switch (filterType)
    {
        case "Starts with":
            Manipulator(cmdArg, filteredList, originalNames, x => x.Substring(0, filterParameter.Length) == filterParameter);
            break;

        case "Ends with":
            Manipulator(cmdArg, filteredList, originalNames, x => x.Substring(x.Length - filterParameter.Length, filterParameter.Length) == filterParameter);
            break;

        case "Length":
            Manipulator(cmdArg, filteredList, originalNames, x => x.Length == int.Parse(filterParameter));
            break;

        case "Contains":
            Manipulator(cmdArg, filteredList, originalNames, x => x.Contains(filterParameter));
            break;
    }
}

Console.WriteLine(string.Join(" ", filteredList));

void Manipulator(string command, List<string> names, List<string> originalNames, Predicate<string> op)
{
    if (command == "Add filter")
    {
        names.RemoveAll(op);
    }
    else if (command == "Remove filter")
    {
        for (int i = 0; i < originalNames.Count; i++)
        {
            if (op(originalNames[i]))
            {
                names.Insert(i, originalNames[i]);
            }
        }
    }
}
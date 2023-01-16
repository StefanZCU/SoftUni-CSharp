Dictionary<string, List<string>> usersPerForce = new Dictionary<string, List<string>>();

string command;
while((command = Console.ReadLine()) != "Lumpawaroo")
{
    if (command.Contains('|'))
    {
        string[] input = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string forceSide = input[0];
        string forceUser = input[1];
        bool flag = true;

        foreach (var force in usersPerForce)
        {
            if (force.Value.Contains(forceUser))
            {
                if (!usersPerForce.ContainsKey(forceSide))
                {
                    usersPerForce.Add(forceSide, new List<string>());
                }

                flag = false;
                break;
            }
        }

        if (flag)
        {
            if (!usersPerForce.ContainsKey(forceSide))
            {
                usersPerForce.Add(forceSide, new List<string>());
            }

            usersPerForce[forceSide].Add(forceUser);
        }
    }
    else if (command.Contains("->"))
    {
        string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string forceUser = input[0];
        string forceSide = input[1];
        bool flag = true;

        foreach (var force in usersPerForce)
        {
            if (force.Value.Contains(forceUser))
            {
                if (!usersPerForce.ContainsKey(forceSide))
                {
                    usersPerForce.Add(forceSide, new List<string>());
                }

                usersPerForce[forceSide].Add(forceUser);
                usersPerForce[force.Key].Remove(forceUser);
                flag = false;
                break;
            }
        }

        if (flag)
        {
            if (!usersPerForce.ContainsKey(forceSide))
            {
                usersPerForce.Add(forceSide, new List<string>());
            }

            usersPerForce[forceSide].Add(forceUser);
        }

        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
}

foreach (var force in usersPerForce.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
{
    if (force.Value.Count != 0)
    {
        Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");

        foreach (var user in force.Value.OrderBy(x => x))
        {
            Console.WriteLine($"! {user}");
        }
    }
}
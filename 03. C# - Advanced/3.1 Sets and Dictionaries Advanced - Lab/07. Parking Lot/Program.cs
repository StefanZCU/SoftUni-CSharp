HashSet<string> licensePlates = new HashSet<string>();
string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    if (input[0] == "IN")
    {
        licensePlates.Add(input[1]);
    }
    else if (input[0] == "OUT")
    {
        licensePlates.Remove(input[1]);
    }
}

if (licensePlates.Count != 0)
{
    foreach (var licensePlate in licensePlates)
    {
        Console.WriteLine(licensePlate);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}
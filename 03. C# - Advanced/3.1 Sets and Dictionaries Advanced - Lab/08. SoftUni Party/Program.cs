HashSet<string> VIPGuests = new HashSet<string>();
HashSet<string> regularGuests = new HashSet<string>();

string command;
while ((command = Console.ReadLine()) != "PARTY")
{
    if (char.IsDigit(command[0]))
    {
        VIPGuests.Add(command);
    }
    else
    {
        regularGuests.Add(command);
    }
}

while ((command = Console.ReadLine()) != "END")
{
    if (VIPGuests.Contains(command))
    {
        VIPGuests.Remove(command);
    }
    else if (regularGuests.Contains(command))
    {
        regularGuests.Remove(command);
    }
}

Console.WriteLine(VIPGuests.Count + regularGuests.Count);

foreach (var vipGuest in VIPGuests)
{
    Console.WriteLine(vipGuest);
}

foreach (var regularGuest in regularGuests)
{
    Console.WriteLine(regularGuest);
}
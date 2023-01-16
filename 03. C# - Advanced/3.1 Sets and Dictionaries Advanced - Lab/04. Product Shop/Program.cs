Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();

string command;
while ((command = Console.ReadLine()) != "Revision")
{
    string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    if (!stores.ContainsKey(input[0]))
    {
        stores.Add(input[0], new Dictionary<string, double>());
    }

    if (!stores[input[0]].ContainsKey(input[1]))
    {
        stores[input[0]].Add(input[1], double.Parse(input[2]));
    }
}

foreach (var store in stores.OrderBy(x => x.Key))
{
    Console.WriteLine($"{store.Key}->");

    foreach (var product in store.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}
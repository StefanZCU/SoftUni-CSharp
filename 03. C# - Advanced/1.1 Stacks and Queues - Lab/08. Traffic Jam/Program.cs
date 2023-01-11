int numCarsToPass = int.Parse(Console.ReadLine());
int carsPassed = 0;

Queue<string> carsInLine = new Queue<string>();

string command;
while ((command = Console.ReadLine()) != "end")
{
    if (command != "green")
    {
        carsInLine.Enqueue(command);
    }
    else
    {
        for (int i = 0; i < numCarsToPass; i++)
        {
            if (carsInLine.Count != 0)
            {
                Console.WriteLine($"{carsInLine.Dequeue()} passed!");
                carsPassed++;
            }
        }
    }
}

Console.WriteLine($"{carsPassed} cars passed the crossroads.");

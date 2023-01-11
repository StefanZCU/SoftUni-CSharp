
int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());
Queue<string> carsInLine = new Queue<string>();

string command;
while ((command = Console.ReadLine()) != "END")
{
    if (command != "green")
    {
        carsInLine.Enqueue(command);
    }
    else
    {
        string currentCar = carsInLine.Dequeue();

        for (int i = 0; i < greenLightDuration; i++)
        {
            
        }
    }
}

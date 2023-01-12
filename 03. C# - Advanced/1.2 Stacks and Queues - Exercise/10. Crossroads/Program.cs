
int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());
Queue<string> carsInLine = new Queue<string>();

int carsPassed = 0;
string passingCar = String.Empty;

string command;

while ((command = Console.ReadLine()) != "END")
{
    if (command != "green")
    {
        carsInLine.Enqueue(command);
    }
    else if (command == "green" && carsInLine.Count != 0)
    {
        passingCar = carsInLine.Peek();
        string currentCar = carsInLine.Dequeue();

        for (int i = 0; i < greenLightDuration; i++) // green light duration
        {
            if (currentCar.Length != 0)
            {
                currentCar = currentCar.Remove(0, 1);
            }
            else
            {
                carsPassed++;

                if (carsInLine.Count != 0)
                {
                    passingCar = carsInLine.Peek();
                    currentCar = carsInLine.Dequeue();
                    currentCar = currentCar.Remove(0, 1);
                }
                else
                {
                    break;
                }
            }

        }

        if (currentCar.Length != 0)
        {
            for (int i = 0; i < freeWindowDuration; i++) // free window
            {
                if (currentCar.Length != 0)
                {
                    currentCar = currentCar.Remove(0, 1);
                }
                else
                {
                    carsPassed++;
                    break;
                }
            }

            if (currentCar.Length != 0)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{passingCar} was hit at {currentCar[0]}.");
                return;
            }
        }
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

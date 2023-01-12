
int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());
Queue<string> carsInLine = new Queue<string>();

int carsPassed = 0;
bool flag = true;

string command;
while ((command = Console.ReadLine()) != "END")
{
    if (command == "green" && carsInLine.Count != 0)
    {
        string passingCar = carsInLine.Peek();
        string currentCar = carsInLine.Dequeue();

        for (int i = 0; i < greenLightDuration; i++) // green light duration
        {
            if (currentCar.Length != 0)
            {
                flag = true;
                currentCar = currentCar.Remove(0, 1);
            }
            else
            {
                carsPassed++;
                flag = false;

                if (carsInLine.Count != 0)
                {
                    passingCar = carsInLine.Peek();
                    currentCar = carsInLine.Dequeue();
                    currentCar = currentCar.Remove(0, 1);
                    flag = true;
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
        
        if (flag)
        {
            carsPassed++;
        }
    }
    else
    {
        carsInLine.Enqueue(command);
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

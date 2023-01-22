int matrixSize = int.Parse(Console.ReadLine());
string racerName = Console.ReadLine();
char[,] matrix = new char[matrixSize, matrixSize];

int[] position = { 0, 0 };
int distanceTraveled = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = line[j];
    }
}

bool flag = true;
string command;
while ((command = Console.ReadLine()) != "End")
{
    switch (command)
    {
        case "up":
            position[0]--;
            break;
        case "down":
            position[0]++;
            break;
        case "right":
            position[1]++;
            break;
        case "left":
            position[1]--;
            break;
    }

    distanceTraveled += 10;

    int row = position[0];
    int col = position[1];

    if (matrix[row, col] == 'F')
    {
        Console.WriteLine($"Racing car {racerName} finished the stage!");
        flag = false;
        break;
    }

    if (matrix[row, col] == 'T')
    {
        matrix[row, col] = '.';
        distanceTraveled += 20;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'T')
                {
                    matrix[i, j] = '.';
                    position[0] = i;
                    position[1] = j;
                    break;
                }
            }
        }
    }
}

if (flag)
{
    Console.WriteLine($"Racing car {racerName} DNF.");
}

Console.WriteLine($"Distance covered {distanceTraveled} km.");
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (position[0] == i && position[1] == j)
        {
            matrix[i, j] = 'C';
        }

        Console.Write(matrix[i, j]);
    }

    Console.WriteLine();
}
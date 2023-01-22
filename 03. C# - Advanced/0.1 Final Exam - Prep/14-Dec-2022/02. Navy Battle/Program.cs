using System.Data;

int matrixSize = int.Parse(Console.ReadLine());

char[,] matrix = new char[matrixSize, matrixSize];

int[] position = new int[2];
int destroyedCruisers = 0;
int minesHit = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string line = Console.ReadLine();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = line[j];

        if (matrix[i, j] == 'S')
        {
            position[0] = i;
            position[1] = j;
            matrix[i, j] = '-';
        }
    }
}

while (true)
{
    string command = Console.ReadLine();

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

    int row = position[0];
    int col = position[1];

    if (matrix[row, col] == '*')
    {
        minesHit++;

        if (minesHit == 3)
        {
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{row}, {col}]!");
            break;
        }

        matrix[row, col] = '-';
    }

    if (matrix[row, col] == 'C')
    {
        destroyedCruisers++;

        if (destroyedCruisers == 3)
        {
            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            break;
        }

        matrix[row, col] = '-';
    }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i == position[0] && j == position[1])
        {
            matrix[i, j] = 'S';
        }

        Console.Write(matrix[i, j]);
    }

    Console.WriteLine();
}

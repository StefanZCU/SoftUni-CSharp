int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = cols[j];
    }
}

string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < bombs.Length; i++)
{
    int[] bombCoords = bombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    BombExploder(matrix, bombCoords[0], bombCoords[1]);
}

int sum = 0, aliveCells = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
        {
            sum += matrix[i, j];
            aliveCells++;
        }
    }
}

Console.WriteLine($"Alive cells: {aliveCells}");
Console.WriteLine($"Sum: {sum}");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]} ");
    }

    Console.WriteLine();
}

int[,] BombExploder(int[,] matrix, int row, int col)
{
    if (matrix[row, col] > 0)
    {
        int explosionAmt = matrix[row, col];
        matrix[row, col] = 0;

        int[,] directions =
        {
            { row - 1, col - 1 },
            { row - 1, col },
            { row - 1, col + 1 },
            { row, col - 1 },
            { row, col + 1 },
            { row + 1, col - 1 },
            { row + 1, col },
            { row + 1, col + 1 }
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            if (IndexChecker(matrix, directions[i, 0], directions[i, 1]) && matrix[directions[i, 0], directions[i, 1]] > 0)
            {
                matrix[directions[i, 0], directions[i, 1]] -= explosionAmt;
            }
        }
    }

    return matrix;
}

bool IndexChecker(int[,] matrix, int row, int col)
{
    return row >= 0 && row < matrix.GetLength(0) &&
           col >= 0 && col < matrix.GetLength(1);
}
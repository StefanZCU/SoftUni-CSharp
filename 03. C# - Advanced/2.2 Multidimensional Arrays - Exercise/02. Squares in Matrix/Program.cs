int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

char[,] matrix = new char[matrixSize[0], matrixSize[1]];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    char[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i,j] = cols[j];
    }
}

int sum = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i + 1 < matrix.GetLength(0) && j + 1 < matrix.GetLength(1))
        {
            char currentSymbol = matrix[i, j];

            if (matrix[i + 1, j] == currentSymbol && matrix[i, j + 1] == currentSymbol &&  matrix[i + 1, j + 1] == currentSymbol)
            {
                sum++;
            }
        }
    }
}

Console.WriteLine(sum);
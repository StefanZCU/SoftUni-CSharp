int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] matrix = new char[matrixSize[0], matrixSize[1]];

int[] playerPos = new int[2];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string line = Console.ReadLine();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = line[j];

        if (line[j] == 'P')
        {
            playerPos[0] = i;
            playerPos[1] = j;
        }
    }
}

string directions = Console.ReadLine();
int[] newPlayerPos = new int[2];
char[,] bunnyMatrix = matrix;
bool flag = false;

for (int i = 0; i < directions.Length; i++)
{
    newPlayerPos = PlayerMover(directions[i], playerPos, newPlayerPos);

    if (newPlayerPos[0] < 0 || newPlayerPos[0] >= matrix.GetLength(0) ||
        newPlayerPos[1] < 0 || newPlayerPos[1] >= matrix.GetLength(1))
    {
        BoardPrinter(flag, matrix, bunnyMatrix);
        Console.WriteLine($"won: {playerPos[0]} {playerPos[1]}");
        return;
    }

    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            if (matrix[j, k] == 'B')
            {
                int[,] bunnyMoves =
                {
                    { j - 1, k },
                    { j + 1, k },
                    { j, k - 1 },
                    { j, k + 1 }
                };

                for (int l = 0; l < bunnyMoves.GetLength(0); l++)
                {
                    if (IndexChecker(matrix, bunnyMoves[l, 0], bunnyMoves[l, 1]))
                    {
                        if (matrix[bunnyMoves[l, 0], bunnyMoves[l, 1]] == 'P')
                        {
                            flag = true;
                        }

                        bunnyMatrix[bunnyMoves[l, 0], bunnyMoves[l, 1]] = 'B';
                    }
                }

                matrix = bunnyMatrix;
            }
        }

        if (flag)
        {
            BoardPrinter(flag, matrix, bunnyMatrix);
            Console.WriteLine($"dead: {playerPos[0]} {playerPos[1]}");
            return;
        }

        flag = false;
    }

    if (matrix[newPlayerPos[0], newPlayerPos[1]] != 'B')
    {
        matrix[playerPos[0], playerPos[1]] = '.';
        playerPos = newPlayerPos;
        matrix[playerPos[0], playerPos[1]] = 'P';
    }

}

int[] PlayerMover(char direction, int[] playerPos, int[] newPlayerPos)
{
    newPlayerPos = new int[]
    {
        playerPos[0],
        playerPos[1]
    };

    if (direction == 'U')
    {
        newPlayerPos[0]--;
    }
    else if (direction == 'D')
    {
        newPlayerPos[0]++;
    }
    else if (direction == 'L')
    {
        newPlayerPos[1]--;
    }
    else if (direction == 'R')
    {
        newPlayerPos[1]++;
    }

    return newPlayerPos;
}

bool IndexChecker(char[,] matrix, int row, int col)
{
    return row >= 0 && row < matrix.GetLength(0) &&
           col >= 0 && col < matrix.GetLength(1);
}

void BoardPrinter(bool flag, char[,] matrix, char[,] bunnyMatrix)
{
    if (!flag)
    {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                if (matrix[j, k] == 'B')
                {
                    int[,] bunnyMoves =
                    {
                        { j - 1, k },
                        { j + 1, k },
                        { j, k - 1 },
                        { j, k + 1 }
                    };

                    for (int l = 0; l < bunnyMoves.GetLength(0); l++)
                    {
                        if (IndexChecker(matrix, bunnyMoves[l, 0], bunnyMoves[l, 1]))
                        {
                            bunnyMatrix[bunnyMoves[l, 0], bunnyMoves[l, 1]] = 'B';
                        }
                    }
                }
            }
        }
    }

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{bunnyMatrix[i, j]}");
        }

        Console.WriteLine();
    }
}

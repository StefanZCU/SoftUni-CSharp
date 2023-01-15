int sizeMatrix = int.Parse(Console.ReadLine());

char[,] matrix = new char[sizeMatrix, sizeMatrix];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string line = Console.ReadLine();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = line[j];
    }
}

int knightAttacks;
int[] knightToRemove = new int[2];
int knightsRemoved = 0;

do
{
    knightAttacks = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 'K')
            {
                int currentAttacks = AttackChecker(matrix, i, j);

                if (currentAttacks > knightAttacks)
                {
                    knightAttacks = currentAttacks;
                    knightToRemove[0] = i;
                    knightToRemove[1] = j;
                }
            }
        }
    }

    if (knightAttacks != 0)
    {
        matrix[knightToRemove[0], knightToRemove[1]] = '0';
        knightsRemoved++;
    }

} while (knightAttacks != 0);

Console.WriteLine(knightsRemoved);

int AttackChecker(char[,] matrix, int row, int col)
{
    int attacks = 0;
    int[,] directions =
    {
        { row - 2, col - 1 },
        { row - 2, col + 1 },
        { row + 2, col - 1 },
        { row + 2, col + 1 },
        { row - 1, col + 2 },
        { row - 1, col - 2 },
        { row + 1, col - 2 },
        { row + 1, col + 2 }
    };

    for (int i = 0; i < directions.GetLength(0); i++)
    {
        if (IndexChecker(matrix, directions[i, 0], directions[i, 1]))
        {
            int checkRow = directions[i, 0];
            int checkCol = directions[i, 1];

            if (matrix[checkRow, checkCol] == 'K')
            {
                attacks++;
            }
        }
    }

    return attacks;
}

bool IndexChecker(char[,] matrix, int row, int col)
{
    return row >= 0 && row < matrix.GetLength(0) &&
           col >= 0 && col < matrix.GetLength(1);
}



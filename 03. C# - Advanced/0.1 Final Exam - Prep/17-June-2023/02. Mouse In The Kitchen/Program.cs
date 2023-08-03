var matrixSize = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

var matrix = new char[matrixSize[0], matrixSize[1]];
int[] position = new int[2];
int cheeseAmt = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string row = Console.ReadLine();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = row[j];

        switch (row[j])
        {
            case 'M':
                matrix[i, j] = '*';
                position[0] = i;
                position[1] = j;
                break;
            case 'C':
                cheeseAmt++;
                break;
        }
    }
}

string command;
while ((command = Console.ReadLine()) != "danger")
{
    int row = position[0];
    int col = position[1];
    
    switch (command)
    {
        case "up" when IndexChecker(--row, col, matrix):
            position[0]--;
            break;
        case "down" when IndexChecker(++row, col, matrix):
            position[0]++;
            break;
        case "right" when IndexChecker(row, ++col, matrix):
            position[1]++;
            break;
        case "left" when IndexChecker(row, --col, matrix):
            position[1]--;
            break;
        default:
            Console.WriteLine("No more cheese for tonight!");
            MatrixPrinter(position, matrix);
            return;
    }

    row = position[0];
    col = position[1];

    switch (matrix[row, col])
    {
        case 'C':
        {
            matrix[row, col] = '*';
            cheeseAmt--;
            if (cheeseAmt == 0)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                MatrixPrinter(position, matrix);
                return;
            }

            break;
        }
        case 'T':
            Console.WriteLine("Mouse is trapped!");
            MatrixPrinter(position, matrix);
            return;
        case '@':
            switch (command)
            {
                case "up": position[0]++;
                    break;
                case "down": position[0]--;
                    break;
                case "right": position[1]--;
                    break;
                case "left": position[1]++;
                    break;
            }

            break;
    }
    
}

Console.WriteLine("Mouse will come back later!");
MatrixPrinter(position, matrix);

bool IndexChecker(int row, int col, char[,] matrix)
{
    return row >= 0 && row < matrix.GetLength(0) &&
           col >= 0 && col < matrix.GetLength(1);
}

void MatrixPrinter(int[] position, char[,] matrix)
{
    matrix[position[0], position[1]] = 'M';

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }

        Console.WriteLine();
    }
}


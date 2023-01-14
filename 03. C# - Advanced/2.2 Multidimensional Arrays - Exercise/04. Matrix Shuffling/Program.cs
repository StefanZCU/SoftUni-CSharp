using System.Data.Common;

int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

string[,] matrix = new string[matrixSize[0], matrixSize[1]];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    string[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = cols[j];
    }
}

string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (InputChecker(input, matrix))
    {
        int rowOne = int.Parse(input[1]);
        int colOne = int.Parse(input[2]);
        int rowTwo = int.Parse(input[3]);
        int colTwo = int.Parse(input[4]);

        (matrix[rowOne, colOne], matrix[rowTwo, colTwo]) = (matrix[rowTwo, colTwo], matrix[rowOne, colOne]);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

static bool InputChecker(string[] input, string[,] matrix)
{
    if (input.Length == 5)
    {
        int rowOne = int.Parse(input[1]);
        int colOne = int.Parse(input[2]);
        int rowTwo = int.Parse(input[3]);
        int colTwo = int.Parse(input[4]);

        if (rowOne >= 0 && rowOne < matrix.GetLength(0) &&
            rowTwo >= 0 && rowTwo < matrix.GetLength(0) &&
            colOne >= 0 && colOne < matrix.GetLength(1) &&
            colTwo >= 0 && colTwo < matrix.GetLength(1) && input[0] == "swap")
        {

            return true;
        }
    }

    return false;
}

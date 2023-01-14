﻿int numRows = int.Parse(Console.ReadLine());

int[][] jaggedArray = new int[numRows][];

jaggedArray[0] = new int[] { 1 };

for (int i = 1; i < jaggedArray.GetLength(0); i++)
{
    jaggedArray[i] = new int[i + 1];

    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        if (j < jaggedArray[i - 1].Length)
        {
            jaggedArray[i][j] += jaggedArray[i - 1][j];
        }

        if (j - 1 >= 0)
        {
            jaggedArray[i][j] += jaggedArray[i - 1][j - 1];
        }

    }
}


for (int i = 0; i < jaggedArray.GetLength(0); i++)
{
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        Console.Write(jaggedArray[i][j] + " ");
    }

    Console.WriteLine();
}


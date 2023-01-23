using System;
using System.Text;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[8, 8];

            int[] whitePosition = new int[2];
            int[] blackPosition = new int[2];

            for (int i = 0; i < 8; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    if (line[j] == 'w')
                    {
                        whitePosition[0] = i;
                        whitePosition[1] = j;
                    }

                    if (line[j] == 'b')
                    {
                        blackPosition[0] = i;
                        blackPosition[1] = j;
                    }

                    matrix[i, j] = line[j];
                }
            }

            bool whiteWin = false;
            bool blackWin = false;
            int playersTurn = 1; // odd - white, even - black

            while (true)
            {
                if (playersTurn % 2 != 0)
                {
                    int whiteRow = whitePosition[0];
                    int whiteCol = whitePosition[1];

                    int[,] whiteAttacker = new int[,]
                    {
                        { whiteRow - 1, whiteCol - 1 },
                        { whiteRow - 1, whiteCol + 1 }
                    };

                    for (int i = 0; i < whiteAttacker.GetLength(0); i++)
                    {
                        if (AttackCheckerWhite(whiteAttacker[i, 0], whiteAttacker[i, 1], matrix))
                        {
                            if (matrix[whiteAttacker[i, 0], whiteAttacker[i, 1]] == 'b')
                            {
                                whitePosition[0] = whiteAttacker[i, 0];
                                whitePosition[1] = whiteAttacker[i, 1];
                                matrix[whitePosition[0], whitePosition[1]] = 'w';
                                whiteWin = true;
                                break;
                            }
                        }
                    }

                    if (whiteWin)
                    {
                        string position = FindCoordinates(whitePosition[0], whitePosition[1], matrix);
                        Console.WriteLine($"Game over! White capture on {position}.");
                        return;
                    }

                    matrix[whitePosition[0], whitePosition[1]] = '-';
                    whitePosition[0]--;
                    matrix[whitePosition[0], whitePosition[1]] = 'w';

                    if (whitePosition[0] == 0)
                    {
                        string position = FindCoordinates(whitePosition[0], whitePosition[1], matrix);
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {position}.");
                        return;
                    }
                }                


                else
                {
                    int blackRow = blackPosition[0];
                    int blackCol = blackPosition[1];

                    int[,] blackAttacker = new int[,]
                    {
                        { blackRow + 1, blackCol + 1 },
                        { blackRow + 1, blackCol - 1 }
                    };

                    for (int i = 0; i < blackAttacker.GetLength(0); i++)
                    {
                        if (AttackCheckerWhite(blackAttacker[i, 0], blackAttacker[i, 1], matrix))
                        {
                            if (matrix[blackAttacker[i, 0], blackAttacker[i, 1]] == 'w')
                            {
                                blackPosition[0] = blackAttacker[i, 0];
                                blackPosition[1] = blackAttacker[i, 1];
                                matrix[blackPosition[0], blackPosition[1]] = 'b';
                                blackWin = true;
                                break;
                            }
                        }
                    }


                    if (blackWin)
                    {
                        string position = FindCoordinates(blackPosition[0], blackPosition[1], matrix);
                        Console.WriteLine($"Game over! Black capture on {position}.");
                        return;
                    }

                    matrix[blackPosition[0], blackPosition[1]] = '-';
                    blackPosition[0]++;
                    matrix[blackPosition[0], blackPosition[1]] = 'b';
                    
                    if (blackPosition[0] == 7)
                    {
                        string position = FindCoordinates(blackPosition[0], blackPosition[1], matrix);
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {position}.");
                        return;
                    }
                }
                
                playersTurn++;
            }
        }

        static bool AttackCheckerWhite(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        static string FindCoordinates(int row, int col, char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            
            switch (col)
            {
                case 0:
                    sb.Append('a');
                    break;
                case 1:
                    sb.Append('b');
                    break;
                case 2:
                    sb.Append('c');
                    break;
                case 3:
                    sb.Append('d');
                    break;
                case 4:
                    sb.Append('e');
                    break;
                case 5:
                    sb.Append('f');
                    break;
                case 6:
                    sb.Append('g');
                    break;
                case 7:
                    sb.Append('h');
                    break;
            }

            switch (row)
            {
                case 0:
                    sb.Append(8);
                    break;
                case 1:
                    sb.Append(7);
                    break;
                case 2:
                    sb.Append(6);
                    break;
                case 3:
                    sb.Append(5);
                    break;
                case 4:
                    sb.Append(4);
                    break;
                case 5:
                    sb.Append(3);
                    break;
                case 6:
                    sb.Append(2);
                    break;
                case 7:
                    sb.Append(1);
                    break;
            }

            return sb.ToString().TrimEnd();
        }
    }
}

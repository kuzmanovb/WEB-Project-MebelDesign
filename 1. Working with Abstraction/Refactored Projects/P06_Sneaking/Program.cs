﻿using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];
            int[] samPosition = new int[2];
            var samRow = samPosition[0];
            var samCol = samPosition[1];
            FillRoomAndFindSamPosition(n, samPosition);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();

                int[] psitionEnemyInSamRow = FindEnemy(samPosition);

                if (samCol < psitionEnemyInSamRow[1] && room[psitionEnemyInSamRow[0]][psitionEnemyInSamRow[1]] == 'd' && psitionEnemyInSamRow[0] == samRow])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
                else if (psitionEnemyInSamRow[1] < samPosition[1] && room[psitionEnemyInSamRow[0]][psitionEnemyInSamRow[1]] == 'b' && psitionEnemyInSamRow[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }


                room[samPosition[0]][samPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                    default:
                        break;
                }
                room[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        psitionEnemyInSamRow[0] = samPosition[0];
                        psitionEnemyInSamRow[1] = j;
                    }
                }
                if (room[psitionEnemyInSamRow[0]][psitionEnemyInSamRow[1]] == 'N' && samPosition[0] == psitionEnemyInSamRow[0])
                {
                    room[psitionEnemyInSamRow[0]][psitionEnemyInSamRow[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
            }
        }

        private static int[] FindEnemy(int[] samPosition)
        {
            int[] psitionEnemyInSamRow = new int[2];
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    psitionEnemyInSamRow[0] = samPosition[0];
                    psitionEnemyInSamRow[1] = j;
                }
            }
            return psitionEnemyInSamRow;
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FillRoomAndFindSamPosition(int n, int[] samPosition)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }
    }
}

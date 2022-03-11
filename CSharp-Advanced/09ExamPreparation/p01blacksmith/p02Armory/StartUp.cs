using System;
using System.Collections.Generic;

namespace p02Armory
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int officerRow = -1;
            int officerCol = -1;
            int firstMirrorRow = -1;
            int firstMirrorCol = -1;
            int secondMirrorRow = -1;
            int secondMirrorCol = -1;
            int completeSwordPrice = 0;
            bool isSafes = true;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    if (matrix[row, col] == 'M')
                    {
                        if (firstMirrorCol == -1)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                        }
                        else
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                    }
                }
            }
            string cmd = Console.ReadLine();

            while (true)
            {
                matrix[officerRow, officerCol] = '-';
                if (cmd == "up")
                {
                    if (IsSafe(matrix, officerRow, officerCol, cmd, n) == true)
                    {
                        officerRow--;
                    }
                    else
                    {
                        isSafes = false;
                    }
                }
                else if (cmd == "down")
                {
                    if (IsSafe(matrix, officerRow, officerCol, cmd, n) == true)
                    {
                        officerRow++;
                    }
                    else
                    {
                        isSafes = false;
                    }
                }
                else if (cmd == "left")
                {
                    if (IsSafe(matrix, officerRow, officerCol, cmd, n) == true)
                    {
                        officerCol--;
                    }
                    else
                    {
                        isSafes = false;
                    }
                }
                else if (cmd == "right")
                {
                    if (IsSafe(matrix, officerRow, officerCol, cmd, n) == true)
                    {
                        officerCol++;
                    }
                    else
                    {
                        isSafes = false;
                    }
                }
                if (isSafes == false)
                {
                    break;
                }
                if (char.IsDigit(matrix[officerRow, officerCol]))
                {
                    char c = matrix[officerRow, officerCol];
                    int number = (int)c - '0';
                    completeSwordPrice += number;
                    matrix[officerRow, officerCol] = '-';
                }
                if (matrix[officerRow, officerCol] == 'M')
                {
                    if (officerRow == firstMirrorRow && officerCol == firstMirrorCol)
                    {
                        matrix[officerRow, officerCol] = '-';
                        officerRow = secondMirrorRow;
                        officerCol = secondMirrorCol;
                    }
                    else
                    {
                        matrix[officerRow, officerCol] = '-';
                        officerRow = firstMirrorRow;
                        officerCol = firstMirrorCol;
                    }
                }
                if (completeSwordPrice >= 65)
                {
                    break;
                }
                matrix[officerRow, officerCol] = '-';
                 
                cmd = Console.ReadLine();
            }
            if (isSafes==false)
            {
                Console.WriteLine($"I do not need more swords!");
            }
            else
            {
                Console.WriteLine($"Very nice swords, I will come back for more!");
            }
            if (completeSwordPrice >= 0)//>
            {
                Console.WriteLine($"The king paid {completeSwordPrice} gold coins.");
            }
            if (isSafes==true)
            {
                matrix[officerRow, officerCol] = 'A';
            }
            Print(matrix);
        }
        private static bool IsSafe(char[,] matrix, int row, int col, string cmd, int n)
        {
            if (cmd == "up")
            {
                if (row - 1 >= 0)
                {
                    return true;
                }
                return false;
            }
            if (cmd == "down")
            {
                if (row + 1 <= n - 1)
                {
                    return true;
                }
                return false;
            }
            if (cmd == "left")
            {
                if (col - 1 >= 0)
                {
                    return true;
                }
                return false;
            }
            if (cmd == "right")
            {
                if (col + 1 <= n - 1)
                {
                    return true;
                }
                return false;
            }

            return true;
        }
        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
namespace MatrixShuff
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] dataRows = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = dataRows[col];
                }

            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] cmdArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmdArr.Length>5 || cmdArr.Length<5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                if (cmdArr[0] == "swap")
                {
                    int firstRow = int.Parse(cmdArr[1]);
                    int firstCol = int.Parse(cmdArr[2]);
                    int secondRow = int.Parse(cmdArr[3]);
                    int secondCol = int.Parse(cmdArr[4]);
                    bool isValid = firstRow >= 0 && firstRow <= rows && firstCol >= 0 && firstCol <= cols &&
                        secondRow >= 0 && secondRow <= rows && secondCol >= 0 && secondCol <= cols;
                    if (isValid)
                    {
                        string swapper = matrix[firstRow, firstCol];//[]
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = swapper;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine();
                        continue;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }
        }
    }

}


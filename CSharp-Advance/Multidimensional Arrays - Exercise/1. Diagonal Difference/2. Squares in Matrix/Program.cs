using System;
using System.Linq;
using System.Collections.Generic;
namespace SquaresMatrix
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
                string[] dataRows = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = dataRows[col];
                }

            }
            int count = 0;
            for (int row = 0; row < rows -1; row++)
            {

                for (int col = 0; col < cols-1; col++)
                {

                    if (matrix[row, col] == matrix[row, col + 1] &&
                       matrix[row, col] == matrix[row + 1, col + 1] &&
                       matrix[row, col] == matrix[row + 1, col])
                    {
                        count++;
                    }
                }

            }
            Console.WriteLine(count);


        }
    }

}


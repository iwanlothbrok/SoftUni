using System;
using System.Linq;
using System.Collections.Generic;
namespace DiagonalDiff
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            int primarySum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primarySum += matrix[row, row];
            }
            int secondarySum = 0;
            int cols = 0;
            for (int r = matrix.GetLength(0) - 1; r >= 0; r--)
            {
                secondarySum += matrix[r, cols];
                cols++;
            }
            Console.WriteLine(Math.Abs(primarySum-secondarySum));
           
        }
    }
}


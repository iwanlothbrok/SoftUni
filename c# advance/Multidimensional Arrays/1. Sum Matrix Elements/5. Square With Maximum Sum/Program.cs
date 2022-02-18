using System;
using System.Linq;

namespace SquareMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    int currentSum = 0;
                    currentSum += matrix[r, c] + matrix[r, c + 1] + matrix[r + 1, c] + matrix[r + 1, c + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = r;
                        maxCol = c;
                    }
                }
            }

            for (int r = maxRow; r < maxRow + 2; r++)
            {
                for (int c = maxCol; c < maxCol + 2; c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
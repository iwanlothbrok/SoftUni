
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Diagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            int firstSum = 0;
            for (int rows = 0; rows < n; rows++)
            {
                firstSum += matrix[rows][rows];
            }

            int secondSum = 0;
            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondSum += matrix[row][col];
            }
            if (firstSum >= secondSum)
            {
                Console.WriteLine(firstSum);
            }
            else
            {
                Console.WriteLine(secondSum);
            }
        }
    }
}


using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int r = 0; r < size; r++)
            {
                char[] array = Console.ReadLine().ToCharArray();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = array[c];
                }
            }

            string symbol = Console.ReadLine();
            bool isFound = false;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (matrix[r, c].ToString() == symbol)
                    {
                        Console.WriteLine($"({r}, {c})");
                        isFound = true;
                        return;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}

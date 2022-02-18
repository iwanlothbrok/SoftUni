using System;
using System.Linq;

namespace JaggerArray
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int[,] matrix = new int[input, input];
            int rowsMatrix = matrix.GetLength(0);
            int colsMatrix = matrix.GetLength(1);
            for (int row = 0; row < rowsMatrix; row++)
            {
                int[] matrixIncome = Console.ReadLine().Split(" ")
               .Select(int.Parse).ToArray();
                for (int cols = 0; cols < colsMatrix; cols++)
                {
                    matrix[row, cols] = matrixIncome[cols];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] cmd = command.Split();
                if (cmd[0] == "Add")
                {

                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    int value = int.Parse(cmd[3]);
                    if (row > rowsMatrix - 1 || col > colsMatrix - 1 || col < 0 || row < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                        command = Console.ReadLine();
                        continue;
                    }
                    matrix[row, col] += value;
                }
                else if (cmd[0] == "Subtract")
                {

                    int row = int.Parse(cmd[1]);
                    int col = int.Parse(cmd[2]);
                    int value = int.Parse(cmd[3]);
                    if (row > rowsMatrix || col > colsMatrix || col < 0 || row < 0)
                    {
                        Console.WriteLine("Invalid coordinates");
                        command = Console.ReadLine();
                        continue;
                    }
                    matrix[row, col] -= value;
                }


                command = Console.ReadLine();
            }
            for (int rows = 0; rows < rowsMatrix; rows++)
            {
                for (int cols = 0; cols < colsMatrix; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
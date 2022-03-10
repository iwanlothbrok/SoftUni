using System;

namespace p02Snake
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            int barrowFirstRow = -1;
            int barrowFirstCol = -1;
            int barrowSecondRow = -1;
            int barrowSecondCol = -1;
            int foodCount = 0;
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (matrix[row, col] == 'B')
                    {
                        if (barrowFirstCol == -1)
                        {
                            barrowFirstRow = row;
                            barrowFirstCol = col;
                        }
                        else
                        {
                            barrowSecondRow = row;
                            barrowSecondCol = col;
                        }
                    }
                }
            }
            try
            {
                while (true)
                {
                    string cmd = Console.ReadLine();
                    matrix[snakeRow, snakeCol] = '.';
                    if (cmd == "left")
                    {
                        snakeCol--;
                    }
                    if (cmd == "right")
                    {
                        snakeCol++;
                    }
                    if (cmd == "up")
                    {
                        snakeRow--;
                    }

                    if (cmd == "down")
                    {
                        snakeRow++;
                    }
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;
                    }
                    if (foodCount == 10)
                    {
                        matrix[snakeRow, snakeCol] = 'S';
                        Console.WriteLine("You won! You fed the snake.");
                        break;
                    }
                    if (matrix[snakeRow,snakeCol] == 'B')
                    {
                        if (snakeRow == barrowFirstRow && snakeCol == barrowFirstCol)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = barrowSecondRow;
                            snakeCol = barrowSecondCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = barrowFirstRow;
                            snakeCol = barrowFirstCol;
                        }
                    }

                    matrix[snakeRow, snakeCol] = '.';
                   //   Print(matrix); // remove it
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Game over!");
                
            }
            Console.WriteLine($"Food eaten: {foodCount}");
            Print(matrix);
        }
        public static void Print(char[,] matrix)
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

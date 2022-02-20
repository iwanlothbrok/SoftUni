using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            MathOperation(operation, firstNum, secondNum);
        }
        static void MathOperation(string text, int first, int second)
        {
            if (text == "add")
            {
                Console.WriteLine($"{first + second}");
            }
            else if (text == "divide")
            {
                Console.WriteLine($"{first / second}");
            }
            else if (text == "subtract")
            {
                Console.WriteLine($"{first - second}");
            }
            else
            {
                Console.WriteLine($"{first * second}");
            }
        }
    }
}


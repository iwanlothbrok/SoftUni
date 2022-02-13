using System;

namespace _11.Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            char type = char.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());
            decimal result = Calculator(firstNum, type, secondNum);
            Console.WriteLine(result);


        }
        static decimal Calculator(decimal first, char type, decimal second)
        {
            decimal result = 0m;
            if (type == '+')
            {
                result = first + second;
            }
            else if (type == '-')
            {
                result = first - second;
            }
            else if (type == '/')
            {
                result = first / second;
            }
            else if (type == '*')
            {
                result = first * second;
            }
            return result;
        }
    }
}

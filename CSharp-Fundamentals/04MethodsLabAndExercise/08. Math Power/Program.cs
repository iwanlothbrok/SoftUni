using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstN = double.Parse(Console.ReadLine());
            double secondN = double.Parse(Console.ReadLine());
            double totalSum = Calculator(firstN, secondN);
            Console.WriteLine(totalSum);
        }
        static double Calculator(double first, double second)
        {
            double number = 1.0;
            for (int i = 0; i < second; i++)
            {
                number = number * first;
            }
            return number;
        }
    }
}

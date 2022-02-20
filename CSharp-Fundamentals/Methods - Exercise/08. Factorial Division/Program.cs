using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());

            double firstResult = factorial_WhileLoop(firstN);
            double secondResult = factorial_WhileLoop(secondN);
            double totalResult = firstResult / secondResult;

            Console.WriteLine($"{totalResult:f2}");
        }
        public static double factorial_WhileLoop(int num)
        {
            double firstResult = 1;
            while (num != 1)
            {
                firstResult = firstResult * num;
                num = num - 1;
            }
            return firstResult;
        }
    }
}


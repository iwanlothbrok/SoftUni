using System;

namespace _01.Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PositiveOrNegative(num);
        }
        static void PositiveOrNegative(int num)
        {
            if (num == 0)
            {
                Console.WriteLine($"The number 0 is zero.");
            }
            else if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {num} is positive.");
            }
        }
    }
}

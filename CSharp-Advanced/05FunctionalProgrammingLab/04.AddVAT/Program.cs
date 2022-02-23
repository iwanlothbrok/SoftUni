using System;
using System.Linq;
using System.Collections.Generic;
namespace SumOfNumbers

{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> func = x => x * 1.20;
            double[] numbers = Console.ReadLine()
              .Split(", ",StringSplitOptions.RemoveEmptyEntries)
              .Select(double.Parse)
              .Select(func)
              .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
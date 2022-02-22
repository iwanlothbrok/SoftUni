using System;
using System.Linq;
using System.Collections.Generic;
namespace CountSame
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] numbers = Console.ReadLine().Split(' ')
                .Select(double.Parse).ToArray();

            Dictionary<double, int> dictonary = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double n = numbers[i];
                if (!dictonary.ContainsKey(n))
                {
                    dictonary.Add(n, 0);
                }
                dictonary[n]++;
            }

            foreach (var nums in dictonary)
            {
                Console.WriteLine($"{nums.Key} - {nums.Value} times");
            }
        }
    }
}
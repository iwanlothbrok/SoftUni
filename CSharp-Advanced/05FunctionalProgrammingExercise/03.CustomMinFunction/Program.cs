
using System;
using System.Linq;
using System.Collections.Generic;


namespace CustomFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                           .Select(int.Parse).ToArray();

            Func<int[], int> func = n => n.Min();

            Console.WriteLine(func(numbers));
        }
    }
}

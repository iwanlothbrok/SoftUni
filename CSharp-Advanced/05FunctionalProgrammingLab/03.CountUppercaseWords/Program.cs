using System;
using System.Linq;
using System.Collections.Generic;
namespace SumOfNumbers

{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = (x => x[0] == x.ToUpper()[0]);
            string[] command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,command));

        }
    }
}
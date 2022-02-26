
using System;
using System.Linq;
using System.Collections.Generic;


namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ').Where(x => x.Length <= lenght).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}

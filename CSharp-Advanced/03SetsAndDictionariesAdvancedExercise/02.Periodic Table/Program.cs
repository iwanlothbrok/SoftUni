using System;
using System.Linq;
using System.Collections.Generic;
namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
           SortedSet<string> set = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                foreach (string s in input)
                {
                    set.Add(s);
                }
            }
            foreach (var output in set)
            {
                Console.Write(output + " ");
            }
        }
    }
}
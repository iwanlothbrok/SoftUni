using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> output = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string names = Console.ReadLine();

                output.Add(names);
            }
            output.Sort();

            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{output[i]}");
            }
        }
    }
}

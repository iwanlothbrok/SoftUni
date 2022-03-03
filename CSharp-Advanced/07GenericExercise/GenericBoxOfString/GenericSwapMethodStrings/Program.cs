using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }
            Box<string> box = new Box<string>(names);
            int[] indexes = Console.ReadLine().Split(" ")
                            .Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            box.Swap(names, firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}

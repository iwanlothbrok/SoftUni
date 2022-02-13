using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagon = new int[n];

            for (int i = 0; i < n; i++)
            {
                wagon[i] = int.Parse(Console.ReadLine());

            }
            Console.WriteLine(string.Join(' ', wagon));
            Console.WriteLine($"{wagon.Sum()}");
        }
    }
}

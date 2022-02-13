using System;

namespace _05._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string population = Console.ReadLine();
            string squareKm = Console.ReadLine();
            Console.WriteLine($"Town {town} has population of {population} and area {squareKm} square km.");
        }
    }
}

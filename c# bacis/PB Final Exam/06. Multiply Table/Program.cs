using System;
namespace MultiplyTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            char first = n[0];
            char second = n[1];
            char third = n[2];
            int firstN = int.Parse(first.ToString());
            int secondN = int.Parse(second.ToString());
            int thirdN = int.Parse(third.ToString());
            for (
                int i = 1; i <= thirdN; i++)
            {
                for (int j = 1; j <= secondN; j++)
                {
                    for (int e = 1; e <= firstN; e++)
                    {
                        Console.WriteLine($"{i} * {j} * {e} = {i * j * e};");
                    }
                }
            }
        }
    }
}
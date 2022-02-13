using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int allEvenValue = 0;
            int allOddValue = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentN = arr[i];
                if (currentN % 2 == 0)
                {
                    allEvenValue = currentN + allEvenValue;
                }
                else
                {
                    allOddValue = currentN + allOddValue;
                }
            }
            int neededSum = allEvenValue - allOddValue;
            Console.WriteLine(neededSum);
        }
    }
}

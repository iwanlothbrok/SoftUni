using System;
using System.Linq;

namespace EqualSum

{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();

            bool isFound = false;
            for (int curr = 0; curr < input.Length; curr++)
            {
                int sumRight = 0;
                for (int i = curr + 1; i < input.Length; i++)
                {
                    sumRight += input[i];
                }
                int sumLeft = 0;
                for (int j = curr - 1; j >= 0; j--)
                {
                    sumLeft += input[j];
                }
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(curr);
                    isFound = true;
                    break;

                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
